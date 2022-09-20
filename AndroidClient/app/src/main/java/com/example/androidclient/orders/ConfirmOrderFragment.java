package com.example.androidclient.orders;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.android.volley.AuthFailureError;
import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.VolleyLog;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.StringRequest;
import com.example.androidclient.HomeFragment;
import com.example.androidclient.MainActivity;
import com.example.androidclient.R;
import com.example.androidclient.adapters.ProductsAdapter;
import com.example.androidclient.databinding.FragmentConfirmOrderBinding;
import com.example.androidclient.databinding.FragmentDeliveryDetailsBinding;
import com.example.androidclient.network.URLGenerator;
import com.example.androidclient.network.VolleyCallBack;
import com.example.androidclient.network.VolleySingleton;
import com.example.androidclient.objects.CartItemObject;
import com.example.androidclient.objects.OrderObject;
import com.example.androidclient.objects.ProductObject;
import com.example.androidclient.objects.UserAddressObject;
import com.example.androidclient.objects.UserObject;
import com.example.androidclient.ui.UIComponents;
import com.google.android.material.snackbar.Snackbar;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Map;


public class ConfirmOrderFragment extends Fragment implements URLGenerator {


    private FragmentConfirmOrderBinding binding;
    RequestQueue requestQueue;
    UIComponents uiComponents;
    String serverResponseCode;
    UserAddressObject userAddressObject;
    OrderObject orderObject;
    ArrayList<CartItemObject> listItemsToOrder = new ArrayList<>();
    SharedPreferences spOrderSession;
    SharedPreferences spUser;


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        binding = FragmentConfirmOrderBinding.inflate(inflater, container, false);
        return binding.getRoot();
    }



    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        spOrderSession = requireContext().getSharedPreferences("userOrderSessionPref", Context.MODE_PRIVATE);
        spUser = requireContext().getSharedPreferences("userPref", Context.MODE_PRIVATE);
        int total =  ((MakeOrderActivity) requireActivity()).getTotPrice();

        uiComponents = new UIComponents(getActivity());
       String cardNum = spOrderSession.getString("cardNumber","0");
        String last4 = cardNum.substring(cardNum.length() - 4);
        binding.txtOrderCardNum.setText("****"+last4);
        binding.txtOrderCardDate.setText(spOrderSession.getString("ExpireDate","01/23"));
        binding.txtUserName.setText(spOrderSession.getString("userName",""));
        binding.txtStreetN.setText(spOrderSession.getString("streetName",""));
        binding.txtOrderSubTot.setText("R"+total);
        binding.txtTot.setText("R"+(total+60));


        binding.btnSubmitOrder.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

             //   if(requireActivity().getIntent().getParcelableArrayListExtra("listItemsToOrder")!=null){
                binding.ConfirmOrderprogressBar.setVisibility(View.VISIBLE);
                    OrderObject orderObj = new OrderObject();
                    ArrayList<Integer> list = new ArrayList<>();
                    listItemsToOrder = requireActivity().getIntent().getParcelableArrayListExtra("listItemsToOrder");
                    int productPrice=0;
                    int totalPrice=0;



                    for(int i=0;i<listItemsToOrder.size();i++){
                       list.add(listItemsToOrder.get(i).getProductId());
                      // orderObj.getListOfCartItemId().add(listItemsToOrder.get(i).getProductId());
                       productPrice=listItemsToOrder.get(i).getProductPrice();
                       productPrice = productPrice*listItemsToOrder.get(i).getQuantity();
                       totalPrice+=productPrice;

                    }


                    orderObj.setListOfCartItemId(list);
                    orderObj.setCardId(Integer.parseInt(spOrderSession.getString("userOrderSessionPref","-1")));
                    orderObj.setUserId(Integer.parseInt(spUser.getString("pref_Id", "-1")));
                    orderObj.setTotalPrice(totalPrice);
                    orderObj.setTotalItems(listItemsToOrder.size());
                    orderObj.setPaymentMade("Paid");
                    orderObj.setOrderStatus("Waiting to be fulfilled");
                    Log.e("Passed there"," created usreObj");
                    orderObject = orderObj;


                    requestQueue = VolleySingleton.getVolleyInstance(getContext()).getRequestQueue();
                    try {
                        POSTCheckoutOrderRequest(new VolleyCallBack() {
                            @Override
                            public void OnSuccess() {

                                if (serverResponseCode != null) {

                                    switch(serverResponseCode){
                                        case "200":
                                            binding.ConfirmOrderprogressBar.setVisibility(View.GONE);
                                            Log.e("RESPONSE CODE 200: made order ", serverResponseCode);
                                            Snackbar sb = Snackbar.make(getActivity().findViewById(android.R.id.content),
                                                    "Thank you! your order has been received", Snackbar.LENGTH_LONG);
                                            sb.show();
                                            sb.addCallback(new Snackbar.Callback() {

                                                @Override
                                                public void onDismissed(Snackbar snackbar, int event) {
                                                    if (event == Snackbar.Callback.DISMISS_EVENT_TIMEOUT) {
                                                        Intent intent = new Intent(getActivity(), MainActivity.class);
                                                        startActivity(intent);
                                                        getActivity().finish();
                                                    }
                                                }

                                                @Override
                                                public void onShown(Snackbar snackbar) {

                                                }
                                            });

                                            break;

                                        case "201":
                                            uiComponents.alertDialog_DefaultNoCancel("Email already exist, please try another email", "Sign up Failed", "OK");
                                            break;

                                        case "202":
                                            uiComponents.alertDialog_DefaultNoCancel("Internal server error, please try again", "Internal error", "Ok");
                                            break;

                                        default:
                                            uiComponents.alertDialog_DefaultNoCancel("Server is temporarily down. Please try again later", "Error", "Ok");
                                            break;

                                    }

                                    serverResponseCode = null;
                                }

                            }
                        });
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }

            }
        });





    }

    @Override
    public String generateURL() {
        String cleanUrl = getResources().getString(R.string.WCF_URL);
        return cleanUrl + "CheckoutOrder";
    }


    public void POSTCheckoutOrderRequest(final VolleyCallBack callBack) throws JSONException{

        JSONObject jsonBody = new JSONObject();
        SharedPreferences spUser = requireContext().getSharedPreferences("userPref", Context.MODE_PRIVATE);
        SharedPreferences spOrder = requireContext().getSharedPreferences("userOrderSessionPref", Context.MODE_PRIVATE);


        JSONObject json = new JSONObject();
        json.put("orderId","-1");
        json.put("cardId", "-1");
        json.put("userId", spUser.getString("pref_Id","-1"));
        json.put("paymentId", "-1");
        json.put("userAddressId", "-1");
        json.put("totalPrice", orderObject.getTotalPrice());
        json.put("totalItems", orderObject.getTotalItems());
        json.put("paymentMade", "true");
        json.put("orderStatus", "Pending");
        JSONArray jsonArray = new JSONArray();
        for(int i=0;i<orderObject.getListOfCartItemId().size();i++){
            jsonArray.put(orderObject.getListOfCartItemId().get(i));
        }
        json.put("listOfCartItemId",jsonArray);


        final String mRequestBody = json.toString();

        StringRequest stringRequest = new StringRequest(Request.Method.POST, generateURL(), new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                String jsonObj = response.toString();
                if (jsonObj.contains("1")) {
                    serverResponseCode = getResources().getString(R.string.response_success);
                }else if(jsonObj.contains("0")){
                    serverResponseCode="201";
                }else if(jsonObj.contains("-1")){
                    serverResponseCode="202";
                }else {
                    serverResponseCode = getResources().getString(R.string.response_login_error);
                    Log.e("Inside response", "returned null object from server login");
                }

                callBack.OnSuccess();

            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                VolleyLog.e("Error: ", error.getMessage());
                Log.e("Succes response",error.toString());
                serverResponseCode = null;
                callBack.OnSuccess();
            }
        }){
            @Override
            public String getBodyContentType() {
                return "application/json; charset=utf-8";
            }
            @Override
            public byte[] getBody() throws AuthFailureError {
                try {
                    return mRequestBody == null ? null : mRequestBody.getBytes("utf-8");
                } catch (UnsupportedEncodingException uee) {
                    VolleyLog.wtf("Unsupported Encoding while trying to get the bytes of %s using %s", mRequestBody, "utf-8");
                    return null;
                }
            }

           /* @Override
            protected Response<String> parseNetworkResponse(NetworkResponse response) {
                String responseString = "";
                if (response != null) {
                    responseString = String.valueOf(response.statusCode);
                }
                return Response.success(responseString, HttpHeaderParser.parseCacheHeaders(response));
            }*/
        };


        stringRequest.setRetryPolicy(new DefaultRetryPolicy(5000, 3, DefaultRetryPolicy.DEFAULT_BACKOFF_MULT));

        requestQueue.add(stringRequest);
    }


}