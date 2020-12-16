package xyz.pokeemon.model.shop;

import android.os.Parcel;
import android.os.Parcelable;

import java.io.Serializable;

import xyz.pokeemon.model.pet.Stat;

public class Item implements Parcelable, Serializable {

    private String name, description;
    private int price;

    private Effect effect;

    public Item(String name, String description, int price, Effect effect) {
        this.name = name;
        this.description = description;
        this.price = price;
        this.effect=effect;
    }

    protected Item(Parcel in) {
        name = in.readString();
        description = in.readString();
        price = in.readInt();
        effect = in.readParcelable(Effect.class.getClassLoader());
    }

    public static final Creator<Item> CREATOR = new Creator<Item>() {
        @Override
        public Item createFromParcel(Parcel in) {
            return new Item(in);
        }

        @Override
        public Item[] newArray(int size) {
            return new Item[size];
        }
    };

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public int getPrice() {
        return price;
    }

    public void setPrice(int price) {
        this.price = price;
    }

    public Effect getEffect() {
        return effect;
    }

    public void setEffect(Effect effect) {
        this.effect = effect;
    }

    @Override
    public String toString() {
        return "name='" + name + '\'' +
                ", description='" + description + '\'' +
                ", price=" + price;
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel parcel, int i) {
        parcel.writeString(name);
        parcel.writeString(description);
        parcel.writeInt(price);
        parcel.writeParcelable(effect, i);
    }
}
