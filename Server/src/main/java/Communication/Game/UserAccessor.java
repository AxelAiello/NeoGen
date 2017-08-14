package Communication.Game;

import Communication.Parseur.DataSerialiser;
import Communication.Parseur.Pair;
import Communication.Receiver;
import Communication.Sender;
import Entity.Deck;
import Entity.Monster;
import Entity.Player;
import Entity.User;

import org.json.simple.parser.JSONParser;
import org.json.simple.JSONObject;
import org.json.simple.parser.ParseException;

import javax.sound.midi.Soundbank;
import javax.xml.crypto.Data;
import java.io.IOException;
import java.net.Socket;

/**
 * Created by Raphaël KUMAR on 31/05/17.
 */
public class UserAccessor implements Runnable {

    private Socket player;

    Receiver receiver;
    Sender sender;


    ThreadGroup oneVOne = new ThreadGroup("1v1");

    public UserAccessor(Socket player) throws IOException {
        this.player = player;
        receiver = new Receiver(player);
        sender = new Sender(player);
    }

    @Override
    public void run() {
        DataSerialiser dataSerialiser = new DataSerialiser();
        try {
            System.out.println("Init connection");
            Pair<String, JSONObject> details = dataSerialiser.deserialize(receiver.read());
            System.out.println("Init end recieved Initialisation");
            System.out.println(details.getRight());

            User user = User.finder(details.getRight().get("Token").toString());


            System.out.println(dataSerialiser.generateMonsterList(user).toJSONString().length());
            sender.send(dataSerialiser.generateMonsterList(user).toJSONString());

            details = dataSerialiser.deserialize(receiver.read());

            Details.addWait(new Player(dataSerialiser.deserializePlayer(details.getRight()), player, oneVOne));

        } catch (IOException e) {
            e.printStackTrace();
        }

    }
}