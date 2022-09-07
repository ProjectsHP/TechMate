package com.example.androidclient.objects;

import android.os.Parcel;
import android.os.Parcelable;

public class BuildObject implements Parcelable{


    String Build_id;
    String User_build_id;
    String Category;
    String CompatibilityStatus;
    String totalPrice;
    int intTotalPrice;

    ProductObject BaseCaseComponent;
    ProductObject CpuComponent;
    ProductObject StorageComponent;
    ProductObject RamComponent;
    ProductObject GraphicsComponent;


    public BuildObject() {

    }


    protected BuildObject(Parcel in) {
        Build_id = in.readString();
        User_build_id = in.readString();
        Category = in.readString();
        CompatibilityStatus = in.readString();
        BaseCaseComponent = in.readParcelable(ProductObject.class.getClassLoader());
        CpuComponent = in.readParcelable(ProductObject.class.getClassLoader());
        StorageComponent = in.readParcelable(ProductObject.class.getClassLoader());
        RamComponent = in.readParcelable(ProductObject.class.getClassLoader());
        GraphicsComponent = in.readParcelable(ProductObject.class.getClassLoader());
    }

    public static final Creator<BuildObject> CREATOR = new Creator<BuildObject>() {
        @Override
        public BuildObject createFromParcel(Parcel in) {
            return new BuildObject(in);
        }

        @Override
        public BuildObject[] newArray(int size) {
            return new BuildObject[size];
        }
    };

    public String getBuild_id() {
        return Build_id;
    }

    public void setBuild_id(String build_id) {
        Build_id = build_id;
    }

    public String getUser_build_id() {
        return User_build_id;
    }

    public void setUser_build_id(String user_build_id) {
        User_build_id = user_build_id;
    }

    public String getCategory() {
        return Category;
    }

    public void setCategory(String category) {
        Category = category;
    }

    public String getCompatibilityStatus() {
        return CompatibilityStatus;
    }

    public void setCompatibilityStatus(String compatibilityStatus) {
        CompatibilityStatus = compatibilityStatus;
    }

    public ProductObject getBaseCaseComponent() {
        return BaseCaseComponent;
    }

    public void setBaseCaseComponent(ProductObject baseCaseComponent) {
        BaseCaseComponent = baseCaseComponent;
    }

    public ProductObject getCpuComponent() {
        return CpuComponent;
    }

    public void setCpuComponent(ProductObject cpuComponent) {
        CpuComponent = cpuComponent;
    }

    public ProductObject getStorageComponent() {
        return StorageComponent;
    }

    public void setStorageComponent(ProductObject storageComponent) {
        StorageComponent = storageComponent;
    }

    public ProductObject getRamComponent() {
        return RamComponent;
    }

    public void setRamComponent(ProductObject ramComponent) {
        RamComponent = ramComponent;
    }

    public ProductObject getGraphicsComponent() {
        return GraphicsComponent;
    }

    public void setGraphicsComponent(ProductObject graphicsComponent) {
        GraphicsComponent = graphicsComponent;
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(Build_id);
        dest.writeString(User_build_id);
        dest.writeString(Category);
        dest.writeString(CompatibilityStatus);
        dest.writeParcelable(BaseCaseComponent, flags);
        dest.writeParcelable(CpuComponent, flags);
        dest.writeParcelable(StorageComponent, flags);
        dest.writeParcelable(RamComponent, flags);
        dest.writeParcelable(GraphicsComponent, flags);
    }

    public int getTotalBuildPrice(){
        int total;
        String desktop = getBaseCaseComponent().getPrice();
        String cpu = getCpuComponent().getPrice();
        String storage = getStorageComponent().getPrice();
        String ram = getRamComponent().getPrice();
        String graphics = getGraphicsComponent().getPrice();

       desktop= desktop.replaceAll(" ","");
       cpu= cpu.replaceAll(" ","");
        storage=storage.replaceAll(" ","");
        ram=ram.replaceAll(" ","");
        graphics=graphics.replaceAll(" ","");

       int deskPrice = Integer.parseInt(desktop);
       int cpuPrice = Integer.parseInt(cpu);
       int storPrice =  Integer.parseInt(storage);
       int ramPrice = Integer.parseInt(ram);
       int graPrice = Integer.parseInt(graphics);
       this.intTotalPrice=deskPrice+cpuPrice+storPrice+ramPrice+graPrice;

        return intTotalPrice;

    }
}
