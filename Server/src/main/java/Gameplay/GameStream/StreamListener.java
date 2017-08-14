package Gameplay.GameStream;

import Communication.Receiver;
import Gameplay.OneVSOne.GameData;

import java.io.IOException;

/**
 * Created by Raphaël KUMAR on 30/05/17.
 */
public class StreamListener implements Runnable {

    Receiver receiver;
    GameData gameData;
    String data = "";
    String playerToken;
    public StreamListener(Receiver receiver, GameData gameData, String playerToken) {
        this.receiver = receiver;
        this.gameData = gameData;
        this.playerToken = playerToken;
    }

    @Override
    public void run() {
        while (!gameData.getEnd()) {
            try {
                data = receiver.read();
                gameData.pushRecieved(data,playerToken);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}
