package xyz.pokeemon.radar.location;

import android.app.Activity;
import android.location.Location;
import android.widget.Button;

/**
 *  This class will mange the button position;
 */
public class PositionManager {

    /**
     * @param a get the current activity.
     * @param b get the button instance from LocationManager class.
     *
     *  Generate a button randomly on the view.
     */
    public void generatePosition(Activity a, Button b){
        PositionGenerator positionGenerator = new PositionGenerator();
        positionGenerator.generatePosition(a, b);
    }


    /**
     *  Update the position of the button when the user moves.

    public void updateButtonPosition(Location location, Button b){
        PositionUpdateCalculator positionUpdateCalculator = new PositionUpdateCalculator();
        positionUpdateCalculator.updateButtonPosition(location, b);
    }
     */
}
