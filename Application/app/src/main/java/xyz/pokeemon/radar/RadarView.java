package xyz.pokeemon.radar;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Point;
import android.location.Location;
import android.util.AttributeSet;
import android.view.View;

/**
 *  Radar content
 *  This is a representation of a radar with different circles all around a point.
 *  A line that turns represent the research.
 *
 *  RadarView extends View to create a new custom view.
 */
public class RadarView extends View {
    private Location loca;
    private final int POINT_ARRAY_SIZE = 25;
    private final int DELAY_TIME_ACTUALISATION = 1/1000000;
    private boolean showCircles = true;

    float alpha = 0;
    Point latestPoint[] = new Point[POINT_ARRAY_SIZE];
    Paint latestPaint[] = new Paint[POINT_ARRAY_SIZE];

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
     * @param defStyleAttr
     *
     *  Constructor, it will set the parameters of the radar design
     */
    public RadarView(Context context, AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
        //drawing parameters
        Paint paint = new Paint();
        paint.setColor(Color.GREEN);
        paint.setStyle(Paint.Style.STROKE);
        paint.setStrokeWidth(4.0F);
        paint.setAlpha(0);
        int alpha_step = 255 / POINT_ARRAY_SIZE;
        for (int i=0; i < latestPaint.length; i++) {
            latestPaint[i] = new Paint(paint);
            latestPaint[i].setAlpha(255 - (i* alpha_step));
        }
    }


    /**
     *  Animate the radar line
     */
    public void startAnimation() {
        handler.removeCallbacks(tick);
        handler.post(tick);
    }


    /**
     * @param showCircles
     *
     * This method shows the radar circles on the fragment.
     */
    public void setShowCircles(boolean showCircles) { this.showCircles = showCircles; }


    /**
     * @param canvas
     *
     *  With the Canvas help, this method draws all the circles and the line of the radar.
     *  It also calculate the line rotation.
     */
    @Override
    protected void onDraw(Canvas canvas) {
        super.onDraw(canvas);
        //Dimension of the circle + radius
        int r = Math.min(getWidth(), getHeight());
        int i = r / 2;
        int j = i - 1;
        Paint localPaint = latestPaint[0];

        //Draw circles with different size
        if (showCircles) {
            canvas.drawCircle(i, i, j, localPaint);
            canvas.drawCircle(i, i, j, localPaint);
            canvas.drawCircle(i, i, j * 3 / 4, localPaint);
            canvas.drawCircle(i, i, j >> 1, localPaint);
            canvas.drawCircle(i, i, j >> 2, localPaint);
        }

        //Line rotation
        alpha -= 0.5;
        if (alpha < -360) alpha = 0;
        double angle = Math.toRadians(alpha);
        int offsetX =  (int) (i + (float)(i * Math.cos(angle)));
        int offsetY = (int) (i - (float)(i * Math.sin(angle)));

        latestPoint[0]= new Point(offsetX, offsetY);
        for (int x=POINT_ARRAY_SIZE-1; x > 0; x--) {
            latestPoint[x] = latestPoint[x-1];
        }

        //Draw line of the radar
        for (int x = 0; x < POINT_ARRAY_SIZE; x++) {
            Point point = latestPoint[x];
            if (point != null) {
                canvas.drawLine(i, i, point.x, point.y, latestPaint[x]);
            }
        }
    }
}
