package Gameplay.GameStream;


import Communication.Parseur.DataSerialiser;
import Communication.Sender;
import Entity.Card.ACard;
import Entity.Card.ClimaticCard;
import Entity.Card.PartMonsterCard;
import Entity.User;
import Gameplay.OneVSOne.GameData;

import javax.xml.crypto.Data;
import java.io.IOException;
import java.util.ArrayList;

/**
 * Created by Raphaël KUMAR on 30/05/17.
 */
public class StreamSender implements Runnable {


    Sender sender;
    GameData gameData;
    String playerToken;
    DataSerialiser dataSerialiser = new DataSerialiser();
    public StreamSender(Sender sender, GameData gameData, String playerToken) {
        this.sender = sender;
        this.gameData = gameData;
        this.playerToken = playerToken;
    }

    @Override
    public void run() {
        while(!gameData.getEnd()){
            try {
                if(gameData.getToSend(playerToken) > 0){
                    String data = gameData.pullToSend(playerToken);

                    if(!data.equals("")) {
                        sender.send(data);
                    }
                    System.out.println("end send data for " + playerToken);
                }
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        if(gameData.winer().equals(playerToken)){
            try {
                sender.send(dataSerialiser.generateEndDetails(true, 100, PartMonsterCard.bareCards, 1000, gameData.personalMonster(playerToken), gameData.opponentMonster(playerToken)).toJSONString());
            } catch (IOException e) {
                e.printStackTrace();
            }
        }else{
            try {
                sender.send(dataSerialiser.generateEndDetails(false, 10, PartMonsterCard.bareCards, 10, gameData.personalMonster(playerToken), gameData.opponentMonster(playerToken)).toJSONString());
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}
