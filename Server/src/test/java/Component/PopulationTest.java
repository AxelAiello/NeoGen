package Component;

import Entity.Player;
import Entity.User;
import Gameplay.OneVSOne.GameData;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Disabled;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

/**
 * Created by Raphaël KUMAR on 14/06/17.
 */
class PopulationTest {


    GameData gameData;
    Player player1;
    Player player2;
    @BeforeEach
    void setUp() {
        player1 = new Player(User.finder("Baal1234"), User.finder("Baal1234").getDecks().get(0), User.finder("Baal1234").getMonsters().get(0));
        player2 = new Player(User.finder("Enlil1234"), User.finder("Enlil1234").getDecks().get(0), User.finder("Enlil1234").getMonsters().get(0));
        gameData = new GameData(player1,player2);
    }

    @Disabled
    @Test
    void computeGenerationHerbivore() {

        assertEquals(100, Population.computeGenerationHerbivore(player1, player2, 10000));
    }


    @Test
    void computeEaten() {
        assertEquals(15.2175, Population.computeEaten(player1, player2));
    }

    @Test
    void computeGeneration() {
        assertEquals(425418, Population.computeGeneration(player1,player2, 1000000));
    }
    @Test
    void Fertilite() {
        assertEquals(9, Population.Fertilite(player1, 1000000000));
    }


}