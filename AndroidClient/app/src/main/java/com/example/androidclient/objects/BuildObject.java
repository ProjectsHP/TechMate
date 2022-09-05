package com.example.androidclient.objects;

public class BuildObject {


    String build_id;
    String user_build_id;
    String category;
    String compatibilityStatus;

    ProductObject baseCaseComponent;
    ProductObject cpuComponent;
    ProductObject storageComponent;
    ProductObject ramComponent;
    ProductObject graphicsComponent;

    public BuildObject(String build_id, String user_id,String category, String compatibility) {
        this.build_id = build_id;
        this.user_build_id = user_id;
        this.category=category;
        this.compatibilityStatus = compatibility;
    }

    public BuildObject() {
    }

    public String getBuild_id() {
        return build_id;
    }

    public void setBuild_id(String build_id) {
        this.build_id = build_id;
    }

    public String getUser_build_id() {
        return user_build_id;
    }

    public void setUser_build_id(String user_build_id) {
        this.user_build_id = user_build_id;
    }

    public String getCategory() {
        return category;
    }

    public void setCategory(String category) {
        this.category = category;
    }

    public String getCompatibilityStatus() {
        return compatibilityStatus;
    }

    public void setCompatibilityStatus(String compatibilityStatus) {
        this.compatibilityStatus = compatibilityStatus;
    }

    public ProductObject getBaseCaseComponent() {
        return baseCaseComponent;
    }

    public void setBaseCaseComponent(ProductObject baseCaseComponent) {
        this.baseCaseComponent = baseCaseComponent;
    }

    public ProductObject getCpuComponent() {
        return cpuComponent;
    }

    public void setCpuComponent(ProductObject cpuComponent) {
        this.cpuComponent = cpuComponent;
    }

    public ProductObject getStorageComponent() {
        return storageComponent;
    }

    public void setStorageComponent(ProductObject storageComponent) {
        this.storageComponent = storageComponent;
    }

    public ProductObject getRamComponent() {
        return ramComponent;
    }

    public void setRamComponent(ProductObject ramComponent) {
        this.ramComponent = ramComponent;
    }

    public ProductObject getGraphicsComponent() {
        return graphicsComponent;
    }

    public void setGraphicsComponent(ProductObject graphicsComponent) {
        this.graphicsComponent = graphicsComponent;
    }
}
