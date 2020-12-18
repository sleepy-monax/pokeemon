package xyz.pokeemon.api;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;
import xyz.pokeemon.model.creature.Creature;

public interface CreatureService {

    @POST("creatures/{id}")
    Call<Boolean> postCreature(int id, @Body Creature creature);
}
