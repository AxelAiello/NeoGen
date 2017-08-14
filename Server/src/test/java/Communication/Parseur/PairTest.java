package Communication.Parseur;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

/**
 * Created by Raphaël KUMAR on 12/06/17.
 */
class PairTest {
    Pair<String, Integer> pair;

    @BeforeEach
    void setUp() {
        pair = new Pair<>("A", 1);
    }

    @Test
    void getLeft() {
        assertEquals("A", pair.getLeft());
    }

    @Test
    void getRight() {
        assertEquals(1, pair.getRight().intValue());
    }

}