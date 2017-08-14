package Gameplay.OneVSOne;

import Communication.Parseur.DataSerialiser;
import Communication.Parseur.Pair;
import Communication.Receiver;
import Communication.Sender;
import Component.Mutator;
import Component.Population;
import Entity.CaracteristicGen;
import Entity.CaracteristicPhys;
import Entity.Card.ACard;
import Entity.Player;
import Gameplay.GameStream.StreamListener;
import Gameplay.GameStream.StreamSender;
import Gameplay.Timer;


import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

/**
 * Created by Raphaël KUMAR on 29/05/17.
 */
public class Engine1v1 implements Runnable {

    Thread playerHostlst;
    Thread playerHostsnd;
    Thread playerChalengerlst;
    Thread playerChalengersnd;
    ThreadGroup tg;
    private GameData gameData;
    DataSerialiser dataSerialiser;
    Mutator mutator;


    public Engine1v1(Player playerChalenger, Player playerHost) {
        // Iinitialisation connexion des threads
        dataSerialiser = new DataSerialiser();
        gameData = new GameData(playerChalenger, playerHost);
        mutator = new Mutator();
        this.tg =  new ThreadGroup("1 vs 1");
        try {
            Receiver chalengerReceiver = new Receiver(playerChalenger.getPlayerSocket());
            Sender chalengerSender = new Sender(playerChalenger.getPlayerSocket());

            this.playerChalengerlst = new Thread(tg, new StreamListener(chalengerReceiver, gameData, playerChalenger.getPlayer().getToken()));
            this.playerChalengersnd = new Thread(tg, new StreamSender(chalengerSender, gameData, playerChalenger.getPlayer().getToken()));
        } catch (IOException e) {
            System.out.println("problem connection with player 1");
            e.printStackTrace();
        }
        try {
            Receiver hostReceiver = new Receiver(playerHost.getPlayerSocket());
            Sender hostSender = new Sender(playerHost.getPlayerSocket());

            this.playerHostlst = new Thread(tg, new StreamListener(hostReceiver, gameData, playerHost.getPlayer().getToken()));
            this.playerHostsnd = new Thread(tg, new StreamSender(hostSender, gameData, playerHost.getPlayer().getToken()));
        } catch (IOException e) {
            System.out.println("problem connection with player 2");
            e.printStackTrace();
        }
    }

    @Override
    public void run() {
        System.out.println("game launched");
        playerHostsnd.start();
        playerHostlst.start();
        playerChalengersnd.start();
        playerChalengerlst.start();
        Timer timer = new Timer();
        Timer timerPoints = new Timer();

        int whaitForPlayer = 2;

        // Envoie le JSON pour MonsterSetter
        int timeValue = 60;
        gameData.pushToSend(dataSerialiser.generateMonsterSetter(gameData.playerHost, timeValue).toJSONString(), gameData.playerHost.getPlayer().getToken());
        gameData.pushToSend(dataSerialiser.generateMonsterSetter(gameData.playerChalenger, timeValue).toJSONString(), gameData.playerChalenger.getPlayer().getToken());

        System.out.println("monsterSetter");
        // Tant que le temps du MonsterSetter n'est pas expiré
        timer.start(timeValue);
        while (!timer.isExpired() && whaitForPlayer > 0){
            // Récupère l'action possible d'un joueur
            Pair<String, String> value = gameData.pullRecieved();
            // Vérifie si il y a eu l'action
            if(!value.getRight().equals("")){
                whaitForPlayer--;
                System.out.println("Initial Cartes recu");
                //Si player 1
                if(value.getRight().equals(gameData.playerChalenger.getPlayer().getToken())){
                    List<Integer> cards = dataSerialiser.deserializeInitialCards(dataSerialiser.deserialize(value.getLeft()).getRight());
                    List<ACard> usedCard = new ArrayList<ACard>();
                    // Parse les cartes pour dire qu'elles sont utilisées
                    for (int i = 0; i < cards.size() ; i++) {
                        usedCard.add(gameData.playerChalenger.removeCardToHand(cards.get(i)));
                    }
                    System.out.println();
                    gameData.playerChalenger.getSelectedMonster().setEffectives(usedCard);
                }
                // Si player 2
                else {
                    List<Integer> cards = dataSerialiser.deserializeInitialCards(dataSerialiser.deserialize(value.getLeft()).getRight());
                    List<ACard> usedCard = new ArrayList<ACard>();
                    // Parse les cartes pour dire qu'elles sont utilisées
                    for (int i = 0; i < cards.size() ; i++) {
                        usedCard.add(gameData.playerHost.removeCardToHand(cards.get(i)));
                    }
                    System.out.println();
                    gameData.playerHost.getSelectedMonster().setEffectives(usedCard);
                }
            }
        }
        System.out.println("start");
        // Variables pour le Start
        timeValue = 60;
        int points = 4;
        gameData.playerHost.setPoints(points);
        gameData.playerChalenger.setPoints(points);
        // On remet les cartes dans le deck et retire aléatoirement 5 cartes
        for (int i = 0; i < gameData.playerHost.getHand().size() ; i++) {
            gameData.playerHost.getSelectedDeck().getTheDeck().add(gameData.playerHost.getHand().get(i));
        }
        for (int i = 0; i < gameData.playerChalenger.getHand().size() ; i++) {
            gameData.playerChalenger.getSelectedDeck().getTheDeck().add(gameData.playerChalenger.getHand().get(i));
        }
        gameData.playerHost.setHand(gameData.playerHost.getSelectedDeck().createRandomHand(6));
        gameData.playerChalenger.setHand(gameData.playerChalenger.getSelectedDeck().createRandomHand(6));

        // Envoie le PartieStart
        gameData.pushToSend(dataSerialiser.generateStart(gameData.playerHost, gameData.playerChalenger, timeValue).toJSONString(), gameData.playerHost.getPlayer().getToken());
        gameData.pushToSend(dataSerialiser.generateStart(gameData.playerChalenger, gameData.playerHost, timeValue).toJSONString(), gameData.playerChalenger.getPlayer().getToken());

        int i = 0;
        int timeToAddPoint = 5;
        timerPoints.start(timeToAddPoint);
        // time start 60s
        timer.start(timeValue);
        boolean updated = false;

        while (!timer.isExpired()){

            // S'il faut rajouter des points
            if(timerPoints.isExpired()) {
                gameData.playerHost.setPopulation(Population.computeGeneration(gameData.playerHost, gameData.playerChalenger, 1000000));
                gameData.playerChalenger.setPopulation(Population.computeGeneration(gameData.playerChalenger, gameData.playerHost, 1000000));
                updated = true;
                // Mutation aléatoire
                mutator.naturalMutation(gameData.playerHost.getSelectedMonster(),gameData.world);
                mutator.naturalMutation(gameData.playerChalenger.getSelectedMonster(), gameData.world);

                System.out.println(i);
                timerPoints.start(timeToAddPoint);
                gameData.playerHost.increasePoints();
                gameData.playerChalenger.increasePoints();
                // Envoie de stats
            }

            // Récupère l'action possible d'un joueur
            Pair<String, String> value = gameData.pullRecieved();
            // Vérifie si il y a eu l'action "PlayCard"
            if(!value.getRight().equals("")) {
                updated = true;
                System.out.println("trolololo");
                //Quel joueur ?
                if(value.getRight().equals(gameData.playerChalenger.getPlayer().getToken())){
                    int idCard = dataSerialiser.deserializePlayCard(dataSerialiser.deserialize(value.getLeft()).getRight());
                    ACard usedCard = null;
                    // Recherche la carte utilisée et l'enlève de la main
                    usedCard = gameData.playerChalenger.removeCardToHand(idCard);
                    // On enlève les points utilisés
                    gameData.playerChalenger.decreasePoints(usedCard.getCost());
                    // On rajoute la caractéristique sur le monstre /!\ ne rajoute que la carte par les caractéristiques !!
                    gameData.playerChalenger.getSelectedMonster().addEffective(usedCard);
                    // On pioche
                    if(gameData.playerChalenger.getSelectedDeck().size()> 0){
                        ACard c = gameData.playerChalenger.getSelectedDeck().chooseRandomCard();
                        gameData.playerChalenger.addCardToHand(c);
                        gameData.pushToSend(dataSerialiser.generateDraw(c).toJSONString(), gameData.playerChalenger.getPlayer().getToken());
                    }
                    // Envoyer à l'autre
                }
                // Si player 2
                else {
                    int idCard = dataSerialiser.deserializePlayCard(dataSerialiser.deserialize(value.getLeft()).getRight());
                    ACard usedCard = null;
                    // Recherche la carte utilisée et l'enlève de la main
                    usedCard = gameData.playerHost.removeCardToHand(idCard);
                    // On enlève les points utilisés
                    gameData.playerHost.decreasePoints(usedCard.getCost());
                    // On rajoute la caractéristique sur le monstre /!\ ne rajoute que la carte par les caractéristiques !!
                    gameData.playerHost.getSelectedMonster().addEffective(usedCard);
                    // On pioche
                    if(gameData.playerHost.getSelectedDeck().size() > 0) {
                        ACard c = gameData.playerHost.getSelectedDeck().chooseRandomCard();
                        gameData.playerHost.addCardToHand(c);
                        gameData.pushToSend(dataSerialiser.generateDraw(c).toJSONString(), gameData.playerHost.getPlayer().getToken());
                    }
                    // Envoyer à l'autre
                }
                // Envoie de stats
            }
            if(updated){
                gameData.pushToSend(dataSerialiser.generateStats(gameData.playerHost, gameData.playerChalenger).toJSONString(), gameData.playerHost.getPlayer().getToken());
                gameData.pushToSend(dataSerialiser.generateStats(gameData.playerChalenger, gameData.playerHost).toJSONString(), gameData.playerChalenger.getPlayer().getToken());

                gameData.pushToSend(dataSerialiser.generateWorld(gameData.playerHost, gameData.playerChalenger).toJSONString(), gameData.playerHost.getPlayer().getToken());
                gameData.pushToSend(dataSerialiser.generateWorld(gameData.playerChalenger, gameData.playerHost).toJSONString(), gameData.playerChalenger.getPlayer().getToken());
                updated = false;
            }
            i++;
        }

        gameData.setEnd();
        try {
            System.out.println("Join playerHostsnd");
            playerHostsnd.join();
            System.out.println("Join playerChalengersnd");
            playerChalengersnd.join();
            System.out.println("Join playerHostlst");
            playerHostlst.join();
            System.out.println("Join playerChalengerlst");
            playerChalengerlst.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        System.out.println("End Game");
    }
}
