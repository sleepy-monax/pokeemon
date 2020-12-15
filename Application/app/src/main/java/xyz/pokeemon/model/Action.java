package xyz.pokeemon.model;

import android.os.Parcel;
import android.os.Parcelable;

import java.io.Serializable;

public class Action implements Parcelable, Serializable {
    private String name;
    private int level;

    public Action(String attackName, int obtainingLevel) {
        this.name = attackName;
        this.level = obtainingLevel;
    }

    protected Action(Parcel in) {
        name = in.readString();
        level = in.readInt();
    }

    @Override
    public int describeContents() {
        return 0;
    }

    public static final Creator<Action> CREATOR = new Creator<Action>() {
        @Override
        public Action createFromParcel(Parcel in) {
            return new Action(in);
        }

        @Override
        public Action[] newArray(int size) {
            return new Action[size];
        }
    };

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getLevel() {
        return level;
    }

    public void setLevel(int level) {
        this.level = level;
    }

    @Override
    public String toString() {
        return "name='" + name + '\'' +
                ", obtainingLevel='" + level;
    }

    @Override
    public void writeToParcel(Parcel parcel, int i) {
        parcel.writeString(name);
        parcel.writeInt(level);
    }
}
