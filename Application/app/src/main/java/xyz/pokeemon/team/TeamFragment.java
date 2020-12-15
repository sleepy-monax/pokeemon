package xyz.pokeemon.team;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.util.List;

import xyz.pokeemon.R;
import xyz.pokeemon.adapter.PetAdapter;
import xyz.pokeemon.model.Action;
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
        petOnClick(lvPets);
        PetAdapter adapter = new PetAdapter(
                getContext(),
                R.id.lv_team,
                pets
        );

        lvPets.setAdapter(adapter);
        return view;
    }


    /**
     * @param lvPets corresponds to each pet in the view.
     *
     *  This method set on click on each pet on the pet listView.
     */
    public void petOnClick(ListView lvPets){
        lvPets.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View v, int position, long id) {
                Pet item = (Pet) lvPets.getItemAtPosition(position);
                final AlertDialog.Builder builder = new AlertDialog.Builder(v.getContext());

                //Set information.
                builder.setTitle("Stats");
                String message = "";
                for (Action action: item.getActions()) {
                    message += "Name: " + action.getName() + " - "
                            + "Level: " + action.getLevel()
                            + "\n";
                }
                builder.setMessage(message);

                //Closing button on the alert dialog.
                builder.setNegativeButton("OK",
                        new DialogInterface.OnClickListener()
                        {
                            @Override
                            public void onClick(DialogInterface dialog, int which)
                            {
                                dialog.dismiss();
                            }
                        });

                //Creating dialog box
                AlertDialog alert = builder.create();
                alert.show();
            }
        });
    }

    private void initialseListPet() {
        String jsonFileString = Utils.getJsonFromAssets(getContext(), "creatures.json");

        Gson gson = new Gson();
        Type listPetType = new TypeToken<List<Pet>>() {}.getType();

        pets = gson.fromJson(jsonFileString, listPetType);
    }

}