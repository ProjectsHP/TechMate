package com.example.androidclient;

import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;
import androidx.preference.EditTextPreference;
import androidx.preference.Preference;
import androidx.preference.PreferenceFragmentCompat;

import com.android.volley.AuthFailureError;
import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.VolleyLog;
import com.android.volley.toolbox.StringRequest;
import com.example.androidclient.databinding.ActivityUserProfileBinding;
import com.example.androidclient.login.LoginActivity;
import com.example.androidclient.network.URLGenerator;
import com.example.androidclient.network.VolleyCallBack;
import com.example.androidclient.network.VolleySingleton;
import com.example.androidclient.objects.UserObject;
import com.example.androidclient.ui.UIComponents;
import com.google.android.material.appbar.CollapsingToolbarLayout;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.android.material.snackbar.Snackbar;

import org.json.JSONException;
import org.json.JSONObject;

import java.nio.charset.StandardCharsets;
import java.util.Objects;

public class UserProfile extends AppCompatActivity implements URLGenerator {

    public UserObject userObject;
    public UIComponents uiComponents;
    String serverResponseCode;
    SharedPreferences sharedPreferences;
    private AppBarConfiguration appBarConfiguration;
    Context context;
    RequestQueue requestQueue;
    private ActivityUserProfileBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        if (savedInstanceState == null) {
            getSupportFragmentManager()
                    .beginTransaction()
                    .replace(R.id.profileContentHolder, new ProfileFragment())
                    .commit();

        }

        binding = ActivityUserProfileBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());
        setSupportActionBar(binding.userToolbar);


        Objects.requireNonNull(getSupportActionBar()).setDisplayHomeAsUpEnabled(true);
        getSupportActionBar().setDisplayShowHomeEnabled(true);
        uiComponents = new UIComponents(this);
        CollapsingToolbarLayout toolBarLayout = binding.userToolbarLayout;
        toolBarLayout.setTitle("Profile");
        FloatingActionButton fab = binding.fab;
        // userPreferences = PreferenceManager.getDefaultSharedPreferences(getBaseContext());

        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });

        binding.userToolbar.setOnMenuItemClickListener(new Toolbar.OnMenuItemClickListener() {
            @Override
            public boolean onMenuItemClick(MenuItem item) {
                switch (item.getItemId()) {
                    case R.id.action_update_changes:

                        //Check responseCode n update accordingly
                        try {
                            requestQueue = VolleySingleton.getVolleyInstance(UserProfile.this).getRequestQueue();
                            POSTEditUserRequest(new VolleyCallBack() {
                                @Override
                                public void OnSuccess() {

                                    if (serverResponseCode != null) {

                                        switch (serverResponseCode) {
                                            case "200":
                                                Log.e("RESPONSE CODE 200: ", serverResponseCode);
                                                Snackbar.make(getWindow().getDecorView().getRootView(), "Profile successfully updated", Snackbar.LENGTH_LONG)
                                                        .setAction("Action", null).show();
                                                break;

                                            case "201":
                                                Snackbar.make(getWindow().getDecorView().getRootView(), "User cannot be found", Snackbar.LENGTH_LONG)
                                                        .setAction("Action", null).show();
                                                break;

                                            case "202":
                                                Snackbar.make(getWindow().getDecorView().getRootView(), "Unexpected error, please try again", Snackbar.LENGTH_LONG)
                                                        .setAction("Action", null).show();
                                                break;
                                            default:
                                                uiComponents.alertDialog_DefaultNoCancel("Server is temporarily down. Please try again later", "Error", "Ok");
                                                break;
                                        }
                                    }
                                    serverResponseCode = null;
                                }
                            });
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }

                        break;
                    case R.id.action_sign_out:


                        Intent intent = new Intent(UserProfile.this, LoginActivity.class);
                        intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                        startActivity(intent);

                        break;

                    case R.id.action_delete_account:

                        //Check responseCode n update accordingly
                        requestQueue = VolleySingleton.getVolleyInstance(UserProfile.this).getRequestQueue();
                        GETDeleteUserRequest(new VolleyCallBack() {
                            @Override
                            public void OnSuccess() {

                                if (serverResponseCode != null) {
                                    switch (serverResponseCode) {
                                        case "200":
                                            Log.e("RESPONSE CODE 200: ", serverResponseCode);
                                            Snackbar.make(getWindow().getDecorView().getRootView(), "Profile successfully Removed", Snackbar.LENGTH_LONG)
                                                    .setAction("Action", null).show();

                                            Handler handler = new Handler();
                                            handler.postDelayed(new Runnable() {
                                                @Override
                                                public void run() {
                                                    Intent intent = new Intent(UserProfile.this, LoginActivity.class);
                                                    intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                                    startActivity(intent);
                                                    finish();
                                                }
                                            }, 1300);

                                            break;

                                        case "201":
                                            Snackbar.make(getWindow().getDecorView().getRootView(), "User cannot be found", Snackbar.LENGTH_LONG)
                                                    .setAction("Action", null).show();
                                            break;

                                        case "202":
                                            Snackbar.make(getWindow().getDecorView().getRootView(), "Unexpected error", Snackbar.LENGTH_LONG)
                                                    .setAction("Action", null).show();
                                            break;
                                        default:
                                            uiComponents.alertDialog_DefaultNoCancel("Server is temporarily down. Please try again later", "Error", "Ok");
                                            break;

                                    }
                                }
                                serverResponseCode = null;

                            }
                        });
                }
                return false;
            }
        });
    }


    //Update user profile call
    public void POSTEditUserRequest(final VolleyCallBack callBack) throws JSONException {

      SharedPreferences sharedPreferences = getSharedPreferences("userPref", Context.MODE_PRIVATE);
        // SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(this);
        String fName = sharedPreferences.getString("pref_FirstName", "");
        String lName = sharedPreferences.getString("pref_LastName", "");
        String email = sharedPreferences.getString("pref_Email", "");
        String gender = sharedPreferences.getString("pref_Gender", "male");
        String cellNo = sharedPreferences.getString("pref_Phone", "11111111");
        String id = sharedPreferences.getString("pref_Id", "-1");
        String userType = sharedPreferences.getString("pref_UserType", "customer");



        JSONObject jsonBody = new JSONObject();
        jsonBody.put("name", fName);
        jsonBody.put("surname", lName);
        jsonBody.put("cellNo", String.valueOf(cellNo));
        jsonBody.put("gender", gender);
        jsonBody.put("email", email);
        jsonBody.put("activeId", String.valueOf(id));
        final String mRequestBody = jsonBody.toString();

        StringRequest stringRequest = new StringRequest(Request.Method.POST, generateURL(), new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                String jsonObj = response;
                assignResponseCode(jsonObj);
                callBack.OnSuccess();

            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                VolleyLog.e("Error: ", error.getMessage());
                Log.e("Succes response", error.toString());
                serverResponseCode = null;
                callBack.OnSuccess();
            }
        }) {
            @Override
            public String getBodyContentType() {
                return "application/json; charset=utf-8";
            }

            @Override
            public byte[] getBody() throws AuthFailureError {
                return mRequestBody == null ? null : mRequestBody.getBytes(StandardCharsets.UTF_8);
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


    //Delete active user account call
    public void GETDeleteUserRequest(final VolleyCallBack callBack) {

        sharedPreferences = getSharedPreferences("userPref", Context.MODE_PRIVATE);
        // SharedPreferences userId = PreferenceManager.getDefaultSharedPreferences(this);
        String id = sharedPreferences.getString("pref_Id", "-1");

        StringRequest stringRequest = new StringRequest(Request.Method.GET, deleteUserURL(String.valueOf(id)),
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {

                        String jsonObj = response;
                        String code = assignResponseCode(jsonObj);
                        callBack.OnSuccess();
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                VolleyLog.e("Error: ", error.getMessage());
                Log.e("Succes response", error.toString());
                serverResponseCode = null;
                callBack.OnSuccess();
            }
        });

        stringRequest.setRetryPolicy(new DefaultRetryPolicy(3000, 3, DefaultRetryPolicy.DEFAULT_BACKOFF_MULT));
        requestQueue.add(stringRequest);
    }


    public void clearPreferenceAndStartActivity() {
        sharedPreferences = getSharedPreferences("userPref", Context.MODE_PRIVATE);
        String declare = "";
        SharedPreferences.Editor editor = sharedPreferences.edit();
        editor.clear().commit();
        Intent intent = new Intent(UserProfile.this, LoginActivity.class);
        int m = 0;
        startActivity(intent);
        finish();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu_user_profile, menu);
        return true;
    }

    @Override
    public String generateURL() {
        String cleanUrl = getResources().getString(R.string.WCF_URL);
        return cleanUrl + "EditUserURI";

    }

    public String deleteUserURL(String userId) {
        String cleanUrl = getResources().getString(R.string.WCF_URL);
        return cleanUrl + "DeleteUserURI/" + userId;
    }

    public String assignResponseCode(String jsonObj) {
        if (jsonObj.contains("1")) {
            //successful
            serverResponseCode = getResources().getString(R.string.response_success);
        } else if (jsonObj.contains("0")) {
            //Object not found on database
            serverResponseCode = "201";
        } else if (jsonObj.contains("-1")) {
            //Unexpected internal error
            serverResponseCode = "202";
        } else {
            serverResponseCode = getResources().getString(R.string.response_login_error);
            Log.e("Inside response", "returned null object from server login");
        }
        return serverResponseCode;
    }


    public static class ProfileFragment extends PreferenceFragmentCompat implements SharedPreferences.OnSharedPreferenceChangeListener {

        @Override
        public void onCreatePreferences(Bundle savedInstanceState, String rootKey) {
            setPreferencesFromResource(R.xml.root_preferences, rootKey);
        }

        @Override
        public void onResume() {
            super.onResume();
            //  SharedPreferences sharedPreferences2 = PreferenceManager.getDefaultSharedPreferences(getContext());
            SharedPreferences sharedPreferences = requireContext().getSharedPreferences("userPref", Context.MODE_PRIVATE);
            sharedPreferences.registerOnSharedPreferenceChangeListener(this);
          //  sharedPreferences2.registerOnSharedPreferenceChangeListener(this);


            getPreferenceScreen().getSharedPreferences()
                  .registerOnSharedPreferenceChangeListener(this);
          //  updatePreference("userPref");
            EditTextPreference txtNamePref = findPreference("pref_FirstName");
            String name = sharedPreferences.getString("pref_FirstName", "Not set");
            txtNamePref.setSummary(name);
            txtNamePref.setText(name);


            EditTextPreference txtLastNamePref = findPreference("pref_LastName");
            String lastname = sharedPreferences.getString("pref_LastName", "Not set");
            txtLastNamePref.setSummary(lastname);
            txtLastNamePref.setText(lastname);


            EditTextPreference txtEmailPref = findPreference("pref_Email");
            String email = sharedPreferences.getString("pref_Email", "Not set");
            txtEmailPref.setSummary(email);
            txtEmailPref.setText(email);

            EditTextPreference txtPhonePref = findPreference("pref_Phone");
            String phone = sharedPreferences.getString("pref_Phone", "454545");
            txtPhonePref.setSummary(String.valueOf(phone));
            txtPhonePref.setText(String.valueOf(phone));

            //DELETE ACCOUNT function
            Preference deleteAccountPref = findPreference(("pref_deleteAcc"));
            deleteAccountPref.setOnPreferenceClickListener(new Preference.OnPreferenceClickListener() {
                @Override
                public boolean onPreferenceClick(Preference preference) {

                    AlertDialog.Builder dialog = new AlertDialog.Builder(getActivity());

                    dialog.setMessage("You are about to delete your account, all data will be lost");
                    dialog.setTitle("Delete account");
                    dialog.setPositiveButton("Delete", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            //DELETE ACCOUNT
                        }
                    });
                    AlertDialog alertDialog = dialog.create();
                    alertDialog.show();
                    return false;
                }
            });


        }

        @Override
        public void onPause() {
            super.onPause();
            // Unregister the listener whenever a key changes
            getPreferenceScreen().getSharedPreferences()
                  .unregisterOnSharedPreferenceChangeListener(this);
        }

        @Override
        public void onSharedPreferenceChanged(SharedPreferences sharedPreferences, String key) {
            //Code check what preference was changed and update the container n SharedPreference
            //updatePreference(key);
          /*
            SharedPreferences.Editor editor = sharedPreferences.edit();
            Preference preference = findPreference(key);
            if (preference instanceof EditTextPreference) {
                EditTextPreference editTextPreference = (EditTextPreference) preference;
                if (editTextPreference.getText().trim().length() > 0) {
                    editTextPreference.setSummary(editTextPreference.getText());
                    editTextPreference.setText(editTextPreference.getText());
                    editor.putString(key, editTextPreference.getText());

                    editor.apply();
                } else {
                    editTextPreference.setSummary("Not set");
                }
            }
*/
        }
/*
        private void updatePreference(String key) {

            SharedPreferences sharedPreferences = requireContext().getSharedPreferences("userPref", Context.MODE_PRIVATE);
            SharedPreferences.Editor editor = sharedPreferences.edit();
            Preference preference = findPreference(key);
            if (preference instanceof EditTextPreference) {
                EditTextPreference editTextPreference = (EditTextPreference) preference;
                if (editTextPreference.getText().trim().length() > 0) {
                    editTextPreference.setSummary(editTextPreference.getText());
                    editTextPreference.setText(editTextPreference.getText());
                    editor.putString(key, editTextPreference.getText());
                    editor.apply();
                } else {
                    editTextPreference.setSummary("Not set");
                }
            }
        }
        */

    }
}