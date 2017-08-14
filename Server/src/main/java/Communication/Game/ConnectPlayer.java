package Communication.Game;

import Communication.ConnetionManager;

import java.io.IOException;

/**
 * Created by Raphaël KUMAR on 31/05/17.
 */
public class ConnectPlayer implements Runnable {
    @Override
    public void run() {
        ThreadGroup finder = new ThreadGroup("finder");

        while(true){
            try {
                Thread findUser = new Thread(finder, new UserAccessor(ConnetionManager.getInstance().matchSocket.accept()));
                findUser.start();

            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}
