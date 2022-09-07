package com.example.androidclient;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.androidclient.adapters.BuildCartAdapter;
import com.example.androidclient.adapters.CartAdapter;
import com.example.androidclient.databinding.FragmentCartBinding;
import com.example.androidclient.databinding.FragmentDisplayBuildBinding;
import com.example.androidclient.network.VolleyCallBack;
import com.example.androidclient.network.VolleySingleton;
import com.example.androidclient.objects.BuildObject;
import com.example.androidclient.objects.ProductObject;
import com.example.androidclient.ui.IRecyclerViewClickHandler;
import com.example.androidclient.ui.UIComponents;

import java.util.ArrayList;
import java.util.Arrays;


public class DisplayBuildFragment extends Fragment implements IRecyclerViewClickHandler {


    private FragmentDisplayBuildBinding binding;
    BuildObject[] buildObject =null;
    ArrayList<BuildObject> list = new ArrayList<>();
    ProductObject selectedBuild  = new ProductObject();
    UIComponents uiComponents;
    BuildObject build;


    public DisplayBuildFragment() {
        // Required empty public constructor
    }



    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        binding = FragmentDisplayBuildBinding.inflate(inflater, container, false);
        return binding.getRoot();
    }


    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        NavController navController = Navigation.findNavController(getActivity(), R.id.nav_host_fragment_content_main);
       // ((MainActivity) getActivity()).getSupportActionBar().setDisplayHomeAsUpEnabled(false);
        //((MainActivity) getActivity()).getSupportActionBar().setDisplayShowHomeEnabled(false);

        uiComponents = new UIComponents(getActivity());
        Bundle bundle = this.getArguments();
        if (bundle != null) {
            build = bundle.getParcelable("selectedBuild");
        }

        ArrayList<ProductObject> list = new ArrayList<>();
        list.add(build.getBaseCaseComponent());
        list.add(build.getRamComponent());
        list.add(build.getStorageComponent());
        list.add(build.getCpuComponent());
        list.add(build.getGraphicsComponent());


        CartAdapter adapter = new CartAdapter(list,this);
        LinearLayoutManager linearLayoutManager=new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.VERTICAL,false);
        binding.recyclerShowBuild.setLayoutManager(linearLayoutManager);
        binding.recyclerShowBuild.setAdapter(adapter);


    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

    @Override
    public void onItemClick(int position) {

    }
}