package Entity;

import Entity.Card.ACard;

import java.net.Socket;
import java.util.List;

/**
 * Created by Raphaël KUMAR on 30/05/17.
 */
public class Player {
    private User player;
    private Socket playerSocket;

    private ThreadGroup mode;

    private Deck selectedDeck;
    private Monster selectedMonster;
    private int population;
    private List<ACard> hand;
    private int points;


    public Player(User player, Deck selectedDeck, Monster selectedMonster){
        this.player = player;
        this.selectedMonster = new Monster(selectedMonster);
        this.selectedDeck = new Deck(selectedDeck);
        this.points = 4;
        this.hand = this.selectedDeck.createRandomHand(5);
        this.population = 10000;
    }

    public Player(Player player, Socket playerSocket, ThreadGroup mode) {
        this.player = player.getPlayer();
        this.selectedDeck = new Deck(player.getSelectedDeck());
        this.selectedMonster =  new Monster(player.getSelectedMonster());
        this.playerSocket = playerSocket;
        this.mode = mode;
        this.points = player.getPoints();
        this.hand = player.getHand();
        this.population = 10000;
    }

    public Deck getSelectedDeck() {
        return selectedDeck;
    }

    public Monster getSelectedMonster() {
        return selectedMonster;
    }

    public ThreadGroup getMode() {
        return mode;
    }

    public Socket getPlayerSocket() {
        return playerSocket;
    }

    public User getPlayer() {
        return player;
    }

    public List<ACard> getHand() {
        return hand;
    }

    public void setHand(List<ACard> l) {
        this.hand = l;
    }

    public int getPoints() {
        return points;
    }

    public void setPoints(int p) {
        this.points = p;
    }

    public void increasePoints() {
        if(this.points < 10) {
            this.points++;
        }
    }

    public void decreasePoints(int p) {
        if(this.points - p >= 0) {
            this.points = this.points - p;
        } else {
            this.points = 0;
        }
    }

    public void addCardToHand(ACard c) {
        hand.add(c);
    }

    public ACard removeCardToHand(int id) {
        ACard cardSelected = null;
        for(int i = 0; i < hand.size(); i++) {
            if(hand.get(i).getId() == id ) {
                cardSelected = hand.get(i);
                hand.remove(hand.get(i));
            }
        }
        return cardSelected;
    }

    public int score(){
        int score = selectedMonster.valueAnnalyses();
        return score;
    }

    public int getPopulation() {
        return population;
    }

    public void setPopulation(int population) {
        this.population = population;
    }
}

