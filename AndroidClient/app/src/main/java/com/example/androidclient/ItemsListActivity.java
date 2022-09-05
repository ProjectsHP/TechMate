package com.example.androidclient;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.FragmentTransaction;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.fragment.NavHostFragment;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;


import android.app.FragmentManager;
import android.content.Intent;
import android.os.Bundle;

import com.example.androidclient.adapters.ItemListAdapter;
import com.example.androidclient.databinding.ActivityItemsListBinding;
import com.example.androidclient.databinding.ActivityMainBinding;
import com.example.androidclient.ui.IRecyclerViewClickHandler;
import com.google.android.material.appbar.AppBarLayout;
import com.google.android.material.appbar.MaterialToolbar;
import com.google.android.material.color.DynamicColors;

import java.util.ArrayList;

public class ItemsListActivity extends AppCompatActivity implements IRecyclerViewClickHandler {

    private AppBarConfiguration appBarConfiguration;
    private AppBarLayout appBarLayout;
    private RecyclerView recyclerListItems;
    private MaterialToolbar materialToolbar;
    private ActivityItemsListBinding binding;

    public String getSelectedCategory() {
        return selectedCategory;
    }

    private String selectedCategory;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Bundle b = getIntent().getExtras();

        if(b != null){
            selectedCategory = b.getString("selectedCategory");
        }



        binding = ActivityItemsListBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());
        DynamicColors.applyToActivitiesIfAvailable(getApplication());
        setSupportActionBar(binding.itemToolbar1);
        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment_content_item_list);
        appBarConfiguration = new AppBarConfiguration.Builder(navController.getGraph()).build();
        NavigationUI.setupActionBarWithNavController(this, navController, appBarConfiguration);
        getSupportActionBar().setDisplayShowTitleEnabled(true);

        if(selectedCategory!=null){
            getSupportActionBar().setTitle(selectedCategory);
        }else{
            getSupportActionBar().setTitle("Items");
        }
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        getSupportActionBar().setDisplayShowHomeEnabled(true);


    }

    @Override
    public boolean onSupportNavigateUp() {
        onBackPressed();
        return true;
    }

    @Override
    public void onItemClick(int position) {

     //   Intent intent = new Intent(this, ProductDetailsFragment.class);
       // startActivity(intent);


    }
}