package com.example.androidclient.adapters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.androidclient.R;
import com.example.androidclient.objects.ProductObject;
import com.example.androidclient.ui.IRecyclerViewClickHandler;

import java.util.ArrayList;

public class CartAdapter extends RecyclerView.Adapter<CartAdapter.ViewHolder>{

    private final ArrayList<ProductObject> localDataSet;
    private final IRecyclerViewClickHandler recyclerViewClickHandler;


    public static class ViewHolder extends RecyclerView.ViewHolder {
        private final TextView txtName;
        private final TextView txtCategory;
        private final TextView txtPrice;

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
            txtName = (TextView) view.findViewById(R.id.cartNameItem);
            txtCategory = (TextView) view.findViewById(R.id.cartCategoryItem);
            txtPrice = (TextView) view.findViewById(R.id.cartPriceItem);
        }

        public TextView getNameView() {
            return txtName;
        }

        public TextView getPriceView() {
            return txtPrice;
        }

        public TextView getCategoryView() {
            return txtCategory;
        }
    }

    public CartAdapter(ArrayList<ProductObject> dataSet,  IRecyclerViewClickHandler clickHandler) {
        this.recyclerViewClickHandler=clickHandler;
        this.localDataSet = dataSet;
    }

    // Create new views (invoked by the layout manager)
    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(ViewGroup viewGroup, int viewType) {
        // Create a new view, which defines the UI of the list item
        View view = LayoutInflater.from(viewGroup.getContext())
                .inflate(R.layout.recycler_cart_item, viewGroup, false);

        return new CartAdapter.ViewHolder(view,recyclerViewClickHandler);
    }


    @Override
    public void onBindViewHolder(ViewHolder viewHolder, final int position) {

        // Get element from your dataset at this position and replace the
        // contents of the view with that element
        viewHolder.getNameView().setText((CharSequence) localDataSet.get(position).getName());
        viewHolder.getCategoryView().setText((CharSequence) localDataSet.get(position).getCategory());
        viewHolder.getPriceView().setText("R"+ localDataSet.get(position).getPrice());

    }


    @Override
    public int getItemCount() { return localDataSet.size(); }
}
