
import Communication.ConnetionManager;
import Communication.Game.MatchMaker;
import Communication.Profile.PlayerInventory;

import java.io.IOException;

/**
 * Created by Raphaël KUMAR on 29/05/17.
 */
public class Server {
    public static void main(String[] args) {
        try {
            ConnetionManager.getInstance();
        } catch (IOException e) {
            e.printStackTrace();
        }

        ThreadGroup tg = new ThreadGroup("Main");
        Thread main    = new Thread(tg, new PlayerInventory());
        Thread match   = new Thread(tg, new MatchMaker());

        main.start();
        match.start();
    }
}
