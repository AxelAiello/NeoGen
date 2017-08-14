package Communication.Parseur;

import Entity.*;
import Entity.Card.ACard;
import Entity.Card.ClimaticCard;
import Entity.Card.PartMonsterCard;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Created by Raphaël KUMAR on 01/06/17.
 */
public class DataSerialiser {



    public DataSerialiser(){

    }

    public Pair<String, JSONObject> deserialize(String data){
        JSONParser parser = new JSONParser();
        JSONObject json=null;
        try {
            json = (JSONObject) parser.parse(data);
        } catch (ParseException e) {
            e.printStackTrace();
        }
        return new Pair(json.get("Type").toString(), json.get("Details"));
    }


    public Player deserializePlayer(JSONObject details){
        User userTMP = User.finder(details.get("Token").toString());
        return new Player(userTMP,
                userTMP.getDecks().get(Integer.parseInt(details.get("Deck").toString())),
                userTMP.getMonsters().get(Integer.parseInt(details.get("Monster").toString())));
    }

    public Monster deserializeMonsterAdd(JSONObject details){
        Map<CaracteristicGen, Integer> mapGenetics = new HashMap<>();
        JSONArray arrayGenetics = (JSONArray) details.get("MapGenetics");
        for(int i = 0; i < arrayGenetics.size(); i++) {
            //mapGenetics.put(type, value);
        }
        Map<CaracteristicPhys, Integer> mapPhysical = new HashMap<>();
        JSONArray arrayPhysical = (JSONArray) details.get("MapPhysical");
        for(int i = 0; i < arrayPhysical.size(); i++) {
            //mapPhysical.put(type, value);
        }
        Monster m = new Monster(Integer.parseInt(details.get("Id").toString()), details.get("Name").toString(), details.get("Image").toString(), mapPhysical, mapGenetics);
        return m;
    }


    public List<Integer> deserializeInitialCards(JSONObject details){
        List<Integer> cards = new ArrayList<Integer>();
        JSONArray listCard = (JSONArray) details.get("Cards");
        for (int i = 0; i < listCard.size(); i++) {
            int value = Integer.parseInt(listCard.get(i).toString());
            cards.add(value);
        }
        return cards;
    }

    public Integer deserializePlayCard(JSONObject details){
        int i = Integer.parseInt(details.get("Card").toString());
        System.out.println("Card played" + i);
        return i;
    }








    public JSONObject generateRequette(String type, JSONObject data){
        JSONObject value = new JSONObject();
        value.put("Type", type);
        value.put("Details", data);
        return value;
    }

    private JSONArray generateHand(List<ACard> hand){
        JSONArray hander = new JSONArray();
        for (int i = 0; i < hand.size(); i++) {
            hander.add(generateCard(hand.get(i)));
        }
        return hander;
    }


    public JSONObject generateMonsterSetter( Player player, int time){
        JSONObject details = new JSONObject();
        details.put("Points", player.getPoints());
        details.put("Time", time);

        details.put("Hand", generateHand(player.getHand()));

        return generateRequette("MonsterSetter", details);
    }

    public JSONObject generateStart(Player player, Player opponent, int time){
        JSONObject details = new JSONObject();
        details.put("Points", player.getPoints());
        details.put("Time", time);
        details.put("Monster", generateMonster(player));
        details.put("Nbrcard", player.getSelectedDeck().size());
        JSONObject opponentJSON = new JSONObject();
        opponentJSON.put("Name", opponent.getPlayer().getUsername());
        opponentJSON.put("Points", opponent.getPoints());
        opponentJSON.put("Nbrcard", opponent.getSelectedDeck().size());
        opponentJSON.put("Monster", generateMonster(opponent));
        details.put("Hand", generateHand(player.getHand()));
        details.put("Opponent", opponentJSON);

        return generateRequette("Start", details);
    }

    public JSONObject generateStats(Player player, Player opponent){
        JSONObject details = new JSONObject();
        details.put("PersonalPoints", player.getPoints());
        details.put("OpponentPoints", opponent.getPoints());
        return generateRequette("Stats", details);
    }



    private JSONObject generateCard(ACard c){
        JSONObject card = new JSONObject();
        card.put("Id", c.getId());
        card.put("Name", c.getName());
        card.put("Image", c.getImage());
        card.put("Nature", c.getType());
        card.put("Cost", c.getCost());

        if(c.getType().equals("CLIMATIC")){
            card.put("Description", generateClimaticCard((ClimaticCard) c));
        }
        else {
            card.put("Description", generatePartMonsterCard((PartMonsterCard) c));
        }
        return card;
    }

    private JSONArray generatePartMonsterCard(PartMonsterCard c){
        JSONArray description = new JSONArray();
        for (Map.Entry<CaracteristicGen, Integer> entry : c.getCaracteristiques().entrySet())
        {
            JSONObject caract = new JSONObject();
            caract.put("Type", entry.getKey());
            caract.put("Modificator", entry.getValue());
            description.add(caract);
        }
        return description;
    }

    private JSONArray generateClimaticCard(ClimaticCard c){
        JSONArray description = new JSONArray();
        for (Map.Entry<CaracteristicWorld, Integer> entry : c.getCaracteristiques().entrySet())
        {
            JSONObject caract = new JSONObject();
            caract.put("Type", entry.getKey());
            caract.put("Modificator", entry.getValue());
            description.add(caract);
        }
        return description;
    }


    public JSONObject generateDraw(ACard c){
        JSONObject details = new JSONObject();
        details.put("Card", generateCard(c));

        return generateRequette("Draw", details);
    }

    public JSONObject generateEndDetails(boolean win, int gold, List<ACard> cards, int xp, Monster player, Monster opponent){
        JSONObject data = new JSONObject();
        data.put("Result", (win)?"Victoire":"Defaite");
        JSONObject reward = new JSONObject();
        reward.put("XP", xp);
        reward.put("PO", gold);
        JSONArray rewardCards = generateHand(cards);
        reward.put("Cards", rewardCards);
        data.put("Reward", reward);
        JSONArray personalScore = new JSONArray();
        for (Map.Entry<CaracteristicPhys, Integer> entry : player.getMapPhysical().entrySet())
        {
            JSONObject caract = new JSONObject();
            caract.put("Type", entry.getKey());
            caract.put("Points", entry.getValue());
            personalScore.add(caract);
        }
        for (Map.Entry<CaracteristicGen, Integer> entry : player.getMapGenetics().entrySet())
        {
            JSONObject caract = new JSONObject();
            caract.put("Type", entry.getKey());
            caract.put("Points", entry.getValue());
            personalScore.add(caract);
        }

        JSONArray opponentScore = new JSONArray();
        for (Map.Entry<CaracteristicPhys, Integer> entry : opponent.getMapPhysical().entrySet())
        {
            JSONObject caract = new JSONObject();
            caract.put("Type", entry.getKey());
            caract.put("Points", entry.getValue());
            opponentScore.add(caract);
        }
        for (Map.Entry<CaracteristicGen, Integer> entry : opponent.getMapGenetics().entrySet())
        {
            JSONObject caract = new JSONObject();
            caract.put("Type", entry.getKey());
            caract.put("Points", entry.getValue());
            opponentScore.add(caract);
        }

        data.put("PersonalScore", personalScore);
        data.put("OpponentScore", opponentScore);
        return generateRequette("End", data);
    }

    public JSONObject generateDeckList(User user){
        JSONArray decks = new JSONArray();
        JSONObject data = new JSONObject();
        for (int i = 0; i < user.getDecks().size(); i++){
            JSONObject deck = new JSONObject();
            deck.put("ID", i);
            deck.put("Name", user.getDecks().get(i).getName());
            deck.put("Number", user.getDecks().get(i).size());
            decks.add(deck);
        }
        data.put("Decks", decks);
        return generateRequette("DeckList", data);
    }

    private JSONObject generateMonster(Player player) {
        JSONObject monster = new JSONObject();
        monster.put("ID",  player.getSelectedMonster().getId());
        monster.put("Name",  player.getSelectedMonster().getName());
        monster.put("Image",  player.getSelectedMonster().getImage());
        JSONArray caracteristicPhys = new JSONArray();
        for (Map.Entry<CaracteristicPhys, Integer> entry :player.getSelectedMonster().getMapPhysical().entrySet())
        {
            JSONObject caracteristic = new JSONObject();
            caracteristic.put("Type", entry.getKey());
            caracteristic.put("Value", entry.getValue());
            caracteristicPhys.add(caracteristic);
        }
        monster.put("MapPhysical", caracteristicPhys);
        JSONArray caracteristicGens = new JSONArray();
        for (Map.Entry<CaracteristicGen, Integer> entry : player.getSelectedMonster().getMapGenetics().entrySet())
        {
            JSONObject caracteristic = new JSONObject();
            caracteristic.put("Type", entry.getKey());
            caracteristic.put("Value", entry.getValue());
            caracteristicGens.add(caracteristic);
        }
        monster.put("MapGenetics", caracteristicGens);
        return monster;
    }

    public JSONObject generateMonsterList(User user){
        JSONArray monsters = new JSONArray();
        JSONObject data = new JSONObject();
        for (int i = 0; i < user.getMonsters().size(); i++) {
            JSONObject monster = new JSONObject();
            monster.put("ID",  user.getMonsters().get(i).getId());
            monster.put("Name",  user.getMonsters().get(i).getName());
            monster.put("Image", user.getMonsters().get(i).getImage());
            JSONArray caracteristicPhys = new JSONArray();
            for (Map.Entry<CaracteristicPhys, Integer> entry : user.getMonsters().get(i).getMapPhysical().entrySet())
            {
                JSONObject caracteristic = new JSONObject();
                caracteristic.put("Type", entry.getKey());
                caracteristic.put("Value", entry.getValue());
                caracteristicPhys.add(caracteristic);
            }
            monster.put("MapPhysical", caracteristicPhys);
            JSONArray caracteristicGens = new JSONArray();
            for (Map.Entry<CaracteristicGen, Integer> entry : user.getMonsters().get(i).getMapGenetics().entrySet())
            {
                JSONObject caracteristic = new JSONObject();
                caracteristic.put("Type", entry.getKey());
                caracteristic.put("Value", entry.getValue());
                caracteristicGens.add(caracteristic);
            }
            monster.put("MapGenetics", caracteristicGens);
            monsters.add(monster);
        }
        data.put("Monsters", monsters);

        return generateRequette("MonsterList", data);
    }


    /*
    public JSONObject generateNaturalEvent(String Description, String Element, int oldVal, int newVal){
        JSONObject event = new JSONObject();

        return event;
    }

    "Description : 'blabla' "
    "Element : 'nom'"
    "Old : 3"
    "New : 5"
     */

    public JSONObject generateCardEvent(ACard card, int oldVal, int newVal){
        JSONObject event = new JSONObject();
        JSONObject cardUsed = new JSONObject();


        return generateRequette("Event", event);
    }

    public JSONObject generateWorld(Player player, Player opponent){
        List<Player> players = new ArrayList<Player>(){{
            add(player);
            add(opponent);
        }};
        JSONObject world = new JSONObject();
        JSONObject map = new JSONObject();
        JSONArray monsters = new JSONArray();

        for (int i = 0; i < players.size(); i++) {
            monsters.add(generateMonster(players.get(i)));
        }


        world.put("Map", map);
        world.put("Monsters", monsters);
        return generateRequette("World", world);
    }
    
}
