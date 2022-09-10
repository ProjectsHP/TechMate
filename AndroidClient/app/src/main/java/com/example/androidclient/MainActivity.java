package com.example.androidclient;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;

import com.example.androidclient.adapters.CartAdapter;
import com.example.androidclient.databinding.ActivityMainBinding;
import com.example.androidclient.objects.BuildObject;
import com.example.androidclient.objects.ProductObject;
import com.google.android.material.appbar.AppBarLayout;
import com.google.android.material.appbar.MaterialToolbar;
import com.google.android.material.color.DynamicColors;
import com.google.android.material.navigation.NavigationView;

import androidx.appcompat.app.AppCompatActivity;

import android.view.View;

import androidx.drawerlayout.widget.DrawerLayout;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;

import android.view.Menu;
import android.widget.ImageView;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    private AppBarConfiguration appBarConfiguration;
    private ActivityMainBinding binding;
    private AppBarLayout appBarLayout;
    private MaterialToolbar materialToolbar;
    ImageView toolbarLogo;
    ArrayList<ProductObject> persistantCartlist;
    CartAdapter cartAdapter;
    int dynamicTotalPriceCart;
    SharedPreferences userSharedPreferences;

    public CartAdapter getCartAdapter() {
        return cartAdapter;
    }

    public void setCartAdapter(CartAdapter cartAdapter) {
        this.cartAdapter = cartAdapter;
    }

    public int getDynamicTotalPriceCart() {
        return dynamicTotalPriceCart;
    }

    public void setDynamicTotalPriceCart(int dynamicTotalPriceCart) {
        this.dynamicTotalPriceCart = dynamicTotalPriceCart;
    }

    public ArrayList<ProductObject> getPersistantCartlist() {
        return persistantCartlist;
    }

    public void setPersistantCartlist(ArrayList<ProductObject> persistantCartlist) {
        this.persistantCartlist = persistantCartlist;
    }





    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        binding = ActivityMainBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());
        DynamicColors.applyToActivitiesIfAvailable(getApplication());
        setSupportActionBar(binding.mainBarDrawer.mainToolbar);

        DrawerLayout drawer = binding.drawerLayout;
        NavigationView navigationView = binding.navView;
        persistantCartlist = new ArrayList<>();
        userSharedPreferences = getSharedPreferences("userPref", Context.MODE_PRIVATE);
        String userType=userSharedPreferences.getString("pref_UserType","Customer");
        navigationView.getMenu().clear();
        switch (userType){
            case "Admin":
                navigationView.inflateMenu(R.menu.admin_menu);
                break;
            case "Manager":
                navigationView.inflateMenu(R.menu.manager_menu);
                break;
            case "Clerk":
                navigationView.inflateMenu(R.menu.clerk_menu);
                break;
            default:
                navigationView.inflateMenu(R.menu.customer_menu);
        }


        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment_content_main);
        appBarConfiguration = new AppBarConfiguration.Builder(navController.getGraph()).setOpenableLayout(drawer).build();

        NavigationUI.setupActionBarWithNavController(this, navController, appBarConfiguration);
        NavigationUI.setupWithNavController(binding.mainBarDrawer.bottomNavView, navController);
        NavigationUI.setupWithNavController(navigationView, navController);

        getWindow().setNavigationBarColor(getResources().getColor(R.color.white));
        appBarLayout = (AppBarLayout) findViewById(R.id.itemAppBarLayout);
        materialToolbar = (MaterialToolbar) findViewById(R.id.mainToolbar);          //for access on other fragments
        getSupportActionBar().setDisplayShowTitleEnabled(false);

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.toolbar_menu, menu);
        return true;
    }

    /*
    @Override
    public void onBackPressed(){
        Intent exitIntent = new Intent(Intent.ACTION_MAIN);
        exitIntent.addCategory(Intent.CATEGORY_HOME);
        exitIntent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK) ;
        startActivity(exitIntent);
    }*/

   /*
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
*/
    @Override
    public boolean onSupportNavigateUp() {
        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment_content_main);
        return NavigationUI.navigateUp(navController, appBarConfiguration)
                || super.onSupportNavigateUp();
    }

}