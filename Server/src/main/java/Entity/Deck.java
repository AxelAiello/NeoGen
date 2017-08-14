package Entity;

import Entity.Card.ACard;
import Entity.Card.ClimaticCard;
import Entity.Card.PartMonsterCard;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Raphaël KUMAR on 29/05/17.
 */
public class Deck {
    List<ACard> theDeck;
    String name;

    public static List<Deck> bareDecks = new ArrayList<Deck>(){{
       add(new Deck(new ArrayList<ACard>(){{
           add(PartMonsterCard.bareCards.get(0));
           add(PartMonsterCard.bareCards.get(2));
           add(PartMonsterCard.bareCards.get(4));
           add(PartMonsterCard.bareCards.get(6));
           add(PartMonsterCard.bareCards.get(8));
           add(PartMonsterCard.bareCards.get(10));
           add(PartMonsterCard.bareCards.get(12));
           add(PartMonsterCard.bareCards.get(14));
           add(PartMonsterCard.bareCards.get(16));
           add(PartMonsterCard.bareCards.get(18));
           add(PartMonsterCard.bareCards.get(20));

           add(PartMonsterCard.bareCards.get(21));
           add(PartMonsterCard.bareCards.get(23));
           add(PartMonsterCard.bareCards.get(25));
           add(PartMonsterCard.bareCards.get(27));
           add(PartMonsterCard.bareCards.get(29));
           add(PartMonsterCard.bareCards.get(31));
           add(PartMonsterCard.bareCards.get(33));
           add(PartMonsterCard.bareCards.get(35));
           add(PartMonsterCard.bareCards.get(37));
           add(PartMonsterCard.bareCards.get(39));

           add(ClimaticCard.bareCards.get(0));
           add(ClimaticCard.bareCards.get(1));
           add(ClimaticCard.bareCards.get(2));
           add(ClimaticCard.bareCards.get(3));
           add(ClimaticCard.bareCards.get(4));
           add(ClimaticCard.bareCards.get(5));
           add(ClimaticCard.bareCards.get(6));
           add(ClimaticCard.bareCards.get(7));
           add(ClimaticCard.bareCards.get(8));
       }}, "deckA"));
        add(new Deck(new ArrayList<ACard>(){{
            add(PartMonsterCard.bareCards.get(1));
            add(PartMonsterCard.bareCards.get(3));
            add(PartMonsterCard.bareCards.get(5));
            add(PartMonsterCard.bareCards.get(7));
            add(PartMonsterCard.bareCards.get(9));
            add(PartMonsterCard.bareCards.get(11));
            add(PartMonsterCard.bareCards.get(13));
            add(PartMonsterCard.bareCards.get(15));
            add(PartMonsterCard.bareCards.get(17));
            add(PartMonsterCard.bareCards.get(19));
            add(PartMonsterCard.bareCards.get(21));

            add(PartMonsterCard.bareCards.get(22));
            add(PartMonsterCard.bareCards.get(24));
            add(PartMonsterCard.bareCards.get(26));
            add(PartMonsterCard.bareCards.get(28));
            add(PartMonsterCard.bareCards.get(30));
            add(PartMonsterCard.bareCards.get(32));
            add(PartMonsterCard.bareCards.get(34));
            add(PartMonsterCard.bareCards.get(36));
            add(PartMonsterCard.bareCards.get(38));
            add(PartMonsterCard.bareCards.get(40));

            add(ClimaticCard.bareCards.get(0));
            add(ClimaticCard.bareCards.get(1));
            add(ClimaticCard.bareCards.get(2));
            add(ClimaticCard.bareCards.get(3));
            add(ClimaticCard.bareCards.get(4));
            add(ClimaticCard.bareCards.get(5));
            add(ClimaticCard.bareCards.get(6));
            add(ClimaticCard.bareCards.get(7));
            add(ClimaticCard.bareCards.get(8));
        }}, "deckB"));
    }};

    public Deck(Deck toCopy){
        theDeck = new ArrayList<>(toCopy.theDeck);
        name = toCopy.name;
    }

    public Deck(List<ACard> theDeck){
        this.theDeck = theDeck;
        this.name = "unnamed";
    }

    public Deck(List<ACard> theDeck, String name) {
        this.theDeck = theDeck;
        this.name = name;
    }

    public Deck() {
        this.theDeck = new ArrayList<ACard>();
    }

    public ACard getCard(int id){
        return theDeck.get(id);
    }

    public int size(){
        return theDeck.size();
    }

    public String getName() {
        return name;
    }

    public List<ACard> getTheDeck() {
        return theDeck;
    }

    public ACard chooseRandomCard() {
        int i = (int)(Math.random() * (theDeck.size() - 1));
        ACard c = theDeck.remove(i);
        return c;
    }

    public List<ACard> createRandomHand(int nbrCard) {
        List<ACard> hand = new ArrayList<>();
        for (int i = 0; i < nbrCard; i++) {
            hand.add(chooseRandomCard());
        }
        return hand;
    }
}

