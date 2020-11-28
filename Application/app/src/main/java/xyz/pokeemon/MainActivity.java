package xyz.pokeemon;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;

import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;

import com.google.android.material.bottomnavigation.BottomNavigationView;

import xyz.pokeemon.shop.ShopFragment;
import xyz.pokeemon.connection.SignInFragment;
import xyz.pokeemon.team.TeamFragment;
import xyz.pokeemon.radar.RadarFragment;

public class MainActivity extends AppCompatActivity {

    private View decorView;
    private Fragment selectedFragment;
    private BottomNavigationView bottomNavigationView;

    //Event to configure each button of navigation bar
    private BottomNavigationView.OnNavigationItemSelectedListener navListener =
            new BottomNavigationView.OnNavigationItemSelectedListener() {
                @Override
                public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                    selectedFragment = null;
                    switch(item.getItemId()){
                        case R.id.ic_home:
                            selectedFragment = new RadarFragment();
                            break;
                        case R.id.ic_pets:
                            selectedFragment = new TeamFragment();
                            break;
                        case R.id.ic_shop:
                            selectedFragment = new ShopFragment();
                            break;
                        case R.id.ic_account:
                            selectedFragment = new SignInFragment();
                            break;
                    }
                    getSupportFragmentManager().beginTransaction().replace(
                            R.id.fl_wrapper,
                            selectedFragment)
                        .commit();
                    return true;
                }
            };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //Apply the method to hide bars
        decorView = getWindow().getDecorView();
        decorView.setOnSystemUiVisibilityChangeListener(new View.OnSystemUiVisibilityChangeListener() {
            @Override
            public void onSystemUiVisibilityChange(int visibility) {
                if(visibility==0){
                    decorView.setSystemUiVisibility(hideSystemBar());
                }
            }
        });

        //Search navbar by ID and set listener to each button
        bottomNavigationView = findViewById(R.id.bottom_navigation);
        bottomNavigationView.setOnNavigationItemSelectedListener(navListener);
        bottomNavigationView.setSelectedItemId(R.id.ic_home);
    }

    //Call when this activity is running
    @Override
    public void onWindowFocusChanged(boolean hasFocus) {
        super.onWindowFocusChanged(hasFocus);
        if(hasFocus){
            decorView.setSystemUiVisibility(hideSystemBar());
        }
    }

    //Called when the activity is create to hide the system bar
    private int hideSystemBar(){
        return View.SYSTEM_UI_FLAG_LAYOUT_STABLE
                | View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY
                | View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN
                | View.SYSTEM_UI_FLAG_FULLSCREEN
                |View.SYSTEM_UI_FLAG_LIGHT_NAVIGATION_BAR;
    }
}