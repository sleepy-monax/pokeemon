package xyz.pokeemon.api;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import xyz.pokeemon.model.User;

public interface UserService {

    @GET("users")
    Call<List<User>> getUsers();

    @POST("users/authenticate")
    Call<User> getUser(@Body User user);

    @POST("users")
    Call<User> postUser(@Body User user);
}
