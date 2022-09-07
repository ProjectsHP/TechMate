package com.example.androidclient;

import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.fragment.NavHostFragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.StringRequest;
import com.example.androidclient.adapters.BuildCartAdapter;
import com.example.androidclient.adapters.CartAdapter;
import com.example.androidclient.adapters.CategoryAdapter;
import com.example.androidclient.adapters.ProductsAdapter;
import com.example.androidclient.databinding.FragmentCartBinding;
import com.example.androidclient.databinding.FragmentCategoryBinding;
import com.example.androidclient.network.URLGenerator;
import com.example.androidclient.network.VolleyCallBack;
import com.example.androidclient.network.VolleySingleton;
import com.example.androidclient.objects.BuildObject;
import com.example.androidclient.objects.ProductObject;
import com.example.androidclient.ui.IRecyclerViewClickHandler;
import com.example.androidclient.ui.UIComponents;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Map;


public class CartFragment extends Fragment implements IRecyclerViewClickHandler, URLGenerator {


    private FragmentCartBinding binding;
    BuildObject[] buildObject =null;
    ArrayList<BuildObject> list = new ArrayList<>();
    RequestQueue requestQueue;
    StringRequest stringRequest;
    BuildObject build = new BuildObject();
    String serverResponseCode;
    ArrayList<ProductObject> buildList = new ArrayList<>();
    ProductObject productObject  = new ProductObject();
    UIComponents uiComponents;



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
      //  ((MainActivity) getActivity()).getSupportActionBar().setDisplayHomeAsUpEnabled(false);
        //((MainActivity) getActivity()).getSupportActionBar().setDisplayShowHomeEnabled(false);

        uiComponents = new UIComponents(getActivity());
        requestQueue = VolleySingleton.getVolleyInstance(getContext()).getRequestQueue();

        GETAllUserBuildsRequest(new VolleyCallBack() {
            @Override
            public void OnSuccess() {

                if (serverResponseCode != null) {
                    if (serverResponseCode.equals("200")) {
                        Log.e("RESPONSE CODE 200: ", serverResponseCode);
                        list.addAll(Arrays.asList(buildObject));
                        BuildCartAdapter adapter2 = new BuildCartAdapter(list,CartFragment.this);
                        LinearLayoutManager linearLayoutManager2=new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.HORIZONTAL,false);
                        binding.recyclerMyBuildsCart.setLayoutManager(linearLayoutManager2);
                        binding.recyclerMyBuildsCart.setAdapter(adapter2);
                        //NOTE THIS LINE. Might cause null response


                    }
                } else {

                    uiComponents.alertDialog_DefaultNoCancel("Server is temporarily down. Please try again later", "Error", "Ok");
                }
                serverResponseCode = null;

            }
        });



        CartAdapter adapter = new CartAdapter(buildList,this);

        Bundle bundle = this.getArguments();
        if (bundle != null) {
            build = bundle.getParcelable("addBuildToCrt");
            buildList.add(build.getGraphicsComponent());
            buildList.add(build.getRamComponent());
            buildList.add(build.getCpuComponent());
            buildList.add(build.getStorageComponent());
            buildList.add(build.getBaseCaseComponent());
            adapter.notifyDataSetChanged();

        }

        LinearLayoutManager linearLayoutManager=new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.VERTICAL,false);
        binding.recyclerCart.setLayoutManager(linearLayoutManager);
        binding.recyclerCart.setAdapter(adapter);

    }

    @Override
    public void onItemClick(int position) {

        Bundle bundle = new Bundle();
        bundle.putParcelable("selectedBuild",list.get(position));
        NavHostFragment.findNavController(CartFragment.this)
                .navigate(R.id.action_cartFragment_to_displayBuildFragment,bundle);
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
        JsonObjectRequest JsonObjectRequest = new JsonObjectRequest(Request.Method.GET, generateURL()+id, null,
                new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                        BuildObject buildObjects=null;

                        try {
                            GsonBuilder builder = new GsonBuilder();
                            builder.serializeNulls();
                            Gson gson = builder.setPrettyPrinting().create();
                            JSONArray buildsArr = response.getJSONArray("FetchAllUserBuildsResult");

                            buildObject = gson.fromJson(String.valueOf(buildsArr),BuildObject[].class);
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


}