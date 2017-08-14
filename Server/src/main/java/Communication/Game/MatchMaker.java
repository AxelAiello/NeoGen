package Communication.Game;

import Entity.Player;
import Gameplay.OneVSOne.Engine1v1;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Raphaël KUMAR on 29/05/17.
 */
public class MatchMaker implements Runnable {


    @Override
    public void run() {
        Thread connections = new Thread(new ConnectPlayer());
        connections.start();
        while(true){
            List<Player> players1v1 = Details.getWait1v1();
            if (players1v1.size()>=2){
                Thread thread;
                if(Math.random() < 0.5){
                    thread =new Thread(players1v1.get(0).getMode(), new Engine1v1(players1v1.get(0), players1v1.get(1)));
                }
                else {
                    thread = new Thread(players1v1.get(0).getMode(), new Engine1v1(players1v1.get(1), players1v1.get(0)));
                }
                Details.addParty(thread);
                List<Player>players = new ArrayList<Player>(){{
                    add(players1v1.get(1));
                    add(players1v1.get(0));
                }};
                Details.removeWaiters(players);
                thread.start();
            }
        }
    }
}