package xyz.pokeemon.model;

import android.os.Parcel;
import android.os.Parcelable;

public class Stat implements Parcelable {
    private int attack, health, defense, speed;

    public Stat(){}

    public Stat(int attack, int health, int defense, int speed) {
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
        this.health = health;
    }

    protected Stat(Parcel in) {
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
        dest.writeInt(attack);
        dest.writeInt(defense);
        dest.writeInt(speed);
        dest.writeInt(health);
    }

    @Override
    public String toString() {
        return "Stat{" +
                "attack=" + attack +
                ", health=" + health +
                ", defense=" + defense +
                ", speed=" + speed +
                '}';
    }
}
