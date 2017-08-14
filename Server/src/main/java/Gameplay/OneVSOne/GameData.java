package Gameplay.OneVSOne;

import Communication.Parseur.Pair;
import Entity.Monster;
import Entity.Player;
import Entity.World;
import com.sun.org.apache.xerces.internal.xs.StringList;


import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Created by Raphaël KUMAR on 30/05/17.
 */
public class GameData {
    List<Pair<String, String>> recieved;
    List<Pair<String, String>> toSend;
    final Player playerHost;
    final Player playerChalenger;
    Boolean end;
    Integer hostToSend;
    Integer chalengerToSend;
    World world;


    public GameData(Player playerChalenger, Player playerHost) {
        this.recieved = new ArrayList<Pair<String, String>>();
        this.toSend = new ArrayList<Pair<String, String>>();
        this.playerChalenger = playerChalenger;
        this.playerHost = playerHost;
        end = false;
        hostToSend = 0;
        chalengerToSend = 0;
        world = new World(playerHost.getSelectedMonster());
    }

    public void setEnd() {
        synchronized (end) {
            this.end = true;
        }
    }

    public Boolean getEnd(){
        synchronized (end){
            return end;
        }
    }

    public Pair<String, String> pullRecieved() {
        synchronized (recieved) {
            if(recieved.size() > 0){
                Pair<String, String> pair = recieved.get(0);
                recieved.remove(0);
                return pair;
            }
            return new Pair<>("", "");
        }
    }

    public void pushRecieved(String recieve, String token) {
        synchronized (recieved){
            this.recieved.add(new Pair<>(recieve, token ));
        }
    }

    public String pullToSend(String token) {
        synchronized (toSend) {
            if(toSend.size() == 0){
                return "";
            }
            for (int i = 0; i < toSend.size(); i++) {
                System.out.println(toSend.size());
                System.out.println(toSend.get(i).toString());
                System.out.println(toSend.get(i).getLeft());
                if(toSend.get(i).getRight().equals(token)){
                    String value = toSend.get(i).getLeft();
                    toSend.remove(i);
                    decrementToSend(token);
                    return value;
                }
            }
            return "";
        }
    }

    public void pushToSend(String toSend, String token) {
        incrementToSend(token);
        synchronized (toSend) {
            this.toSend.add(new Pair<>(toSend, token));
        }
    }

    public String winer(){
        synchronized (end){
            return (playerChalenger.getSelectedMonster().valueAnnalyses() >= playerHost.getSelectedMonster().valueAnnalyses())? playerChalenger.getPlayer().getToken(): playerHost.getPlayer().getToken();
        }
    }


    public Monster personalMonster(String token) {
        synchronized (end) {
            if (playerHost.getPlayer().getToken().equals(token)) {
                return playerHost.getSelectedMonster();
            } else return playerChalenger.getSelectedMonster();
        }
    }

    public Monster opponentMonster(String token) {
        synchronized (end) {
            if (!playerHost.getPlayer().getToken().equals(token)) {
                System.out.println(playerHost.getPlayer().getUsername());
                System.out.println(playerChalenger.score());
                return playerHost.getSelectedMonster();
            } else return playerChalenger.getSelectedMonster();
        }
    }

    public int getToSend(String token) {
        if(token.equals(playerChalenger.getPlayer().getToken())){
            synchronized (this.chalengerToSend) {
                return chalengerToSend;
            }
        }
        else {
            synchronized (this.hostToSend) {
                return hostToSend;
            }
        }
    }

    private void incrementToSend(String token){
        if(token.equals(playerChalenger.getPlayer().getToken())){
            synchronized (this.chalengerToSend) {
                this.chalengerToSend ++;
            }
        }
        else {
            synchronized (this.hostToSend) {
                this.hostToSend ++;
            }
        }
    }

    private void decrementToSend(String token) {
        if(token.equals(playerChalenger.getPlayer().getToken())){
            synchronized (this.chalengerToSend) {
                this.chalengerToSend --;
            }
        }
        else {
            synchronized (this.hostToSend) {
                this.hostToSend --;
            }
        }
    }
}
