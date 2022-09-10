package com.example.androidclient.adapters;

import android.app.Activity;
import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.ToggleButton;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.androidclient.MainActivity;
import com.example.androidclient.R;
import com.example.androidclient.objects.BuildObject;
import com.example.androidclient.objects.ProductObject;
import com.example.androidclient.ui.IRecyclerViewClickHandler;

import java.util.ArrayList;

public class BuildCartAdapter extends RecyclerView.Adapter<BuildCartAdapter.ViewHolder>{

    private final ArrayList<BuildObject> localDataSet;
    private ArrayList<BuildObject> buildList;
    private final IRecyclerViewClickHandler recyclerViewClickHandler;
//    private ArrayList<ProductObject> cartProductList;
    ArrayList<ProductObject> persistantCartlist;


    /**
     * Provide a reference to the type of views that you are using
     * (custom ViewHolder).
     */
    public static class ViewHolder extends RecyclerView.ViewHolder {
        private final TextView txtName;
        private final TextView txtPrice;
        private final TextView txtBuildNumber;
        private final ToggleButton tglAddCart;

        View tglAddCartView;

        public ViewHolder(View view, IRecyclerViewClickHandler recyclerViewClickHandler) {
            super(view);
            // Define click listener for the ViewHolder's View



            view.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    if(recyclerViewClickHandler!=null){
                        int pos = getBindingAdapterPosition();

                        if(pos!= RecyclerView.NO_POSITION){
                            recyclerViewClickHandler.onItemClick(pos);
                        }

                    }
                }
            });

            txtName = (TextView) view.findViewById(R.id.build_item_name);
            txtPrice = (TextView) view.findViewById(R.id.build_item_price);
            txtBuildNumber = (TextView) view.findViewById(R.id.build_item_number);
            tglAddCart = (ToggleButton) view.findViewById(R.id.toggleAddBuildToCart);

        }


        public TextView getTextNameView() {
            return txtName;
        }

        public TextView getTextPriceView() {
            return txtPrice;
        }

        public TextView getTextNumberView() {
            return txtBuildNumber;
        }

    }

    public BuildCartAdapter(ArrayList<BuildObject> dataSet,  IRecyclerViewClickHandler clickHandler) {
        this.recyclerViewClickHandler=clickHandler;
        this.localDataSet = dataSet;


    }

    // Create new views (invoked by the layout manager)
    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(ViewGroup viewGroup, int viewType) {
        // Create a new view, which defines the UI of the list item
        View view = LayoutInflater.from(viewGroup.getContext())
                .inflate(R.layout.recycler_build_item, viewGroup, false);

        return new ViewHolder(view,recyclerViewClickHandler);
    }


    // Replace the contents of a view (invoked by the layout manager)
    @Override
    public void onBindViewHolder(ViewHolder viewHolder, final int position) {

        int pos=viewHolder.getBindingAdapterPosition();
        viewHolder.getTextNameView().setText((CharSequence) localDataSet.get(position).getBaseCaseComponent().getName());
        viewHolder.getTextPriceView().setText("R"+ localDataSet.get(position).getTotalPrice());
        viewHolder.getTextNumberView().setText("Build "+(position+1));

        viewHolder.tglAddCart.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                BuildObject build;
                int totPrice=0;
                build=localDataSet.get(viewHolder.getBindingAdapterPosition());

                if(viewHolder.tglAddCart.isChecked()){

                   build.getStorageComponent().setBuild_id(build.getBuild_id());
                   build.getRamComponent().setBuild_id(build.getBuild_id());
                   build.getGraphicsComponent().setBuild_id(build.getBuild_id());
                   build.getCpuComponent().setBuild_id(build.getBuild_id());
                   build.getBaseCaseComponent().setBuild_id(build.getBuild_id());

                    ((MainActivity) v.getContext()).getPersistantCartlist().add(build.getStorageComponent());
                    ((MainActivity) v.getContext()).getPersistantCartlist().add(build.getRamComponent());
                    ((MainActivity) v.getContext()).getPersistantCartlist().add(build.getGraphicsComponent());
                    ((MainActivity) v.getContext()).getPersistantCartlist().add(build.getCpuComponent());
                    ((MainActivity) v.getContext()).getPersistantCartlist().add(build.getBaseCaseComponent());


                }else
                {
                    ((MainActivity) v.getContext()).getPersistantCartlist().removeIf(product ->
                            product.getBuild_id() == build.getBuild_id() );

                }


                persistantCartlist= ((MainActivity) v.getContext()).getPersistantCartlist();
                for (ProductObject product:persistantCartlist) {
                    totPrice+=product.getIntPrice();
                }
                ((MainActivity) v.getContext()).setDynamicTotalPriceCart(totPrice);
                ((MainActivity)v.getContext()).getCartAdapter().notifyDataSetChanged();
            }
        });

    }


    // Return the size of your dataset (invoked by the layout manager)
    @Override
    public int getItemCount() {
        return localDataSet.size();
    }



}
