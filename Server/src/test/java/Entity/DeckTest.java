package Entity;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

/**
 * Created by Raphaël KUMAR on 12/06/17.
 */
class DeckTest {


    Deck deck;

    @BeforeEach
    void setUp() {
        deck = new Deck(Deck.bareDecks.get(0));
    }

    @Test
    void chooseRandomCard() {
        assertEquals(30, deck.size());
        deck.chooseRandomCard();
        assertEquals(29, deck.size());
        assertEquals(30, Deck.bareDecks.get(0).size());
    }

    @Test
    void createRandomHand() {
        assertEquals(30, deck.size());
        deck.createRandomHand(5);
        assertEquals(25, deck.size());
    }

}