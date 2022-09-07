package com.example.androidclient.adapters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.ToggleButton;

import androidx.recyclerview.widget.RecyclerView;

import com.example.androidclient.R;
import com.example.androidclient.objects.BuildObject;
import com.example.androidclient.ui.IRecyclerViewClickHandler;

import java.util.ArrayList;

public class BuildCartAdapter extends RecyclerView.Adapter<BuildCartAdapter.ViewHolder>{

    private final ArrayList<BuildObject> localDataSet;
    private ArrayList<BuildObject> buildList;
    private final IRecyclerViewClickHandler recyclerViewClickHandler;

    /**
     * Provide a reference to the type of views that you are using
     * (custom ViewHolder).
     */
    public static class ViewHolder extends RecyclerView.ViewHolder {
        private final TextView txtName;
        private final TextView txtPrice;
        private final TextView txtBuildNumber;
        private final ToggleButton tglAddCart;

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

        // Get element from your dataset at this position and replace the
        // contents of the view with that element


        int total = localDataSet.get(position).getTotalBuildPrice();
        viewHolder.getTextNameView().setText((CharSequence) localDataSet.get(position).getBaseCaseComponent().getName());
        viewHolder.getTextPriceView().setText("R"+ total);
        viewHolder.getTextNumberView().setText("Build "+(position+1));

//        viewHolder.tglAddCart.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                if(viewHolder.tglAddCart.isChecked()){
//                    buildList.add(localDataSet.get(viewHolder.getBindingAdapterPosition()));
//                }else{
//                    buildList.remove(localDataSet.get(viewHolder.getBindingAdapterPosition()));
//                }
//            }
//        });


    }

    // Return the size of your dataset (invoked by the layout manager)
    @Override
    public int getItemCount() {
        return localDataSet.size();
    }

}
