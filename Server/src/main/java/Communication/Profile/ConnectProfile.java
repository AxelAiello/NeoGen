package Communication.Profile;

import Communication.ConnetionManager;

import java.io.IOException;

/**
 * @author Zineb El HAOUARI
 */
public class ConnectProfile implements Runnable {
  @Override
  public void run() {
    ThreadGroup usersInfo = new ThreadGroup("UsersInfo");

    while(true){
      try{
        Thread profil = new Thread(usersInfo,new Profile(ConnetionManager.getInstance().personalSocket.accept()));
        profil.start();
      }catch (IOException e){
        e.printStackTrace();
      }
    }
  }
}
