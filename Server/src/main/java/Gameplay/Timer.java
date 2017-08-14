package Gameplay;

/**
 * Created by Raphaël KUMAR on 01/06/17.
 */
public class Timer {

    long start;
    long second;

    public Timer() {
    }

    public void start(long second) {
        this.second = second;
        this.start = System.currentTimeMillis();
    }

    public boolean isExpired() {
        return ((System.currentTimeMillis() - this.start)) > this.second*1000;
    }

}
