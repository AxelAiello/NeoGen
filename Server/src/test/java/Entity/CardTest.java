package Entity;

import Entity.Card.ACard;
import Entity.Card.ClimaticCard;
import Entity.Card.PartMonsterCard;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;
/**
 * Created by Raphaël KUMAR on 12/06/17.
 */
class CardTest {
    ACard partCard;
    ACard climaticCard;
    @BeforeEach
    void setUp() {
        partCard = new PartMonsterCard();
        climaticCard = new ClimaticCard();
    }

    @Test
    void GenerateCost() {
        assertEquals(climaticCard.getCost(), partCard.getCost()+4);
    }
}
