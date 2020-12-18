package xyz.pokeemon.repository;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import xyz.pokeemon.api.Api;
import xyz.pokeemon.api.CreatureService;
import xyz.pokeemon.model.User;
import xyz.pokeemon.model.creature.Creature;

public class CreatureRepository {

    public CreatureRepository() {
    }

    private CreatureService getCreatureService() {
        return Api.get().create(CreatureService.class);
    }

    public LiveData<Boolean> addCreature(User user, Creature creature){
        final MutableLiveData<Boolean> mutableLiveData = new MutableLiveData<>();

        getCreatureService().postCreature(user.getId(), creature).enqueue(new Callback<Boolean>() {
            @Override
            public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                mutableLiveData.postValue(response.body());
            }

            @Override
            public void onFailure(Call<Boolean> call, Throwable t) {

            }
        });

        return mutableLiveData;
    }
}
