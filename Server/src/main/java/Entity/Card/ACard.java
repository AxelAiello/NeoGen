package Entity.Card;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Raphaël KUMAR on 29/05/17.
 */
public abstract class ACard {
    static int ID = 0;

    int id;
    String name;
    String image;
    int cost;

    public ACard(String name, String image) {
        this.id = ID;
        ID++;
        this.name = name;
        this.image = image;
    }

    public int getCost() {return cost;}
    public int getId() {return id;}
    public String getName() {return name;}
    public String getImage() {return image;}
    public abstract String getType();

}
