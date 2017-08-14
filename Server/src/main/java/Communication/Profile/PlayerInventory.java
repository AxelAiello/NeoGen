package Communication.Profile;

import Communication.Sender;
import Entity.Card.PartMonsterCard;

import javax.smartcardio.CardTerminal;

/**
 * Created by Raphaël KUMAR on 29/05/17.
 */

/**
 * For now, since we don't have the login feature,
 * and we're not about to add it, we will make one
 * same inventory for every player.
 * This inventory will include monsters and cards and everything.
 * This was needed especially for the feature of creating monsters,
 * adding them to the inventories.
 */
public class PlayerInventory implements Runnable {
    @Override
    public void run() {
      Thread connections = new Thread(new ConnectProfile());
      connections.start();



    }
}
