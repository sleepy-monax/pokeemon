package xyz.pokeemon.team;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;

import xyz.pokeemon.R;
import xyz.pokeemon.adapter.PetAdapter;
import xyz.pokeemon.model.Pet;


public class TeamFragment extends Fragment {

    private List<Pet> pets = new ArrayList<>();

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

        final ListView lvPets = view.findViewById(R.id.lv_team);
        pets.add(new Pet("Aracnoide", 200, 20, 10, 50));
        pets.add(new Pet("Pismiflor", 100, 50, 5, 20));
        pets.add(new Pet("Jofleur", 300, 10, 15, 30));
        pets.add(new Pet("Smilodon", 150, 50, 15, 60));

        PetAdapter adapter = new PetAdapter(
                getContext(),
                R.id.lv_team,
                pets
        );

        lvPets.setAdapter(adapter);

        return view;
    }
}