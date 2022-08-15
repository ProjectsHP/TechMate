package com.example.androidclient;

import android.content.Context;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.Toast;

import com.example.androidclient.adapters.CategoryAdapter;
import com.example.androidclient.adapters.ProductsAdapter;
import com.example.androidclient.databinding.FragmentCategoryBinding;
import com.example.androidclient.ui.IRecyclerViewClickHandler;

import java.util.ArrayList;


public class CategoryFragment extends Fragment implements IRecyclerViewClickHandler {


    private FragmentCategoryBinding binding;
    private ImageView toolbarLogo;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentCategoryBinding.inflate(inflater, container, false);
        return binding.getRoot();

    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);


        toolbarLogo = getActivity().findViewById(R.id.toolbarLogo);
        toolbarLogo.setVisibility(View.GONE);



        ArrayList<Integer> iconsList = new ArrayList<>();
        iconsList.add(R.drawable.desktop_icon);
        iconsList.add(R.drawable.laptop_icon);
        iconsList.add(R.drawable.cpu_icon);
        iconsList.add(R.drawable.gpu_icon);
        iconsList.add(R.drawable.ram_icon);
        iconsList.add(R.drawable.harddisk_icon);


        ArrayList<String> list = new ArrayList<>();
        list.add("Desktops");
        list.add("Laptops");
        list.add("Processors");
        list.add("Graphic cards");
        list.add("Computer memory");
        list.add("Disk storage");
        CategoryAdapter adapter = new CategoryAdapter(iconsList,list, this);
        LinearLayoutManager linearLayoutManager=new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.VERTICAL,false);
        binding.recyclerCategory.setLayoutManager(linearLayoutManager);
        binding.recyclerCategory.setAdapter(adapter);

    }

   /* @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }*/






    @Override
    public void onItemClick(int position) {
        Toast.makeText(getActivity(),"Check if works nice",Toast.LENGTH_LONG).show();
    }
}