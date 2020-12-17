package xyz.pokeemon.adapter;

import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import java.util.List;

import xyz.pokeemon.R;
import xyz.pokeemon.model.pet.Pet;

public class PetAdapter extends ArrayAdapter<Pet> {

    public PetAdapter(@NonNull Context context, int resource, @NonNull List<Pet> objects) {
        super(context, resource, objects);
    }


    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {

        if (convertView == null) {
            final LayoutInflater inflater = LayoutInflater.from(getContext());
            convertView = inflater.inflate(R.layout.list_item_pets, parent, false);
        }

        final Pet pet = getItem(position);
        populateViewWithPet(convertView, pet);

        return convertView;
    }

    private void populateViewWithPet(View convertView, Pet pet) {
        TextView tvHealth = convertView.findViewById(R.id.tv_health),
                tvAttack = convertView.findViewById(R.id.tv_attack),
                tvDefend = convertView.findViewById(R.id.tv_defend),
                tvSpeed = convertView.findViewById(R.id.tv_speed),
                tvName = convertView.findViewById(R.id.tv_name_pet);

        Log.i("pet", pet.toString());

        tvName.setText(pet.getName());
        tvHealth.setText(pet.getStats().getHealth()+"");
        tvAttack.setText(pet.getStats().getAttack()+"");
        tvDefend.setText(pet.getStats().getDefense()+"");
        tvSpeed.setText(pet.getStats().getSpeed()+"");

    }
}
