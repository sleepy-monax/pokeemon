package xyz.pokeemon.model.pet;

import android.os.Parcel;
import android.os.Parcelable;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

public class Item implements Parcelable, Serializable {

    private String name;
    private Stat stats;
    private List<Action> actions;

    public Item(String name, Stat stat) {
        this.name = name;
        this.stats = stat;
        actions = new ArrayList<>();
    }

    protected Item(Parcel in) {
        name = in.readString();
        stats = in.readParcelable(Stat.class.getClassLoader());
        actions = new ArrayList<>();
        in.readList(actions, Action.class.getClassLoader());
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

    public Stat getStats() {
        return stats;
    }

    public void setStats(Stat stats) {
        this.stats = stats;
    }

    public List<Action> getActions() {
        return actions;
    }

    public void setActions(List<Action> actions) {
        this.actions = actions;
    }

    @Override
    public String toString() {
        return "Pet{" +
                "name='" + name + '\'' +
                ", stat=" + stats +
                ", actions=" + actions +
                '}';
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel parcel, int i) {
        parcel.writeString(name);
        parcel.writeParcelable(stats, i);
        parcel.writeList(actions);
    }
}
