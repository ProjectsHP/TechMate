package com.example.androidclient;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.StringRequest;
import com.example.androidclient.adapters.ItemListAdapter;
import com.example.androidclient.adapters.ProductsAdapter;
import com.example.androidclient.databinding.FragmentItemsListBinding;
import com.example.androidclient.network.URLGenerator;
import com.example.androidclient.network.VolleyCallBack;
import com.example.androidclient.network.VolleySingleton;
import com.example.androidclient.objects.ProductObject;
import com.example.androidclient.ui.IRecyclerViewClickHandler;
import com.example.androidclient.ui.UIComponents;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.Arrays;

public class ItemsListFragment extends Fragment implements IRecyclerViewClickHandler, URLGenerator {

    private FragmentItemsListBinding binding;
    ArrayList<ProductObject> list = new ArrayList<>();
    RequestQueue requestQueue;
    StringRequest stringRequest;
    String serverResponseCode;
    String selectedCategory;
    UIComponents uiComponents;
    ItemsListActivity listActivity;
    ProductObject[] productObject =null;

    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState
    ) {

        binding = FragmentItemsListBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);



        listActivity = (ItemsListActivity) getActivity();
        uiComponents = new UIComponents(getActivity());
        requestQueue = VolleySingleton.getVolleyInstance(getContext()).getRequestQueue();

        GETComponentsByCategoryRequest(new VolleyCallBack() {
            @Override
            public void OnSuccess() {

                if (serverResponseCode != null) {
                    if (serverResponseCode.equals("200")) {
                        Log.e("RESPONSE CODE 200: ", serverResponseCode);
                        list.addAll(Arrays.asList(productObject));                  //NOTE THIS LINE. Might cause null response
                        ItemListAdapter adapter = new ItemListAdapter(list,getContext(), ItemsListFragment.this);
                        binding.recyclerListItems.setLayoutManager(new GridLayoutManager(getContext(),2));
                        binding.recyclerListItems.setAdapter(adapter);
                    }
                } else {

                    uiComponents.alertDialog_DefaultNoCancel("Server is temporarily down. Please try again later", "Error", "Ok");
                }
                serverResponseCode = null;

            }
        });


    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

    @Override
    public void onItemClick(int position) {

        Bundle bundle = new Bundle();
       bundle.putParcelable("selectedProduct",list.get(position));
        NavHostFragment.findNavController(ItemsListFragment.this)
                        .navigate(R.id.action_ItemsListFragment_to_ProductDetailsFragment,bundle);


    }


    public void GETComponentsByCategoryRequest(final VolleyCallBack callBack) {

        String url = generateURL()+listActivity.getSelectedCategory();
        //JSONObject Request initialized
        JsonObjectRequest JsonObjectRequest = new JsonObjectRequest(Request.Method.GET, url, null,
                new Response.Listener<JSONObject>() {
                    @Override
                    public void onResponse(JSONObject response) {
                        ProductObject[] productObjects=null;

                        try {
                            JSONArray productsArr = response.getJSONArray("FetchComponentsByCategoryResult");
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


    @Override
    public String generateURL() {
        String cleanUrl = getResources().getString(R.string.WCF_URL);
        return cleanUrl + "FetchComponentsByCategoryURI/";
    }
}