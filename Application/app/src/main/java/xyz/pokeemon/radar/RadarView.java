package xyz.pokeemon.radar;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Point;
import android.graphics.RectF;
import android.graphics.SweepGradient;
import android.location.Location;
import android.os.Build;
import android.util.AttributeSet;
import android.view.View;

import androidx.annotation.RequiresApi;

/**
 * Radar content
 * This is a representation of a radar with different circles all around a point.
 * A line that turns represent the research.
 * <p>
 * RadarView extends View to create a new custom view.
 */
public class RadarView extends View {
    private final int DELAY_TIME_ACTUALISATION = 1000 / 60;
    private final float SWEEP_ANGLE = 0.15f;
    private final int CIRCLE_COUNT = 4;

    private boolean showCircles = true;

    private float rotation = 0;
    private Paint circlePaint = new Paint();
    private Paint sweepPaint = new Paint();

    //Delay for the appearance of coordinates
    android.os.Handler handler = new android.os.Handler();
    Runnable tick = new Runnable() {
        @Override
        public void run() {
            invalidate();
            handler.postDelayed(this, DELAY_TIME_ACTUALISATION);
        }
    };

    public RadarView(Context context) {
        this(context, null);
    }

    public RadarView(Context context, AttributeSet attrs) {
        this(context, attrs, 0);
    }


    /**
     * @param context
     * @param attrs
     * @param defStyleAttr Constructor, it will set the parameters of the radar design
     */
    public RadarView(Context context, AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);

        circlePaint.setColor(Color.GREEN);
        circlePaint.setStyle(Paint.Style.STROKE);
        circlePaint.setStrokeWidth(8.0F);
        circlePaint.setAlpha(255);

        circlePaint.setColor(Color.GREEN);

        int[] colors = {Color.TRANSPARENT, Color.GREEN};
        float[] positions = {0, SWEEP_ANGLE};
        SweepGradient gradient = new SweepGradient(0f, 0f, colors, positions);
        sweepPaint.setShader(gradient);

        startAnimation();
    }


    /**
     * Animate the radar line
     */
    public void startAnimation() {
        handler.removeCallbacks(tick);
        handler.post(tick);
    }


    /**
     * @param showCircles This method shows the radar circles on the fragment.
     */
    public void setShowCircles(boolean showCircles) {
        this.showCircles = showCircles;
    }


    private void drawCircles(Canvas canvas, int cx, int cy, int size) {
        for (int i = 0; i < CIRCLE_COUNT; i++) {
            float radius = (size / CIRCLE_COUNT) + ((size / CIRCLE_COUNT) * i);
            canvas.drawCircle(cx, cy, radius, circlePaint);
        }
    }

    private void drawSweep(Canvas canvas, int cx, int cy, float rotation, int size) {
        canvas.save();

        canvas.translate(cx, cy);
        canvas.rotate(rotation, 0.5f, 0.5f);
        canvas.scale(size, size);

        canvas.drawArc(new RectF(-1, -1, 1, 1), 0, 360 * SWEEP_ANGLE, true, sweepPaint);

        canvas.restore();
    }

    /**
     * @param canvas With the Canvas help, this method draws all the circles and the line of the radar.
     *               It also calculate the line rotation.
     */
    @Override
    protected void onDraw(Canvas canvas) {
        super.onDraw(canvas);

        int cx = getWidth() / 2;
        int cy = getHeight() / 2;
        int size = Math.min(getWidth(), getHeight()) / 2;

        if (showCircles) {
            drawCircles(canvas, cx, cy, size);
        }

        drawSweep(canvas, cx, cy, rotation, size);

        rotation += 1;
    }
}
