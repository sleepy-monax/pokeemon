package xyz.pokeemon.adapter;

import android.content.Context;
import android.content.res.AssetManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import java.io.IOException;
import java.io.InputStream;
import java.util.List;

import xyz.pokeemon.R;
import xyz.pokeemon.model.creature.Creature;

public class CreatureAdapter extends ArrayAdapter<Creature> {

    public CreatureAdapter(@NonNull Context context, int resource, @NonNull List<Creature> objects) {
        super(context, resource, objects);
    }


    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {

        if (convertView == null) {
            final LayoutInflater inflater = LayoutInflater.from(getContext());
            convertView = inflater.inflate(R.layout.list_item_creatures, parent, false);
        }

        final Creature creature = getItem(position);
        populateViewWithCreature(convertView, creature);

        return convertView;
    }

    private void populateViewWithCreature(View convertView, Creature creature) {
        TextView tvHealth = convertView.findViewById(R.id.tv_health),
                tvAttack = convertView.findViewById(R.id.tv_attack),
                tvDefend = convertView.findViewById(R.id.tv_defend),
                tvSpeed = convertView.findViewById(R.id.tv_speed),
                tvName = convertView.findViewById(R.id.tv_name_creature);


        tvName.setText(creature.getName());
        tvHealth.setText(creature.getStats().getHealth()+"");
        tvAttack.setText(creature.getStats().getAttack()+"");
        tvDefend.setText(creature.getStats().getDefense()+"");
        tvSpeed.setText(creature.getStats().getSpeed()+"");

        putImageCreature(convertView, creature);
    }

    private void putImageCreature(View v, Creature creature){
        AssetManager assetManager = v.getContext().getAssets();
        ImageView imageView = (ImageView) v.findViewById(R.id.iv_item_pokeemon);
        try (InputStream inputStream = assetManager.open("creatures/"+creature.getName()+".png")) {
            Bitmap bitmap = BitmapFactory.decodeStream(inputStream);
            imageView.setImageBitmap(bitmap);
        } catch (IOException ex) {
            ex.getStackTrace();
        }
    }
}
