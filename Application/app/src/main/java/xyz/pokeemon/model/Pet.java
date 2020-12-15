package xyz.pokeemon.model;

import android.os.Parcel;
import android.os.Parcelable;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

public class Pet implements Parcelable, Serializable {

    private String name;
    private String type;
    private Stat stats;
    private List<Action> actions;

    public Pet(String name, String type, Stat stat) {
        this.name = name;
        this.type = type;
        this.stats = stat;
        actions = new ArrayList<>();
    }

    protected Pet(Parcel in) {
        name = in.readString();
        type = in.readString();
        stats = in.readParcelable(Stat.class.getClassLoader());
        actions = new ArrayList<>();
        in.readList(actions, Action.class.getClassLoader());
    }

    public static final Creator<Pet> CREATOR = new Creator<Pet>() {
        @Override
        public Pet createFromParcel(Parcel in) {
            return new Pet(in);
        }

        @Override
        public Pet[] newArray(int size) {
            return new Pet[size];
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


    @Override
    public String toString() {
        return "Pet{" +
                "name='" + name + '\'' +
                ", type='" + type + '\'' +
                ", stat=" + stats +
                ", actions=" + actions +
                '}';
    }

    /**
    @Override
    public String toString() {
        return"name='" + name + '\'' +
                ", health=" + stat.getHealth() +
                ", attack=" + stat.getAttack() +
                ", defense=" + stat.getDefense() +
                ", speed=" + stat.getSpeed();
    }
     */



    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel parcel, int i) {
        parcel.writeString(name);
        parcel.writeString(type);
        parcel.writeParcelable(stats, i);
        parcel.writeList(actions);
    }
}
