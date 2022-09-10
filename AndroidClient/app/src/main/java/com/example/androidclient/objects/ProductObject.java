package com.example.androidclient.objects;

import android.os.Parcel;
import android.os.Parcelable;

public class ProductObject implements Parcelable {

    private int Id;
    private String name;
    private String price;
    private String availability;
    private String description;
    private String image;
    private String compability;
    private String build_id;
    private String category;
    private int intPriceFormat;





    public ProductObject(){}

    public ProductObject(int id, String name, String price, String availability, String description, String image, String compability, String build_id, String category, int intPrice) {
        Id = id;
        this.name = name;
        this.price = price;
        this.availability = availability;
        this.description = description;
        this.image = image;
        this.compability = compability;
        this.build_id = build_id;
        this.category = category;
        this.intPriceFormat = intPrice;
    }


    protected ProductObject(Parcel in) {
        Id = in.readInt();
        name = in.readString();
        price = in.readString();
        availability = in.readString();
        description = in.readString();
        image = in.readString();
        compability = in.readString();
        build_id = in.readString();
        category = in.readString();
        intPriceFormat = in.readInt();
    }

    public static final Creator<ProductObject> CREATOR = new Creator<ProductObject>() {
        @Override
        public ProductObject createFromParcel(Parcel in) {
            return new ProductObject(in);
        }

        @Override
        public ProductObject[] newArray(int size) {
            return new ProductObject[size];
        }
    };

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPrice() {
        return price;
    }

    public void setPrice(String price) {
        this.price = price;
    }

    public int getIntPrice() {
        return intPriceFormat;
    }

    public void setIntPrice(int intPrice) {
        this.intPriceFormat = intPrice;
    }

    public String getAvailability() {
        return availability;
    }

    public void setAvailability(String availability) {
        this.availability = availability;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }

    public String getCompability() {
        return compability;
    }

    public void setCompability(String compability) {
        this.compability = compability;
    }

    public String getBuild_id() {
        return build_id;
    }

    public void setBuild_id(String build_id) {
        this.build_id = build_id;
    }

    public String getCategory() {
        return category;
    }

    public void setCategory(String category) {
        this.category = category;
    }


    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(Id);
        dest.writeString(name);
        dest.writeString(price);
        dest.writeString(availability);
        dest.writeString(description);
        dest.writeString(image);
        dest.writeString(compability);
        dest.writeString(build_id);
        dest.writeString(category);
        dest.writeInt(intPriceFormat);
    }
}
