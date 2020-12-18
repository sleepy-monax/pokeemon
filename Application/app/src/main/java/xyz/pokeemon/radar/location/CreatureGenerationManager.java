package xyz.pokeemon.radar.location;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.util.Log;
import android.view.View;
import android.widget.Button;

import androidx.fragment.app.Fragment;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.util.List;
import java.util.Random;

import xyz.pokeemon.MainActivity;
import xyz.pokeemon.R;
import xyz.pokeemon.model.creature.Creature;
import xyz.pokeemon.radar.animations.AnimationEffects;
import xyz.pokeemon.repository.CreatureRepository;
import xyz.pokeemon.repository.UserRepository;
import xyz.pokeemon.serialization.Utils;

/**
 *  This class will generate a button randomly on a view.
 *  It initializes the button parameters.
 *  Apply animation on the generated button.
 *  Apply button position update.
 */
public class CreatureGenerationManager {
    private Button btn;
    private PositionManager positionManager;
    private AnimationEffects animationEffect;
    private List<Creature> creatures;
    private UserRepository userRepository = new UserRepository();
    private CreatureRepository creatureRepository = new CreatureRepository();
    private Fragment fragment;


    /**
     * @param view get the view where is the button.
     * @param a get the current activity.
     *
     *  Generate a button randomly on the view.
     */
    public Button generateButton(View view, Activity a, Fragment fragment){
        //Display button with a blinking dot.
        btn = buttonProperties(view);
        this.fragment = fragment;

        //Generate random for position.
        positionManager = new PositionManager();
        positionManager.generatePosition(a, btn);

        //Start blinking animation of the button.
        applyAnimation();
        return btn;
    }


    /**
     * @param v get the view where is the button.
     * @return
     *
     *  Find the button id on the file .xml and set it disabled while it isn't in a good range.
     *  When the user can click on the button, it creates an alert dialog
     *  and it shows what you have captured.
     */
    public Button buttonProperties(View v){
        btn = v.findViewById(R.id.b);

        //Set the button disable if it's not in range near the player.
        btn.setEnabled(true);

        //Set the onclick event of the button.
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                final AlertDialog.Builder builder = new AlertDialog.Builder(v.getContext());
                creatures = initialiseListCreature(v.getContext());

                //Generate random for creature capture.
                Random random = new Random();
                int randomIndex = random.nextInt(creatures.size());
                Creature creature = creatures.get(randomIndex);
                btn.setText(creature.getName());
                //Set information.
                builder.setTitle("Captured Creature");
                builder.setMessage("You have captured : " + creature.getName());

                //Closing button on the alert dialog.
                builder.setPositiveButton("GOTCHA",
                        (dialog, which) -> {
                            dialog.dismiss();
                            btn.clearAnimation();
                            btn.setVisibility(View.INVISIBLE);
//                            creatureRepository.addCreature(MainActivity.user, creature)
//                            .observe(fragment.getViewLifecycleOwner(), isAdd -> Log.i("creature", isAdd+""));
                        });

                //Creating dialog box
                AlertDialog alert = builder.create();
                alert.show();
            }
        });
        return btn;
    }

    /**
     *  Apply blinking animation for the button.
     */
    public void applyAnimation(){
        animationEffect = new AnimationEffects();
        animationEffect.blinkAnimation(btn);
    }


    /**
     * @param context get the context of the current view.
     * @return return the creature list read in the json file.
     */
    private List<Creature> initialiseListCreature(Context context) {
        String jsonFileString = Utils.getJsonFromAssets(context, "creatures.json");

        Gson gson = new Gson();
        Type listCreatureType = new TypeToken<List<Creature>>() {}.getType();

        creatures = gson.fromJson(jsonFileString, listCreatureType);
        return creatures;
    }

    /**
     *  Register the creature capture in the database.
     */
    public void registerCreatureCapture(){

    }


    /**
     *  Update the position of the button when the user moves

     public void updateButtonPosition(Location location, Button b){
     positionManager.updateButtonPosition(location, b);
     }
     */
}
