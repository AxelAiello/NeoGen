package Gameplay;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

/**
 * Created by Raphaël KUMAR on 12/06/17.
 */
class TimerTest {
    @Test
    void isExpired() {
        Timer timer = new Timer();
        timer.start(100);
        assertFalse(timer.isExpired());
        timer.start(-1);
        assertTrue(timer.isExpired());

    }


}