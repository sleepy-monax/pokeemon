package xyz.pokeemon.shop;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import java.util.List;

import xyz.pokeemon.R;
import xyz.pokeemon.adapter.ItemAdapter;
import xyz.pokeemon.model.Item;
import xyz.pokeemon.serialization.Utils;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;
import java.util.List;

public class ShopFragment extends Fragment {

    private List<Item> items;

    public ShopFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    private void initialseListShop() {
        String jsonFileString = Utils.getJsonFromAssets(getContext(), "items.json");

        Gson gson = new Gson();
        Type listItemType = new TypeToken<List<Item>>() {}.getType();

        items = gson.fromJson(jsonFileString, listItemType);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        initialseListShop();
        View view = inflater.inflate(R.layout.fragment_shop, container, false);

        final ListView lvShop = view.findViewById(R.id.lv_shop);
        ItemAdapter adapter = new ItemAdapter(
                getContext(),
                R.id.lv_shop,
                items
        );

        lvShop.setAdapter(adapter);

        return view;
    }
}