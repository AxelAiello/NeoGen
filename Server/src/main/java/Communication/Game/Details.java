package Communication.Game;

import Entity.Player;

import java.net.Socket;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Created by Raphaël KUMAR on 31/05/17.
 */
public class Details {

    static Map<Player, ThreadGroup> wait = new HashMap<>();
    static List<Thread> party = new ArrayList<>();


    public static Map<Player, ThreadGroup> getWait() {
        synchronized (wait) {return wait;}

    }

    public static void removeWaiters(List<Player> players) {
        synchronized (wait) {
            for (int i = 0; i <players.size() ; i++) {
                wait.remove(players.get(i));
            }
        }

    }

    public static List<Player> getWait1v1(){
        synchronized (wait){
            List<Player> players = new ArrayList<>();
            for (Map.Entry<Player, ThreadGroup> entry : wait.entrySet())
            {
                if(entry.getValue().getName().equals("1v1")){
                    players.add(entry.getKey());
                }
            }
            return players;
        }
    }


    public static void addWait(Player player) {
        synchronized (wait){
            Details.wait.put(player, player.getMode());
        }
    }

    public static List<Thread> getParty() {
        synchronized (party) {
            return party;
        }
    }

    public static void addParty(Thread party) {
        synchronized (party) {
            Details.party.add(party);
        }
    }
}
