package xyz.pokeemon.radar.location;

import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import android.location.Location;
import android.widget.Button;

/**
 *  This class will calculate the new button position when the users moves.
 */
public class PositionUpdateCalculator{
    private SensorManager sensorManager;
    private Sensor accelerometre;

    /**
     *  Update the position of the button when the user moves.
     *  Using phone sensor to detect when the user moves and apply new position of the button.
     *  This can be compared to a compass system.
     */
    public void updateButtonPosition(Location location, Button b){
        SensorEventListener sensorEventListener = new SensorEventListener() {
            @Override
            public void onSensorChanged(SensorEvent event) {
                double x = event.values[0];
                double y = event.values[1];
            }

            @Override
            public void onAccuracyChanged(Sensor sensor, int accuracy) {

            }
        };
    }

}
