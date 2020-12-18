package xyz.pokeemon.api;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import xyz.pokeemon.model.User;

public interface UserService {

    @GET("users")
    Call<User> getUser();

    @POST("users")
    Call<User> postUser(@Body User user);
}
