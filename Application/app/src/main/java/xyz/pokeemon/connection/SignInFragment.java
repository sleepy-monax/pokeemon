package xyz.pokeemon.connection;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import xyz.pokeemon.R;

public class SignInFragment extends Fragment {

    private Button btn;

    public SignInFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_sign_in, container, false);
        goToSignUp(v);
        return v;
    }

    public void submit(View view){

    }

    public void goToSignUp(View view){
        btn = (Button) view.findViewById(R.id.btn_signin_signup);
        btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                FragmentTransaction ft = SignInFragment.this.getParentFragmentManager().beginTransaction();
                ft.replace(R.id.fl_wrapper, new SignUpFragment());
                ft.addToBackStack(null);
                ft.commit();
            }
        });
    }
}