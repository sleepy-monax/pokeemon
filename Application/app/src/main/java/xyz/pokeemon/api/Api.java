package xyz.pokeemon.api;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class Api {

    private static final String BASE_URL_API_DEV = "http://10.0.2.2:5000/";

    public static Retrofit get() {
        return new Retrofit.Builder()
                .baseUrl(BASE_URL_API_DEV)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
    }
}
