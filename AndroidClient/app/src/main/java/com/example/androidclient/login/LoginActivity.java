package com.example.androidclient.login;

import android.os.Bundle;

import com.android.volley.RequestQueue;
import com.android.volley.toolbox.Volley;
import com.example.androidclient.R;
import com.example.androidclient.network.VolleySingleton;
import com.google.android.material.color.DynamicColors;
import com.google.android.material.snackbar.Snackbar;

import androidx.appcompat.app.AppCompatActivity;

import android.view.View;
import android.widget.TextView;

import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;
import androidx.viewpager.widget.ViewPager;

import com.example.androidclient.databinding.ActivityLoginBinding;
import com.google.android.material.tabs.TabLayout;

import java.util.Objects;

public class LoginActivity extends AppCompatActivity {

    private AppBarConfiguration appBarConfiguration;
    public ActivityLoginBinding binding;
    float v=0;
    ConstraintLayout mLoginCOnstraintLayout;
    TabLayout mTabLayout;
    ViewPager mViewPager;




    public ActivityLoginBinding getBinding() {
        return binding;
    }



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        DynamicColors.applyToActivitiesIfAvailable(getApplication());
        binding = ActivityLoginBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());



        binding.tabLayout.addTab(binding.tabLayout.newTab().setText("Login"));
        binding.tabLayout.addTab(binding.tabLayout.newTab().setText("Sign Up"));
        binding.tabLayout.setTabGravity(TabLayout.GRAVITY_FILL);

        final FragmentAdapter fragmentAdapterLogin = new FragmentAdapter(getSupportFragmentManager()
                ,this,binding.tabLayout.getTabCount());
        binding.viewPager.setAdapter(fragmentAdapterLogin);

        binding.viewPager.addOnPageChangeListener(new TabLayout.TabLayoutOnPageChangeListener(binding.tabLayout));

      animateView();


    }

    @Override
    public boolean onSupportNavigateUp() {
        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment_content_login);
        return NavigationUI.navigateUp(navController, appBarConfiguration)
                || super.onSupportNavigateUp();
    }

    private void animateView(){
        binding.fabFacebook.setTranslationY(300);
        binding.fabGoogle.setTranslationY(300);
        binding.fabTwitter.setTranslationY(300);
        binding.tabLayout.setTranslationY(300);


        binding.fabFacebook.setAlpha(v);
        binding.fabTwitter.setAlpha(v);
        binding.fabGoogle.setAlpha(v);
        binding.tabLayout.setAlpha(v);


        binding.fabFacebook.animate().translationY(0).alpha(1).setDuration(1000).setStartDelay(400).start();
        binding.fabGoogle.animate().translationY(0).alpha(1).setDuration(1000).setStartDelay(600).start();
        binding.fabTwitter.animate().translationY(0).alpha(1).setDuration(1000).setStartDelay(800).start();
        binding.tabLayout.animate().translationY(0).alpha(1).setDuration(1000).setStartDelay(100).start();
        mLoginCOnstraintLayout = (ConstraintLayout) findViewById(R.id.layout_activityLogin);
        mTabLayout = (TabLayout) findViewById(R.id.tabLayout);
        mViewPager = (ViewPager) findViewById(R.id.viewPager);

    }


}