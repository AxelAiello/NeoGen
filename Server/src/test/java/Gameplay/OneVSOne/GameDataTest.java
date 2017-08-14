package Gameplay.OneVSOne;

import Communication.Parseur.Pair;
import Entity.Monster;
import Entity.Player;
import Entity.User;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

/**
 * Created by Raphaël KUMAR on 12/06/17.
 */
class GameDataTest {
    GameData gameData;

    @BeforeEach
    void setUp() {
        User user1 = User.finder("Baal1234");
        User user2 = User.finder("Enlil1234");
        Player one = new Player(user1, user1.getDecks().get(0), user1.getMonsters().get(0));
        Player two = new Player(user2, user2.getDecks().get(0), user2.getMonsters().get(0));
        gameData = new GameData(one,two);
    }

    @Test
    void pullRecieved() {
        assertEquals("",gameData.pullRecieved().getLeft());
        gameData.pushRecieved("Data", "Baal1234");
        assertEquals("Data", gameData.pullRecieved().getLeft());
    }


    @Test
    void pullToSend() {
        assertEquals(0, gameData.getToSend("Baal1234"));
        assertEquals("", gameData.pullToSend("Baal1234"));
        gameData.pushToSend("Data", "Baal1234");
        assertEquals(0, gameData.getToSend("Enlil1234"));
        assertEquals(1, gameData.getToSend("Baal1234"));
        assertEquals("", gameData.pullToSend("Enlil1234"));
        assertEquals("Data", gameData.pullToSend("Baal1234"));
    }


    @Test
    void winer() {
        assertEquals("Baal1234",gameData.winer());
    }

    @Test
    void personalMonster() {
        assertEquals(Monster.bareMonsters.get(0).getId(), gameData.personalMonster("Baal1234").getId());
    }

    @Test
    void opponentMonster() {
        assertEquals(Monster.bareMonsters.get(0).getId(), gameData.opponentMonster("Enlil1234").getId());
    }


}