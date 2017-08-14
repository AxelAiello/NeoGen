package Entity;

import Entity.Card.ACard;
import Entity.Card.ClimaticCard;
import Entity.Card.PartMonsterCard;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Raphaël KUMAR on 29/05/17.
 */
public class  User {

    private String username;
    private String password;
    private String token;

    List<Deck> decks;
    List<ACard> collection;
    List<Monster> monsters;


    private static List<User> bareUsers = new ArrayList<User>(){{
        add(new User("Baal","bAAL",
                new ArrayList<Deck>(){{
                    add(new Deck(Deck.bareDecks.get(0)));
                }},
                new ArrayList<ACard>(){{

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
                    add(PartMonsterCard.bareCards.get(31));
                    add(PartMonsterCard.bareCards.get(33));
                    add(PartMonsterCard.bareCards.get(35));
                    add(PartMonsterCard.bareCards.get(37));
                    add(PartMonsterCard.bareCards.get(39));
                    add(PartMonsterCard.bareCards.get(21));
                    add(PartMonsterCard.bareCards.get(23));
                    add(PartMonsterCard.bareCards.get(25));
                    add(PartMonsterCard.bareCards.get(27));
                    add(PartMonsterCard.bareCards.get(29));
                    add(ClimaticCard.bareCards.get(1));
                    add(ClimaticCard.bareCards.get(3));
                    add(ClimaticCard.bareCards.get(5));
                    add(ClimaticCard.bareCards.get(7));
                    add(ClimaticCard.bareCards.get(9));
                    add(ClimaticCard.bareCards.get(11));
                    add(ClimaticCard.bareCards.get(13));
                    add(ClimaticCard.bareCards.get(15));
                    add(ClimaticCard.bareCards.get(17));
                    add(ClimaticCard.bareCards.get(19));
                    add(ClimaticCard.bareCards.get(0));
                    add(ClimaticCard.bareCards.get(2));
                    add(ClimaticCard.bareCards.get(4));
                    add(ClimaticCard.bareCards.get(6));
                    add(ClimaticCard.bareCards.get(8));
                    add(ClimaticCard.bareCards.get(10));
                }},
                new ArrayList<Monster>(){{
                    add(new Monster(Monster.bareMonsters.get(0)));
                }}));
        add(new User("Enlil","eNLIL",
                new ArrayList<Deck>(){{
                    add(new Deck(Deck.bareDecks.get(1)));
                }},
                new ArrayList<ACard>(){{
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
                    add(PartMonsterCard.bareCards.get(32));
                    add(PartMonsterCard.bareCards.get(34));
                    add(PartMonsterCard.bareCards.get(36));
                    add(PartMonsterCard.bareCards.get(38));
                    add(PartMonsterCard.bareCards.get(40));
                    add(PartMonsterCard.bareCards.get(22));
                    add(PartMonsterCard.bareCards.get(24));
                    add(PartMonsterCard.bareCards.get(26));
                    add(PartMonsterCard.bareCards.get(28));
                    add(PartMonsterCard.bareCards.get(30));
                    add(ClimaticCard.bareCards.get(0));
                    add(ClimaticCard.bareCards.get(2));
                    add(ClimaticCard.bareCards.get(4));
                    add(ClimaticCard.bareCards.get(6));
                    add(ClimaticCard.bareCards.get(8));
                    add(ClimaticCard.bareCards.get(10));
                    add(ClimaticCard.bareCards.get(12));
                    add(ClimaticCard.bareCards.get(14));
                    add(ClimaticCard.bareCards.get(16));
                    add(ClimaticCard.bareCards.get(18));
                    add(ClimaticCard.bareCards.get(1));
                    add(ClimaticCard.bareCards.get(3));
                    add(ClimaticCard.bareCards.get(5));
                    add(ClimaticCard.bareCards.get(7));
                    add(ClimaticCard.bareCards.get(9));
                    add(ClimaticCard.bareCards.get(11));
                    add(ClimaticCard.bareCards.get(13));
                    add(ClimaticCard.bareCards.get(15));
                    add(ClimaticCard.bareCards.get(17));
                    add(ClimaticCard.bareCards.get(19));
                }},
                new ArrayList<Monster>(){{
                    add(new Monster(Monster.bareMonsters.get(1)));
                    add(new Monster(Monster.bareMonsters.get(0)));
                }}));
    }};


    public User(String username, String password, List<Deck> decks, List<ACard> collection, List<Monster> monsters) {
        this.username = username;
        this.password = password;
        this.decks = decks;
        this.collection = collection;
        this.monsters = monsters;
        this.token = username + "1234"; // Math.random();
    }

    public static User finder(String token){
        for (int i = 0; i < bareUsers.size(); i++) {
            if(bareUsers.get(i).getToken().equals(token)) {
                return bareUsers.get(i);
            }
        }
        return null;
    }

    public String getToken() {
        return token;
    }

    public String getUsername() {
        return username;
    }

    public List<Deck> getDecks() {
        return decks;
    }

    public List<ACard> getCollection() {
        return collection;
    }

    public List<Monster> getMonsters() {
        return monsters;
    }

    public void addMonster (Monster monster) {
      this.monsters.add(monster);
    }
}
