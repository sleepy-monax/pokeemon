package xyz.pokeemon.model.pet;

import android.os.Parcel;
import android.os.Parcelable;

public class Stat implements Parcelable {
    private String type;
    private int attack, health, defense, speed;

    public Stat(){}

    public Stat(String type, int attack, int health, int defense, int speed) {
        this.type=type;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
        this.health = health;
    }

    protected Stat(Parcel in) {
        type = in.readString();
        attack = in.readInt();
        defense = in.readInt();
        speed = in.readInt();
        health = in.readInt();
    }

    public static final Creator<Stat> CREATOR = new Creator<Stat>() {
        @Override
        public Stat createFromParcel(Parcel in) {
            return new Stat(in);
        }

        @Override
        public Stat[] newArray(int size) {
            return new Stat[size];
        }
    };

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public int getAttack() {
        return attack;
    }

    public void setAttack(int attack) {
        this.attack = attack;
    }

    public int getHealth() {
        return health;
    }

    public void setHealth(int health) {
        this.health = health;
    }

    public int getDefense() {
        return defense;
    }

    public void setDefense(int defense) {
        this.defense = defense;
    }

    public int getSpeed() {
        return speed;
    }

    public void setSpeed(int speed) {
        this.speed = speed;
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(type);
        dest.writeInt(attack);
        dest.writeInt(defense);
        dest.writeInt(speed);
        dest.writeInt(health);
    }

    @Override
    public String toString() {
        return "Stat{" +
                "type=" + type +
                "attack=" + attack +
                ", health=" + health +
                ", defense=" + defense +
                ", speed=" + speed +
                '}';
    }
}
