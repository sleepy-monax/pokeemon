package xyz.pokeemon.radar.location;

import android.app.Activity;
import android.content.Intent;
import android.os.Handler;
import android.util.DisplayMetrics;
import android.view.View;
import android.widget.Button;

import java.util.Random;

import xyz.pokeemon.MainActivity;

/**
 *  This class generates a button randomly on a view.
 */
public class PositionGenerator {
    private DisplayMetrics displayMetrics;
    private Random random;


    /**
     * @param a get the current activity.
     * @param b get the button instance from LocationManager class.
     *
     *  Generate a button randomly on the view.
     */
    public void generatePosition(Activity a, Button b){
        //Set the screen size.
        displayMetrics = new DisplayMetrics();
        a.getWindowManager().getDefaultDisplay().getMetrics(displayMetrics);

        //Generate random for position.
        random = new Random();

        b.animate()
                .x(random.nextFloat()*displayMetrics.widthPixels)
                .y(random.nextFloat()*displayMetrics.heightPixels)
                .setDuration(10)
                .start();
    }
}
