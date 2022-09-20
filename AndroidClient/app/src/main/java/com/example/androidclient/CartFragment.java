package com.example.androidclient;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.fragment.NavHostFragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.android.volley.AuthFailureError;
import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.VolleyLog;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.StringRequest;
import com.example.androidclient.adapters.BuildCartAdapter;
import com.example.androidclient.adapters.CartAdapter;
import com.example.androidclient.databinding.FragmentCartBinding;
import com.example.androidclient.network.URLGenerator;
import com.example.androidclient.network.VolleyCallBack;
import com.example.androidclient.network.VolleySingleton;
import com.example.androidclient.objects.BuildObject;
import com.example.androidclient.objects.CartItemObject;
import com.example.androidclient.objects.ProductObject;
import com.example.androidclient.orders.MakeOrderActivity;
import com.example.androidclient.ui.ICartClickHandler;
import com.example.androidclient.ui.IRecyclerViewClickHandler;
import com.example.androidclient.ui.UIComponents;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Objects;


public class CartFragment extends Fragment implements IRecyclerViewClickHandler, ICartClickHandler, URLGenerator {


    BuildObject[] buildObject = null;
    ArrayList<BuildObject> list = new ArrayList<>();
    RequestQueue requestQueue;
    StringRequest stringRequest;
    BuildObject build = new BuildObject();
    String serverResponseCode;
    ProductObject productObject = new ProductObject();
    UIComponents uiComponents;
    BuildCartAdapter buildAdapter;
    SharedPreferences sharedPreferences;
    private FragmentCartBinding binding;


    public CartFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        binding = FragmentCartBinding.inflate(inflater, container, false);
        return binding.getRoot();
    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);


        NavController navController = Navigation.findNavController(getActivity(), R.id.nav_host_fragment_content_main);
        ((AppCompatActivity) getActivity()).getSupportActionBar().setDisplayHomeAsUpEnabled(false);
        uiComponents = new UIComponents(getActivity());
        requestQueue = VolleySingleton.getVolleyInstance(getContext()).getRequestQueue();

        if(((MainActivity) requireActivity()).getDynamicTotalPriceCart()!=0){

            int totPrice = ((MainActivity) requireActivity()).getDynamicTotalPriceCart();
            int ItemsNum = ((MainActivity) requireActivity()).getPersistantCartlist().size();
            binding.txtCartTotal.setText("R"+totPrice);
            binding.txtTotalItemsCart.setText("("+((MainActivity) requireActivity()).getPersistantCartlist().size()+") items in cart");
        }

        if(list.isEmpty()){
            GETAllUserBuildsRequest(new VolleyCallBack() {
                @Override
                public void OnSuccess() {

                    if (serverResponseCode != null) {
                        if (serverResponseCode.equals("200")) {
                            Log.e("RESPONSE CODE 200: ", serverResponseCode);
                            list.addAll(Arrays.asList(buildObject));
                            buildAdapter = new BuildCartAdapter(list, CartFragment.this);
                            LinearLayoutManager linearLayoutManager2 = new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.HORIZONTAL, false);
                            binding.recyclerMyBuildsCart.setLayoutManager(linearLayoutManager2);
                            binding.recyclerMyBuildsCart.setAdapter(buildAdapter);
                            //NOTE THIS LINE. Might cause null response

                        }
                    } else {

                        uiComponents.alertDialog_DefaultNoCancel("Server is temporarily down. Please try again later", "Error", "Ok");
                    }
                    serverResponseCode = null;

                }
            });

        }else{
            buildAdapter = new BuildCartAdapter(list, CartFragment.this);
            LinearLayoutManager linearLayoutManager2 = new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.HORIZONTAL, false);
            binding.recyclerMyBuildsCart.setLayoutManager(linearLayoutManager2);
            binding.recyclerMyBuildsCart.setAdapter(buildAdapter);
        }

        ((MainActivity) requireActivity()).cartAdapter = new CartAdapter(((MainActivity) requireActivity()).getPersistantCartlist(),getContext(),this );
        LinearLayoutManager linearLayoutManager = new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.VERTICAL, false);
        binding.recyclerCart.setLayoutManager(linearLayoutManager);
        binding.recyclerCart.setAdapter(((MainActivity) requireActivity()).cartAdapter);

        ((MainActivity) requireActivity()).cartAdapter.registerAdapterDataObserver(new RecyclerView.AdapterDataObserver() {
            @Override
            public void onChanged() {
                super.onChanged();
                String cartNum = "("+((MainActivity) requireActivity()).getPersistantCartlist().size()+") items in cart";
                binding.txtCartTotal.setText("R"+((MainActivity) requireActivity()).getDynamicTotalPriceCart());
                binding.txtTotalItemsCart.setText(cartNum);
            }
        });

        binding.btnProceedToCheckout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ArrayList<CartItemObject> listToOrder = new ArrayList<>();

                ArrayList<ProductObject> localList;
                sharedPreferences = requireContext().getSharedPreferences("userPref", Context.MODE_PRIVATE);
                int userId = Integer.parseInt(sharedPreferences.getString("pref_Id","-1"));
                if(sharedPreferences!=null){
                    int subTotal=0;
                    localList = ((MainActivity) requireActivity()).getPersistantCartlist();
                    int size = ((MainActivity) requireActivity()).cartAdapter.getItemCount();
                    if(size!=0){
                        for(int i=0;i<size;i++){
                            String quantity = ((EditText) Objects.requireNonNull(binding.recyclerCart.findViewHolderForAdapterPosition(i)).itemView.findViewById(R.id.txtQuantityNum)).getText().toString();
                            CartItemObject cartItem = new CartItemObject();
                            cartItem.setProductId(localList.get(i).getId());
                            cartItem.setQuantity(Integer.parseInt(quantity));
                            cartItem.setUserId(userId);
                            cartItem.setProductPrice(localList.get(i).getIntPrice());
                            listToOrder.add(cartItem);
                            subTotal+= localList.get(i).getIntPrice();

                        }

                        SharedPreferences userSharedPreferences = requireContext().getSharedPreferences("userOrderSessionPref", Context.MODE_PRIVATE);
                        SharedPreferences.Editor editor = userSharedPreferences.edit();
                        editor.putInt("orderSubTotal",subTotal);

                        Intent intent = new Intent(getActivity(), MakeOrderActivity.class);
                        intent.putParcelableArrayListExtra("listItemsToOrder",listToOrder);
                        intent.putExtra("OrderSubTotal",subTotal);
                        startActivity(intent);

                       // NavHostFragment.findNavController(CartFragment.this)
                         //      .navigate(R.id.action_cartFragment_to_orders_nav_graph,bundle);

                    }
                }




            }
        });

    }


    @Override
    public void onItemClick(int position) {

        Bundle bundle = new Bundle();
        bundle.putParcelable("selectedBuildDisplay", list.get(position));
        NavHostFragment.findNavController(CartFragment.this)
                .navigate(R.id.action_cartFragment_to_displayBuildFragment, bundle);
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }


    @Override
    public String generateURL() {
        String cleanUrl = getResources().getString(R.string.WCF_URL);
        return cleanUrl + "FetchAllUserBuildsURI/";
    }


    public void GETAllUserBuildsRequest(final VolleyCallBack callBack) {

        SharedPreferences sharedPreferences = requireContext().getSharedPreferences("userPref", Context.MODE_PRIVATE);
        String id = sharedPreferences.getString("pref_Id", "-1");

        //JSONObject Request initialized
        JsonObjectRequest JsonObjectRequest = new JsonObjectRequest(Request.Method.GET, generateURL() + id, null,
                new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                       // BuildObject buildObjects = null;
                        try {
                            GsonBuilder builder = new GsonBuilder();
                            builder.serializeNulls();
                            Gson gson = builder.setPrettyPrinting().create();
                            JSONArray buildsArr = response.getJSONArray("FetchAllUserBuildsResult");
                            buildObject = gson.fromJson(String.valueOf(buildsArr), BuildObject[].class);
                            serverResponseCode = getResources().getString(R.string.response_success);
                        } catch (JSONException e) {
                            e.printStackTrace();

                        }
                        callBack.OnSuccess();
                    }
                },
                new Response.ErrorListener() {
                    @Override
                    public void onErrorResponse(VolleyError error) {
                        String body = "";
                        serverResponseCode = null;
                        Log.e("Error response", error.toString());
                        callBack.OnSuccess();
                    }
                }
        );

        JsonObjectRequest.setRetryPolicy(new DefaultRetryPolicy(3000, 3, DefaultRetryPolicy.DEFAULT_BACKOFF_MULT));

        requestQueue.add(JsonObjectRequest);
    }

    @Override
    public void onPause() {
        super.onPause();
     //   list.clear();
    }

    @Override
    public void OncartClickListener(int pos) {




    }



}