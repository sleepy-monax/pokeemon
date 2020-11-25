package xyz.myapplication.fragements;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebView;
import android.webkit.WebViewClient;

import xyz.myapplication.R;


public class TeamFragment extends Fragment {
    private WebView webView;

    public TeamFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_home, container, false);
        webView = (WebView) v.findViewById(R.id.wv_home);
        webView.setWebViewClient(new WebViewClient());
        webView.loadUrl("https://pokeemon.xyz/team");
        webView.setWebViewClient(new WebViewClient());
        return v;
    }
}