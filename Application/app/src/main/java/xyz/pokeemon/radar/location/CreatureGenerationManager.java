package xyz.pokeemon.radar.location;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.view.View;
import android.widget.Button;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.util.List;
import java.util.Random;

import xyz.pokeemon.R;
import xyz.pokeemon.model.User;
import xyz.pokeemon.model.creature.Creature;
import xyz.pokeemon.radar.animations.AnimationEffects;
import xyz.pokeemon.repository.UserRepository;
import xyz.pokeemon.serialization.Utils;

/**
 *  This class will generate a button randomly on a view.
 *  It initializes the button parameters.
 *  Apply animation on the generated button.
 *  Apply button position update.
 */
public class CreatureGenerationManager {
    private Button b;
    private PositionManager positionManager;
    private AnimationEffects animationEffect;
    private List<Creature> creatures;
    private UserRepository repository = new UserRepository();
    private User user;


    /**
     * @param v get the view where is the button.
     * @param a get the current activity.
     *
     *  Generate a button randomly on the view.
     */
    public Button generatePosition(View v, Activity a){
        //Display button with a blinking dot.
        b = buttonProperties(v);

        //Generate random for position.
        positionManager = new PositionManager();
        positionManager.generatePosition(a, b);

        //Start blinking animation of the button.
        applyAnimation();
        return b;
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
        b = (Button) v.findViewById(R.id.b);

        //Set the button disable if it's not in range near the player.
        b.setEnabled(true);

        //Set the onclick event of the button.
        b.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                final AlertDialog.Builder builder = new AlertDialog.Builder(v.getContext());
                creatures = initialiseListCreature(v.getContext());

                //Generate random for creature capture.
                Random random = new Random();
                int randomIndex = random.nextInt(creatures.size());
                Creature creature = creatures.get(randomIndex);
                //Set information.
                builder.setTitle("Captured Creature");
                builder.setMessage("You have captured : " + creature.getName());

                //Closing button on the alert dialog.
                builder.setNegativeButton("OK",
                        new DialogInterface.OnClickListener()
                        {
                            @Override
                            public void onClick(DialogInterface dialog, int which)
                            {
                                dialog.dismiss();
                                //repository.addCreature(user, creature);
                            }
                        });

                //Creating dialog box
                AlertDialog alert = builder.create();
                alert.show();
            }
        });
        return b;
    }

    /**
     *  Apply blinking animation for the button.
     */
    public void applyAnimation(){
        animationEffect = new AnimationEffects();
        animationEffect.blinkAnimation(b);
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
