package Entity;

import Entity.Card.ACard;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

/**
 * Created by Raphaël KUMAR on 12/06/17.
 */
class UserTest {

    User user;

    @BeforeEach
    void setUp() {
        user = User.finder("Baal1234");
    }

    @Test
    void testDeckCardInAlbum(){
        Deck userDeck = user.getDecks().get(0);
        List<ACard> userCollection = user.getCollection();
        assertTrue(userCollection.containsAll(userDeck.getTheDeck()));
    }

    @Test
    void testDeckCardNotInAlbum(){
        Deck userDeck = user.getDecks().get(0);
        List<ACard> userCollection = user.getCollection();
        assertFalse(userCollection.containsAll(Deck.bareDecks.get(1).getTheDeck()));
    }

}