package xyz.pokeemon.radar;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;
import androidx.fragment.app.Fragment;

import android.Manifest;
import android.content.Context;
import android.content.pm.PackageManager;
import android.location.Location;
import android.location.LocationListener;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.location.LocationServices;

import xyz.pokeemon.R;
import xyz.pokeemon.radar.location.CreatureGenerationManager;


/**
 *  This class represents the radar container.
 *  It will contains the RadarView.
 *  It will check the app permissions to have access to geolocation coordinates.
 *  It generates a button randomly on the radar to represent a creature that you can capture.
 */
public class RadarFragment extends Fragment {
    private TextView tvLatitude, tvLongitude;
    private RadarView radarView = null;
    private CreatureGenerationManager creatureGenerationManager;

    private android.location.LocationManager locationManager;

    private Location loca;
    private FusedLocationProviderClient client;
    
    public RadarFragment(){

    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }


    /**
     * @param inflater
     * @param container
     * @param savedInstanceState
     * @return
     *
     *  That method creates the radar view.
     *  It retrieves the coordinates of the user.
     *  It calls the method to check the permissions of geo location.
     *  This method calls the method to generate randomly a button on the radar.
     */
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_radar, container, false);

        //Find Latitude & Longitude and check the permission
        //Replace the coordinates
        tvLatitude = v.findViewById(R.id.tv_latitude);
        tvLongitude = v.findViewById(R.id.tv_longitude);
        client = LocationServices.getFusedLocationProviderClient(getActivity());
        checkPermission();

        //Create radar
        radarView = (RadarView) v.findViewById(R.id.rdv_radar);
        if (radarView != null) radarView.startAnimation();
        radarView.setShowCircles(true);

        //Generate a button randomly on the radar
        generateRandomButton(v);

        return v;
    }


    /**
     *  The App will check the permissions of location.
     *  It will ask to the user if it can access to his data.
     */
    public void checkPermission(){
        locationManager =(android.location.LocationManager) getActivity().getSystemService(Context.LOCATION_SERVICE);
        //Check permissions
        if((ContextCompat.checkSelfPermission(getContext(), Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) &&
                (ContextCompat.checkSelfPermission(getContext(), Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED) &&
                (locationManager.isProviderEnabled(android.location.LocationManager.GPS_PROVIDER))
                || (locationManager.isProviderEnabled(android.location.LocationManager.NETWORK_PROVIDER))){

            //When permissions Granted
            ActivityCompat.requestPermissions(getActivity(), new String[]{
                            Manifest.permission.ACCESS_COARSE_LOCATION,
                            Manifest.permission.ACCESS_FINE_LOCATION
                    },
                    1);

            //Display of coordinates when they change
            locationManager.requestLocationUpdates(android.location.LocationManager.GPS_PROVIDER, 1, 1, new LocationListener() {
                @Override
                public void onLocationChanged(@NonNull Location location) {
                    loca = location;
                    if(location!=null) {
                        tvLatitude.setText(String.valueOf(location.getLatitude()));
                        tvLongitude.setText(String.valueOf(location.getLongitude()));
                    }
                }
            });
        }
    }


    /**
     *  Generate a button randomly on the radar.
     *  The button corresponds to a creature.
     */
    public void generateRandomButton(View v){
        //Display a button with a blinking dot
        creatureGenerationManager = new CreatureGenerationManager();
        creatureGenerationManager.generatePosition(v, getActivity());
    }


    /**
     *  Update the position of the button when the user moves.
     *  Using phone sensor to detect when the user moves and apply new position of the button.
     *  This can be compared to a compass system.

     public void updateButtonPosition(Location loca, Button b){
     creatureGenerationManager.updateButtonPosition(loca, b);
     }
     */
}