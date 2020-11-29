package xyz.pokeemon.adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import java.util.List;

import xyz.pokeemon.R;
import xyz.pokeemon.model.Item;

public class ItemAdapter extends ArrayAdapter<Item> {

    public ItemAdapter(@NonNull Context context, int resource, @NonNull List<Item> objects) {
        super(context, resource, objects);
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {

        if (convertView == null) {
            final LayoutInflater inflater = LayoutInflater.from(getContext());
            convertView = inflater.inflate(R.layout.list_item_shop, parent, false);
        }

        final Item item = getItem(position);
        populateViewWithItem(convertView,  item);

        return convertView;
    }

    private void populateViewWithItem(View convertView, Item item) {
        TextView tvName = convertView.findViewById(R.id.tv_item_name),
                tvDescription = convertView.findViewById(R.id.tv_item_description),
                tvPrice = convertView.findViewById(R.id.tv_item_price);

        tvName.setText(item.getName());
        tvDescription.setText(item.getDescription());
        tvPrice.setText(item.getPrice()+"");
    }
}
