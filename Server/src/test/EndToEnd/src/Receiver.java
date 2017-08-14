

import java.io.IOException;
import java.io.InputStream;
import java.net.Socket;

/**
 * Created by Raphaël KUMAR on 29/05/17.
 */
public class Receiver {

    InputStream is;

    public Receiver(Socket socket) throws IOException {
        is = socket.getInputStream();
    }

    public String read() throws IOException {
        byte[] lenBytes = new byte[4];
        is.read(lenBytes, 0, 4);
        int len = (((lenBytes[3] & 0xff) << 24) | ((lenBytes[2] & 0xff) << 16) |
                ((lenBytes[1] & 0xff) << 8) | (lenBytes[0] & 0xff));
        byte[] receivedBytes = new byte[len];
        is.read(receivedBytes, 0, len);
        return new String(receivedBytes, 0, len);
    }
}
