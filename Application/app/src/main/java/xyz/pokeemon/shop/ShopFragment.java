package xyz.pokeemon.shop;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebView;
import android.webkit.WebViewClient;

import xyz.pokeemon.R;

public class ShopFragment extends Fragment {

    private WebView webView;

    public ShopFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_shop, container, false);
        webView = (WebView) v.findViewById(R.id.wv_shop);
        webView.setWebViewClient(new WebViewClient());
        webView.loadUrl("https://pokeemon.xyz/shop");
        webView.setWebViewClient(new WebViewClient());
        return v;
    }
}