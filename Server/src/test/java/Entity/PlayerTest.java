package Entity;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import javax.jws.soap.SOAPBinding;

import static org.junit.jupiter.api.Assertions.*;

/**
 * Created by Raphaël KUMAR on 12/06/17.
 */
class PlayerTest {
    Player player;
    @BeforeEach
    void setUp() {
        User user = User.finder("Baal1234");
        player = new Player(user, user.getDecks().get(0), user.getMonsters().get(0));
    }

    @Test
    void increasePoints() {
        assertEquals(4, player.getPoints());
        player.increasePoints();
        assertEquals(5, player.getPoints());
    }
    @Test
    void increaseOverflowPoints() {
        player.setPoints(10);
        assertEquals(10, player.getPoints());
        player.increasePoints();
        assertEquals(10, player.getPoints());
    }
    @Test
    void decreasePoints() {
        assertEquals(4, player.getPoints());
        player.decreasePoints(2);
        assertEquals(2, player.getPoints());
    }

    @Test
    void decreaseOverFlowPoints() {
        assertEquals(4, player.getPoints());
        player.decreasePoints(5);
        assertEquals(0, player.getPoints());
    }

    @Test
    void addCardToHand() {

    }

    @Test
    void removeCardToHand() {
        assertEquals(5, player.getHand().size());
        assertEquals(player.getHand().get(0) ,player.removeCardToHand(player.getHand().get(0).getId()));
        assertEquals(4, player.getHand().size());
    }

    @Test
    void score() {
        assertEquals(152243, player.score());
    }

}