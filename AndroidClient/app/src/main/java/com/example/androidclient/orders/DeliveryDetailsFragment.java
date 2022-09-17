package com.example.androidclient.orders;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.os.Handler;
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
import com.android.volley.toolbox.StringRequest;
import com.example.androidclient.MainActivity;
import com.example.androidclient.databinding.FragmentDeliveryDetailsBinding;
import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

import com.example.androidclient.R;
import com.example.androidclient.network.URLGenerator;
import com.example.androidclient.network.VolleyCallBack;
import com.example.androidclient.network.VolleySingleton;
import com.example.androidclient.objects.UserAddressObject;
import com.example.androidclient.ui.UIComponents;
import com.google.android.material.snackbar.Snackbar;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.UnsupportedEncodingException;
import java.util.Objects;


public class DeliveryDetailsFragment extends Fragment implements URLGenerator {

    private FragmentDeliveryDetailsBinding binding;
    String serverResponseCode;
    UIComponents uiComponents;
    RequestQueue requestQueue;
    SharedPreferences sharedPreferences;

    @Override
    public View onCreateView(
            LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState
    ) {

        binding = FragmentDeliveryDetailsBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        sharedPreferences = requireContext().getSharedPreferences("user_pref",Context.MODE_PRIVATE);
        uiComponents = new UIComponents(getActivity());
        binding.btnContinueOrder.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                requestQueue = VolleySingleton.getVolleyInstance(getContext()).getRequestQueue();
                try {
                    POSTUserAddressRequest(new VolleyCallBack() {
                        @Override
                        public void OnSuccess() {

                                    if (serverResponseCode != null) {

                                        switch(serverResponseCode){
                                            case "200":
                                                Log.e("RESPONSE CODE 200: ", serverResponseCode);
                                               int uId = Integer.parseInt(sharedPreferences.getString("pref_Id","-1"));
                                                ((MakeOrderActivity) requireActivity()).getOrderObject().setOrderStatus("Pending");
                                                ((MakeOrderActivity) requireActivity()).getOrderObject().setUserId(uId);
                                                createUserAddressSharedPreferences();
                                                ((MakeOrderActivity) requireActivity()).getOrderViewPager().setCurrentItem(1,true);
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

        binding.btnCancelOrder.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                requireActivity().finish();
            }
        });

    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }


    @Override
    public String generateURL() {
        return getResources().getString(R.string.WCF_URL)+"StoreUserAddress";
    }


    public void POSTUserAddressRequest(final VolleyCallBack callBack) throws JSONException{

        JSONObject jsonBody = new JSONObject();
        sharedPreferences = getContext().getSharedPreferences("userPref", Context.MODE_PRIVATE);

        String id = sharedPreferences.getString("pref_Id", "-1");


        jsonBody.put("userId",id);
        jsonBody.put("country", binding.txtCountry.getText());
        jsonBody.put("province", binding.txtProvince.getText());
        jsonBody.put("city", binding.txtCity.getText());
        jsonBody.put("streetUnit", binding.txtStreetUnit.getText());
        jsonBody.put("name",binding.txtName.getText());
        jsonBody.put("surname",binding.txtSurname.getText());
        jsonBody.put("cellPhone",binding.txtCellPhone.getText());
        jsonBody.put("email",binding.txtEmail.getText());
        final String mRequestBody = jsonBody.toString();

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

        stringRequest.setRetryPolicy(new DefaultRetryPolicy(3000, 3, DefaultRetryPolicy.DEFAULT_BACKOFF_MULT));

        requestQueue.add(stringRequest);
    }


    public void createUserAddressSharedPreferences(){

      SharedPreferences userSharedPreferences = requireContext().getSharedPreferences("userOrderSessionPref", Context.MODE_PRIVATE);
      SharedPreferences.Editor editor = userSharedPreferences.edit();
      editor.putString("streetName",binding.txtStreetUnit.getText().toString());
      editor.putString("userName",binding.txtName.getText().toString()+" "+binding.txtSurname.getText().toString());
      editor.commit();

    }
}