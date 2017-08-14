package Communication.Profile;

import Communication.Parseur.DataSerialiser;
import Communication.Parseur.Pair;
import Communication.Receiver;
import Entity.Monster;
import Entity.User;
//import org.apache.logging.log4j.LogManager;
//import org.apache.logging.log4j.Logger;
import org.json.simple.JSONObject;


import java.io.IOException;
import java.net.Socket;
import java.util.HashMap;
import java.util.Map;

/**
 * @author Zineb El HAOUARI
 */
public class Profile implements Runnable {
  //private static Logger logger = LogManager.getLogger(Profile.class)

  private Socket player;
  Receiver receiver;

  public Profile(Socket player) throws IOException {
    this.player = player;
    receiver = new Receiver(player);
  }


  @Override
  public void run() {

    DataSerialiser dataSerialiser = new DataSerialiser();
    try{
      Pair<String,JSONObject> details = dataSerialiser.deserialize(receiver.read());

      User user = User.finder(details.getRight().get("Token").toString());
      System.out.println(details.getRight().get("Token").toString());
      Map<String,String> map = new HashMap<>();
      map.put("Monster",details.getRight().get("Monster").toString());
      JSONObject monster = new JSONObject(map);

      Monster newMonster
        = dataSerialiser.deserializeMonsterAdd(monster);
      user.addMonster(newMonster);

    }catch (IOException e){
      //TODO
      //logger.error("IOException while deserialize");
      e.printStackTrace();
    }catch(NullPointerException e){
      e.printStackTrace();
      //logger.error("Nullpointerxception while deserialize");
    }

  }
}
