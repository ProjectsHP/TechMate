package com.example.androidclient.orders;

import android.os.Bundle;

import com.example.androidclient.databinding.ActivityLoginBinding;
import com.example.androidclient.databinding.ActivityMakeOrderBinding;
import com.example.androidclient.login.FragmentAdapter;
import com.google.android.material.color.DynamicColors;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.android.material.snackbar.Snackbar;

import androidx.appcompat.app.AppCompatActivity;

import android.view.View;

import androidx.fragment.app.Fragment;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;
import androidx.viewpager.widget.ViewPager;
import androidx.viewpager2.widget.MarginPageTransformer;
import androidx.viewpager2.widget.ViewPager2;


import com.example.androidclient.R;
import com.google.android.material.tabs.TabLayout;
import com.google.android.material.tabs.TabLayoutMediator;

import java.util.ArrayList;

public class MakeOrderActivity extends AppCompatActivity {

    private AppBarConfiguration appBarConfiguration;
    OrdersFragmentAdapter myAdapter;
    private ViewPager orderViewPager;


    public ViewPager getOrderViewPager() {
        return orderViewPager;
    }

    public void setOrderViewPager(ViewPager orderViewPager) {
        this.orderViewPager = orderViewPager;
    }

    public ActivityMakeOrderBinding getBinding() {
        return binding;
    }

    private ActivityMakeOrderBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        binding = ActivityMakeOrderBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        setSupportActionBar(binding.orderToolbar);
        orderViewPager = (ViewPager) findViewById(R.id.orders_viewPager);
        binding.ordersTabLayout.setTabGravity(TabLayout.GRAVITY_FILL);

        myAdapter = new OrdersFragmentAdapter(getSupportFragmentManager());
        binding.ordersViewPager.setAdapter(myAdapter);
        binding.ordersTabLayout.setupWithViewPager(binding.ordersViewPager);
        binding.ordersViewPager.addOnPageChangeListener(new TabLayout.TabLayoutOnPageChangeListener(binding.ordersTabLayout));

        binding.ordersViewPager.beginFakeDrag();
        binding.ordersTabLayout.setClickable(false);


    }

    @Override
    public boolean onSupportNavigateUp() {
        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment_content_make_order);
        return NavigationUI.navigateUp(navController, appBarConfiguration)
                || super.onSupportNavigateUp();
    }
}