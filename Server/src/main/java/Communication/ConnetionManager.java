package Communication;

import java.io.IOException;
import java.net.ServerSocket;

/**
 * Created by Raphaël KUMAR on 29/05/17.
 */
public class ConnetionManager {

    private static ConnetionManager INSTANCE = null;
    public ServerSocket personalSocket = null;
    public ServerSocket matchSocket = null;

    private ConnetionManager() throws IOException {
        personalSocket  = new ServerSocket(9999, 10);
        matchSocket     = new ServerSocket(8888, 10);
    }

    public static ConnetionManager getInstance() throws IOException {
        if (INSTANCE == null)INSTANCE = new ConnetionManager();
        return INSTANCE;
    }

    public static void stop() throws IOException {
        INSTANCE.personalSocket.close();
        INSTANCE.matchSocket.close();
        INSTANCE = null;
    }


}
