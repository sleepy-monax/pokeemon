package xyz.pokeemon.team;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.util.List;

import xyz.pokeemon.R;
import xyz.pokeemon.adapter.PetAdapter;
import xyz.pokeemon.model.Item;
import xyz.pokeemon.model.Pet;
import xyz.pokeemon.serialization.Utils;


public class TeamFragment extends Fragment {

    private List<Pet> pets;

    public TeamFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_team, container, false);
        initialseListPet();
        final ListView lvPets = view.findViewById(R.id.lv_team);

        PetAdapter adapter = new PetAdapter(
                getContext(),
                R.id.lv_team,
                pets
        );

        lvPets.setAdapter(adapter);

        return view;
    }

    private void initialseListPet() {
        String jsonFileString = Utils.getJsonFromAssets(getContext(), "creatures.json");

        Gson gson = new Gson();
        Type listPetType = new TypeToken<List<Pet>>() {}.getType();

        pets = gson.fromJson(jsonFileString, listPetType);
    }

}