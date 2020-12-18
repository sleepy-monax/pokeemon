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
import xyz.pokeemon.adapter.CreatureAdapter;
import xyz.pokeemon.model.creature.Action;
import xyz.pokeemon.model.creature.Creature;
import xyz.pokeemon.serialization.Utils;


public class TeamFragment extends Fragment {

    private List<Creature> creatures;

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
        initialiseListCreature();
        final ListView lvCreatures = view.findViewById(R.id.lv_team);
        creatureOnClick(lvCreatures);
        CreatureAdapter adapter = new CreatureAdapter(
                getContext(),
                R.id.lv_team,
                creatures
        );

        lvCreatures.setAdapter(adapter);
        return view;
    }


    /**
     * @param lvCreatures corresponds to each creature in the view.
     *
     *  This method set on click on each creature on the creature listView.
     */
    public void creatureOnClick(ListView lvCreatures){
        lvCreatures.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View v, int position, long id) {
                Creature creature = (Creature) lvCreatures.getItemAtPosition(position);
                final AlertDialog.Builder builder = new AlertDialog.Builder(v.getContext());

                //Set information.
                builder.setTitle("Stats");
                String message = "";
                for (Action action: creature.getActions()) {
                    message += "Name: " + action.getName() + " \t "
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

    private void initialiseListCreature() {
        String jsonFileString = Utils.getJsonFromAssets(getContext(), "creatures.json");

        Gson gson = new Gson();
        Type listCreatureType = new TypeToken<List<Creature>>() {}.getType();

        creatures = gson.fromJson(jsonFileString, listCreatureType);
    }

}