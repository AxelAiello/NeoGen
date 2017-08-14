import java.io.IOException;
import java.net.Socket;

/**
 * Created by KUMAR Raphaël on 15/06/17.
 */
public class Main {

    public static void main(String[] args) throws IOException {

        Socket p1 = null;
        Socket p2 = null;
        try {
            p1 = new Socket("127.0.0.1", 8888);
            p2 = new Socket("127.0.0.1", 8888);

            Receiver p1is = new Receiver(p1);
            Receiver p2is = new Receiver(p2);
            Sender p1os = new Sender(p1);
            Sender p2os = new Sender(p2);

            p1os.send("{\"Type\":\"InitialisationUser\",\"Details\":{\"Token\":\"Enlil1234\",\"Match\":\"1v1\"}}");
            p2os.send("{\"Type\":\"InitialisationUser\",\"Details\":{\"Token\":\"Baal1234\",\"Match\":\"1v1\"}}");
            p1is.read();
            p2is.read();
            p2os.send("{\"Type\":\"InitialisationMonster\",\"Details\":{\"Token\":\"Baal1234\",\"Match\":\"1v1\",\"Monster\":0,\"Deck\":0}}");
            p1os.send("{\"Type\":\"InitialisationMonster\",\"Details\":{\"Token\":\"Enlil1234\",\"Match\":\"1v1\",\"Monster\":0,\"Deck\":0}}");
            p1is.read();
            p2is.read();
            p1os.send("{\"Type\":\"InitialCards\",\"Details\":{\"Cards\":[]}}");
            p2os.send("{\"Type\":\"InitialCards\",\"Details\":{\"Cards\":[]}}");
            boolean one = true;
            boolean two = true;
            while (true){
                if(two){
                    if(p2.isConnected() && p2is.read().contains("Type\":\"End")){
                        two = false;
                        System.out.println("End   ");
                        p2.close();
                    }
                }
                if(one){
                    if(p1.isConnected()&& p1is.read().contains("Type\":\"End")){
                        one = false;
                        System.out.println("End   ");
                        p1.close();
                    }
                }
                if(!one && !two)break;
            }

        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            p1.close();
            p2.close();
        }

    }
}
