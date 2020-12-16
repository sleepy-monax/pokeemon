package xyz.pokeemon.model.shop;

import android.os.Parcel;
import android.os.Parcelable;

public class Effect implements Parcelable {
    private String type;

    public Effect(String type) {
        this.type = type;
    }


    protected Effect(Parcel in) {
        type = in.readString();
    }

    public static final Creator<Effect> CREATOR = new Creator<Effect>() {
        @Override
        public Effect createFromParcel(Parcel in) {
            return new Effect(in);
        }

        @Override
        public Effect[] newArray(int size) {
            return new Effect[size];
        }
    };

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    @Override
    public String toString() {
        return "Effect{" +
                "type='" + type + '\'' +
                '}';
    }


    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(type);
    }
}
