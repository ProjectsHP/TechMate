package com.example.androidclient;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.StringRequest;
import com.example.androidclient.adapters.ProductsAdapter;
import com.example.androidclient.databinding.FragmentHomeBinding;
import com.example.androidclient.network.URLGenerator;
import com.example.androidclient.network.VolleyCallBack;
import com.example.androidclient.network.VolleySingleton;
import com.example.androidclient.objects.ProductObject;
import com.example.androidclient.objects.UserObject;
import com.example.androidclient.ui.IRecyclerViewClickHandler;
import com.example.androidclient.ui.UIComponents;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.fragment.NavHostFragment;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Arrays;

public class HomeFragment extends Fragment implements IRecyclerViewClickHandler , URLGenerator {

    private FragmentHomeBinding binding;
    private ImageView toolbarIcon;
    UIComponents uiComponents;
    ProductObject[] productObject =null;
    ArrayList<ProductObject> list = new ArrayList<>();
    RequestQueue requestQueue;
    StringRequest stringRequest;
    String serverResponseCode;
    ProductsAdapter adapter;

    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState) {
        binding = FragmentHomeBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

//        NavController navController = Navigation.findNavController(getActivity(), R.id.nav_host_fragment_content_main);
    //    ((MainActivity) getActivity()).getSupportActionBar().setDisplayHomeAsUpEnabled(false);
        uiComponents = new UIComponents(getActivity());
        requestQueue = VolleySingleton.getVolleyInstance(getContext()).getRequestQueue();

        if(list.isEmpty()){
            GETRandomComponentsRequest(new VolleyCallBack() {
                @Override
                public void OnSuccess() {

                    if (serverResponseCode != null) {
                        if (serverResponseCode.equals("200")) {
                            Log.e("RESPONSE CODE 200: ", serverResponseCode);
                            list.addAll(Arrays.asList(productObject));                  //NOTE THIS LINE. Might cause null response
                             adapter = new ProductsAdapter(list,getContext() ,HomeFragment.this);
                            LinearLayoutManager linearLayoutManager=new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.HORIZONTAL,false);
                            binding.recyclerPopularProducts.setLayoutManager(linearLayoutManager);
                            binding.recyclerPopularProducts.setAdapter(adapter);
                        }
                    } else {

                        uiComponents.alertDialog_DefaultNoCancel("Server is temporarily down. Please try again later", "Error", "Ok");
                    }
                    serverResponseCode = null;
                }
            });

        }else{
            adapter = new ProductsAdapter(list,getContext(), HomeFragment.this);
            LinearLayoutManager linearLayoutManager=new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.HORIZONTAL,false);
            binding.recyclerPopularProducts.setLayoutManager(linearLayoutManager);
            binding.recyclerPopularProducts.setAdapter(adapter);
        }

    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }


    @Override
    public void onResume() {
        super.onResume();
        ((AppCompatActivity)getActivity()).getSupportActionBar().setLogo(R.mipmap.logo_bk);
        ((AppCompatActivity)getActivity()).getSupportActionBar().setDisplayShowTitleEnabled(false);
        ((MainActivity) getActivity()).getSupportActionBar().setDisplayUseLogoEnabled(true);

    }

//    @Override
//    public void onPause() {
//        super.onPause();
//        ((AppCompatActivity)getActivity()).getSupportActionBar().setDisplayShowTitleEnabled(true);
//        ((MainActivity) getActivity()).getSupportActionBar().setDisplayUseLogoEnabled(false);
//    }

    @Override
    public void onStop() {
        super.onStop();
        ((AppCompatActivity)getActivity()).getSupportActionBar().setDisplayShowTitleEnabled(true);
        ((MainActivity) getActivity()).getSupportActionBar().setDisplayUseLogoEnabled(false);

    }

    @Override
    public void onItemClick(int position) {

        Bundle bundle = new Bundle();
        bundle.putParcelable("selectedProduct",list.get(position));
        NavHostFragment.findNavController(HomeFragment.this)
                        .navigate(R.id.action_homeFragment_to_productDetailsFragment,bundle);
    }

    @Override
    public String generateURL() {
        String cleanUrl = getResources().getString(R.string.WCF_URL);
        return cleanUrl + "FetchRandomComponentsURI/9";
    }


    public void GETRandomComponentsRequest(final VolleyCallBack callBack) {

        //JSONObject Request initialized
        JsonObjectRequest JsonObjectRequest = new JsonObjectRequest(Request.Method.GET, generateURL(), null,
                new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                        ProductObject[] productObjects=null;

                        try {
                            JSONArray productsArr = response.getJSONArray("FetchRandomComponentsResult");
                            GsonBuilder builder = new GsonBuilder();
                            builder.serializeNulls();
                            Gson gson = builder.setPrettyPrinting().create();
                            productObject = gson.fromJson(String.valueOf(productsArr),ProductObject[].class);
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
                        Log.e("Error response",error.toString());
                        callBack.OnSuccess();
                    }
                }
        );
        JsonObjectRequest.setRetryPolicy(new DefaultRetryPolicy(3000, 3, DefaultRetryPolicy.DEFAULT_BACKOFF_MULT));

        requestQueue.add(JsonObjectRequest);
    }

//    @Override
//    public boolean onCreateOptionsMenu(Menu menu) {
//        MenuInflater inflater = getMenuInflater();
//        inflater.inflate(R.menu.options_menu, menu);
//
//        return true;
//    }




}