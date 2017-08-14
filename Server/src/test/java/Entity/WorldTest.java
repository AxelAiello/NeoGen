package Entity;

import Entity.Card.ClimaticCard;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

/**
 * Created by Raphaël KUMAR on 13/06/17.
 */
class WorldTest {
    World newWorld;
    @BeforeEach
    void setUp() {
        newWorld = new World();
    }

    @Test
    void alterWorld() {
        assertEquals(30, newWorld.getCaracteristicParty().get(CaracteristicWorld.Temperature).intValue());
        newWorld.alterWorld((ClimaticCard) ClimaticCard.bareCards.get(1));
        assertEquals(60, newWorld.getCaracteristicParty().get(CaracteristicWorld.Temperature).intValue());
    }

}