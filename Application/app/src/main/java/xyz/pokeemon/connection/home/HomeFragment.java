package xyz.pokeemon.connection.home;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import xyz.pokeemon.R;
import xyz.pokeemon.model.User;

public class HomeFragment extends Fragment {

    private User user;

    private TextView tvMoney;
    private EditText edPseudo, edEmail, edPassword;

    public HomeFragment() {
    }

    public HomeFragment(User user) {
        this.user = user;
    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_home, container, false);
                return view;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        tvMoney = view.findViewById(R.id.tv_home_money);
        edPseudo = view.findViewById(R.id.ed_home_pseudo_user);
        edEmail = view.findViewById(R.id.ed_home_email);
        edPassword = view.findViewById(R.id.ed_home_password);
    }

    public void displayReceiveData(User user) {
        this.user = user;
    }
}
