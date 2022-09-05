package com.example.androidclient.objects;

public class CategoryObject {

    private String title;
    private int image;

    public CategoryObject(int image, String title) {
        this.image = image;
        this.title = title;
    }





    public int getImage() {
        return image;
    }

    public void setImage(int image) {
        this.image = image;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }
}
