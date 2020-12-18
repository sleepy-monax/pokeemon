package xyz.pokeemon.connection;

import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import xyz.pokeemon.MainActivity;
import xyz.pokeemon.R;
import xyz.pokeemon.connection.home.HomeFragment;
import xyz.pokeemon.model.User;
import xyz.pokeemon.repository.UserRepository;

public class SignUpFragment extends Fragment {
    private Button signInBtn, signUpBtn;

    private EditText password, confirmPassword, pseudo, email;

    private UserRepository repository = new UserRepository();
    private boolean pseudoIsCorrect, emailIsCorrect;

    public SignUpFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_sign_up, container, false);
        password = v.findViewById(R.id.et_signup_password);
        confirmPassword = v.findViewById(R.id.et_signup_confirm_password);
        pseudo = v.findViewById(R.id.et_signup_pseudo);
        email = v.findViewById(R.id.et_signup_email);
        submit(v);
        goToSignIn(v);
        addListenerOnInput();

        return v;
    }

    private void addListenerOnInput() {
        pseudo.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                if (charSequence.toString().matches("^[a-zA-Z0-9]{1,20}")) {
                    pseudoIsCorrect = true;
                }
            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });

        email.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                if (charSequence.toString().matches("^.+@.+\\..+")) {
                    emailIsCorrect = true;

                }
            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });
    }

    public void submit(View view) {
        signUpBtn = view.findViewById(R.id.btn_signup_signup);

        signUpBtn.setOnClickListener(v -> {
            if (pseudoIsCorrect && emailIsCorrect) {
                if (password.getText().toString().equals(confirmPassword.getText().toString())) {
                    final User user =new User(
                            pseudo.getText().toString(),
                            email.getText().toString(),
                            password.getText().toString()
                    );
                    MainActivity.setUser(user);
                    repository.create(
                            user
                    ).observe(getViewLifecycleOwner(), us -> {
                        if (us.getId() != 0) {
                            FragmentTransaction ft = SignUpFragment.this.getParentFragmentManager().beginTransaction();
                            ft.replace(R.id.fl_wrapper, new HomeFragment());
                            ft.addToBackStack(null);
                            ft.commit();
                        }
                        else {
                            if (us.getPseudo().equals(user.getPseudo())) {
                                pseudo.setText("");
                                pseudo.setHint("Pseudo already exist");
                                pseudo.setHintTextColor(getResources().getColor(R.color.colorError));
                            }
                            if (us.getEmail().equals(user.getEmail())) {
                                email.setText("");
                                email.setHint("Email already exist");
                                email.setHintTextColor(getResources().getColor(R.color.colorError));
                            }
                        }
                    });
                }
            }
        });
    }

    public void goToSignIn(View view) {
        signInBtn = view.findViewById(R.id.btn_signup_login);
        signInBtn.setOnClickListener(v -> {
            FragmentTransaction ft = SignUpFragment.this.getParentFragmentManager().beginTransaction();
            ft.replace(R.id.fl_wrapper, new SignInFragment());
            ft.addToBackStack(null);
            ft.commit();
        });
    }
}