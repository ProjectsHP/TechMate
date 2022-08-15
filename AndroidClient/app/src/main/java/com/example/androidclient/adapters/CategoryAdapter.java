package com.example.androidclient.adapters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.androidclient.R;
import com.example.androidclient.ui.IRecyclerViewClickHandler;

import java.util.ArrayList;


public class CategoryAdapter extends RecyclerView.Adapter<CategoryAdapter.ViewHolder> {

    private ArrayList<String> labelDataSet;
    private ArrayList<Integer> iconsDataSet;
    private final IRecyclerViewClickHandler recyclerViewClickHandler;



    public static class ViewHolder extends RecyclerView.ViewHolder {
        private final TextView textView;
        private  ImageView iconImage;


        public ViewHolder(View view, IRecyclerViewClickHandler recyclerViewClickHandler) {
            super(view);

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
            textView = (TextView) view.findViewById(R.id.lblCategoryName);
            iconImage = (ImageView) view.findViewById(R.id.imgCategoryIcon);
        }

        public TextView getTextView() {
            return textView;
        }

        public ImageView getImageView() {
            return iconImage;
        }



    }

    public CategoryAdapter(ArrayList<Integer> icons, ArrayList<String> labels, IRecyclerViewClickHandler clickHandler) {
        this.iconsDataSet = icons;
        this.labelDataSet = labels;
        this.recyclerViewClickHandler  = clickHandler;
    }


    @Override
    public CategoryAdapter.ViewHolder onCreateViewHolder(ViewGroup viewGroup, int viewType) {
        // Create a new view, which defines the UI of the list item
        View view = LayoutInflater.from(viewGroup.getContext())
                .inflate(R.layout.recycler_category_item, viewGroup, false);

        return new CategoryAdapter.ViewHolder(view, recyclerViewClickHandler);
    }

    // Replace the contents of a view (invoked by the layout manager)
    @Override
    public void onBindViewHolder(CategoryAdapter.ViewHolder viewHolder, final int position) {

        // Get element from your dataset at this position and replace the
        // contents of the view with that element
        viewHolder.getTextView().setText((CharSequence) labelDataSet.get(position));
        viewHolder.getImageView().setImageResource((Integer) iconsDataSet.get(position));

    }

    // Return the size of your dataset (invoked by the layout manager)
    @Override
    public int getItemCount() {
        return labelDataSet.size();
    }



}