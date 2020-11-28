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
import android.location.LocationManager;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.location.LocationServices;

import xyz.pokeemon.R;

public class RadarFragment extends Fragment{

    private TextView tvLatitude, tvLongitude;
    private LocationManager locationManager;
    private FusedLocationProviderClient client;
    private RadarView radarView = null;

    public RadarFragment(){

    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

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
        return v;
    }

    //Check the app permission
    public void checkPermission(){

        locationManager =(LocationManager) getActivity().getSystemService(Context.LOCATION_SERVICE);
        //Check permissions
        if((ContextCompat.checkSelfPermission(getContext(), Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) &&
                (ContextCompat.checkSelfPermission(getContext(), Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED) &&
                (locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER))
                || (locationManager.isProviderEnabled(LocationManager.NETWORK_PROVIDER))){

            //When permissions Granted
            ActivityCompat.requestPermissions(getActivity(), new String[]{
                        Manifest.permission.ACCESS_COARSE_LOCATION,
                        Manifest.permission.ACCESS_FINE_LOCATION
                    },
                    1);

            locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, 1, 1, new LocationListener() {
                @Override
                public void onLocationChanged(@NonNull Location location) {
                    if(location!=null) {
                        tvLatitude.setText(String.valueOf(location.getLatitude()));
                        tvLongitude.setText(String.valueOf(location.getLongitude()));
                    }else{

                    }
                }
            });
        }
    }
}