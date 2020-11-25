package xyz.myapplication;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;

import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;

import com.google.android.material.bottomnavigation.BottomNavigationView;

import xyz.myapplication.fragements.HomeFragment;
import xyz.myapplication.fragements.AccountFragment;
import xyz.myapplication.fragements.ShopFragment;
import xyz.myapplication.fragements.TeamFragment;

public class MainActivity extends AppCompatActivity {

    private View decorView;

    private BottomNavigationView.OnNavigationItemSelectedListener navListener =
            new BottomNavigationView.OnNavigationItemSelectedListener() {
                @Override
                public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                    Fragment selectedFragement = null;
                    switch(item.getItemId()){
                        case R.id.ic_home:
                            selectedFragement = new HomeFragment();
                            break;
                        case R.id.ic_pets:
                            selectedFragement = new TeamFragment();
                            break;
                        case R.id.ic_shop:
                            selectedFragement = new ShopFragment();
                            break;
                        case R.id.ic_account:
                            selectedFragement = new AccountFragment();
                            break;
                    }
                    getSupportFragmentManager().beginTransaction().replace(
                            R.id.fl_wrapper,
                            selectedFragement)
                        .commit();
                    return true;
                }
            };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        decorView = getWindow().getDecorView();
        decorView.setOnSystemUiVisibilityChangeListener(new View.OnSystemUiVisibilityChangeListener() {
            @Override
            public void onSystemUiVisibilityChange(int visibility) {
                if(visibility==0){
                    decorView.setSystemUiVisibility(hideSystemBar());
                }
            }
        });

        BottomNavigationView bottomNavigationView = findViewById(R.id.bottom_navigation);
        bottomNavigationView.setOnNavigationItemSelectedListener(navListener);
    }

    @Override
    public void onWindowFocusChanged(boolean hasFocus) {
        super.onWindowFocusChanged(hasFocus);
        if(hasFocus){
            decorView.setSystemUiVisibility(hideSystemBar());
        }
    }

    private int hideSystemBar(){
        return View.SYSTEM_UI_FLAG_LAYOUT_STABLE
                | View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY
                | View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN
                | View.SYSTEM_UI_FLAG_FULLSCREEN;
    }
}