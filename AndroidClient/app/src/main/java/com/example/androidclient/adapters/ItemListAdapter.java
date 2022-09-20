package com.example.androidclient.adapters;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.androidclient.R;
import com.example.androidclient.objects.ProductObject;
import com.example.androidclient.ui.IRecyclerViewClickHandler;

import java.util.ArrayList;

public class ItemListAdapter extends RecyclerView.Adapter<ItemListAdapter.ViewHolder>{

    private final ArrayList<ProductObject> localDataSet;
    private final IRecyclerViewClickHandler recyclerViewClickHandler;
    Context mContext;


    /**
     * Provide a reference to the type of views that you are using
     * (custom ViewHolder).
     */
    public static class ViewHolder extends RecyclerView.ViewHolder {
        private final TextView textView;
        private final TextView txtPrice;
        private final ImageView imgProduct;

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

            imgProduct = (ImageView) view.findViewById(R.id.product_item_list_img);
            textView = (TextView) view.findViewById(R.id.build_item_name);
            txtPrice = (TextView) view.findViewById(R.id.build_item_price);
        }

        public TextView getTextView() {
            return textView;
        }
        public TextView getPriceView() {
            return txtPrice;
        }
        public ImageView getImageView() {
            return imgProduct;
        }


    }


    public ItemListAdapter(ArrayList<ProductObject> dataSet,Context context , IRecyclerViewClickHandler clickHandler) {
        this.recyclerViewClickHandler=clickHandler;
        this.localDataSet = dataSet;
        this.mContext=context;
    }



    // Create new views (invoked by the layout manager)
    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(ViewGroup viewGroup, int viewType) {
        // Create a new view, which defines the UI of the list item
        View view = LayoutInflater.from(viewGroup.getContext())
                .inflate(R.layout.recycler_list_items, viewGroup, false);

        return new ViewHolder(view,recyclerViewClickHandler);
    }


    // Replace the contents of a view (invoked by the layout manager)
    @Override
    public void onBindViewHolder(ViewHolder viewHolder, final int position) {

        // Get element from your dataset at this position and replace the
        // contents of the view with that element

        String imageName = localDataSet.get(position).getImage();
        String result = imageName.substring(0, imageName.indexOf("."));
        int drawableId = mContext.getResources().getIdentifier(result, "drawable", mContext.getPackageName());
        viewHolder.getImageView().setImageResource(drawableId);
        viewHolder.getTextView().setText( localDataSet.get(position).getName());
        viewHolder.getPriceView().setText("R" + localDataSet.get(position).getPrice());
    }

    @Override
    public int getItemCount() { return localDataSet.size(); }
}
