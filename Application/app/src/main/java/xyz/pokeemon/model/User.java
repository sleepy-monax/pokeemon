package xyz.pokeemon.model;

public class User {

    private int id, money;
    private String pseudo, email, password;
    private boolean admin;

    public User(int id, int money, String pseudo, String email, String password, boolean admin) {
        this.id = id;
        this.money = money;
        this.pseudo = pseudo;
        this.email = email;
        this.password = password;
        this.admin = admin;
    }

    public User(String pseudo, String email, String password) {
        this.admin = false;
        this.money = 120;
        this.pseudo = pseudo;
        this.email = email;
        this.password = password;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getMoney() {
        return money;
    }

    public void setMoney(int money) {
        this.money = money;
    }

    public String getPseudo() {
        return pseudo;
    }

    public void setPseudo(String pseudo) {
        this.pseudo = pseudo;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public boolean isAdmin() {
        return admin;
    }

    public void setAdmin(boolean admin) {
        this.admin = admin;
    }

    @Override
    public String toString() {
        return "User{" +
                "id=" + id +
                ", money=" + money +
                ", pseudo='" + pseudo + '\'' +
                ", email='" + email + '\'' +
                ", password='" + password + '\'' +
                ", admin=" + admin +
                '}';
    }
}
