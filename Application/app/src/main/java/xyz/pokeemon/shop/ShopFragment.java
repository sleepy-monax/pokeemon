package xyz.pokeemon.shop;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import java.util.List;

import xyz.pokeemon.R;
import xyz.pokeemon.adapter.ItemAdapter;
import xyz.pokeemon.model.pet.Action;
import xyz.pokeemon.model.shop.Item;
import xyz.pokeemon.serialization.Utils;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.lang.reflect.Type;

public class ShopFragment extends Fragment {

    private List<Item> items;

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

        View view = inflater.inflate(R.layout.fragment_shop, container, false);
        initialiseListShop();
        final ListView lvShop = view.findViewById(R.id.lv_shop);
        itemOnClick(lvShop);
        ItemAdapter adapter = new ItemAdapter(
                getContext(),
                R.id.lv_shop,
                items
        );

        lvShop.setAdapter(adapter);

        return view;
    }

    /**
     * @param lvItem corresponds to each pet in the view.
     *
     *  This method set on click on each pet on the pet listView.
     */
    public void itemOnClick(ListView lvItem){
        lvItem.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View v, int position, long id) {
                Item item = (Item) lvItem.getItemAtPosition(position);
                final AlertDialog.Builder builder = new AlertDialog.Builder(v.getContext());

                //Set information.
                builder.setTitle("Description:");
                builder.setMessage(item.getDescription());

                //Closing button on the alert dialog.
                builder.setNegativeButton("OK",
                        new DialogInterface.OnClickListener()
                        {
                            @Override
                            public void onClick(DialogInterface dialog, int which)
                            {
                                dialog.dismiss();
                            }
                        });

                //Creating dialog box
                AlertDialog alert = builder.create();
                alert.show();
            }
        });
    }

    private void initialiseListShop() {
        String jsonFileString = Utils.getJsonFromAssets(getContext(), "items.json");

        Gson gson = new Gson();
        Type listItemType = new TypeToken<List<xyz.pokeemon.model.shop.Item>>() {}.getType();

        items = gson.fromJson(jsonFileString, listItemType);
    }
}