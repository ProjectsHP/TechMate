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

public class ItemListAdapter extends RecyclerView.Adapter<ItemListAdapter.ViewHolder>{

    private final ArrayList<ProductObject> localDataSet;
    private final IRecyclerViewClickHandler recyclerViewClickHandler;


    /**
     * Provide a reference to the type of views that you are using
     * (custom ViewHolder).
     */
    public static class ViewHolder extends RecyclerView.ViewHolder {
        private final TextView textView;

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
            textView = (TextView) view.findViewById(R.id.lblListItemProductName);
        }

        public TextView getTextView() {
            return textView;
        }
    }


    public ItemListAdapter(ArrayList<ProductObject> dataSet,  IRecyclerViewClickHandler clickHandler) {
        this.recyclerViewClickHandler=clickHandler;
        this.localDataSet = dataSet;
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
        viewHolder.getTextView().setText((CharSequence) localDataSet.get(position));
    }

    @Override
    public int getItemCount() { return localDataSet.size(); }
}
