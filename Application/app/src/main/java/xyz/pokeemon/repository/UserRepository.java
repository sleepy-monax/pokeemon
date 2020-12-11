package xyz.pokeemon.repository;

import android.util.Log;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import xyz.pokeemon.api.ApiClient;
import xyz.pokeemon.api.UserService;
import xyz.pokeemon.model.User;

public class UserRepository {

    public UserRepository() {
    }

    private UserService getUserService() {
        return ApiClient.getClient().create(UserService.class);
    }

    public LiveData<User> create(User user) {
        final MutableLiveData<User> mutableLiveData = new MutableLiveData<>();

        getUserService().postUser(user).enqueue(new Callback<User>() {
            @Override
            public void onResponse(Call<User> call, Response<User> response) {
                mutableLiveData.postValue(response.body());
            }

            @Override
            public void onFailure(Call<User> call, Throwable t) {
                Log.e("User", t.toString());
            }
        });

        return mutableLiveData;
    }
}
