package xyz.pokeemon.radar.animations;

import android.view.View;
import android.view.animation.AlphaAnimation;
import android.view.animation.Animation;

/**
 * This is a concrete class.
 * It groups the animations that can be applied on a view.
 */
public class AnimationEffects{
    private final int BLINKING_SPEED = 400;

    /**
     * @param v get the view on which the blink animation is applied.
     */
    public void blinkAnimation(View v){
        Animation anim = new AlphaAnimation(0.0f, 1.0f);
        anim.setDuration(50);
        anim.setStartOffset(BLINKING_SPEED);
        anim.setRepeatMode(Animation.REVERSE);
        anim.setRepeatCount(Animation.INFINITE);
        v.startAnimation(anim);
    }
}
