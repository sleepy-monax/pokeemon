package xyz.pokeemon.model;

import android.os.Parcel;
import android.os.Parcelable;

public class Pet implements Parcelable {

    private String name;
    private int health, attack, defend, speed;

    public Pet(String name, int health, int attack, int defend, int speed) {
        this.name = name;
        this.health = health;
        this.attack = attack;
        this.defend = defend;
        this.speed = speed;
    }

    protected Pet(Parcel in) {
        name = in.readString();
        health = in.readInt();
        attack = in.readInt();
        defend = in.readInt();
        speed = in.readInt();
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

    public int getHealth() {
        return health;
    }

    public void setHealth(int health) {
        this.health = health;
    }

    public int getAttack() {
        return attack;
    }

    public void setAttack(int attack) {
        this.attack = attack;
    }

    public int getDefend() {
        return defend;
    }

    public void setDefend(int defend) {
        this.defend = defend;
    }

    public int getSpeed() {
        return speed;
    }

    public void setSpeed(int speed) {
        this.speed = speed;
    }

    @Override
    public String toString() {
        return"name='" + name + '\'' +
                ", health=" + health +
                ", attack=" + attack +
                ", defend=" + defend +
                ", speed=" + speed;
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel parcel, int i) {
        parcel.writeString(name);
        parcel.writeInt(health);
        parcel.writeInt(attack);
        parcel.writeInt(defend);
        parcel.writeInt(speed);
    }
}
