package Component;

import Entity.CaracteristicGen;
import Entity.CaracteristicPhys;
import Entity.Monster;
import Entity.World;

import java.util.Map;

/**
 * Created by Raphaël KUMAR on 01/06/17.
 */
public class Mutator {

    double mutateur;

    public Mutator() {
        this.mutateur = 0.5;
    }
    public Monster naturalMutation(Monster monster, World world){
        if(Math.random() < mutateur){
            for (Map.Entry<CaracteristicPhys, Integer> entry : monster.getMapPhysical().entrySet())
            {
                entry.setValue(entry.getValue() +  (int)(Math.random() * 2));
            }
            for (Map.Entry<CaracteristicGen, Integer> entry : monster.getMapGenetics().entrySet())
            {
                entry.setValue(entry.getValue() +  (int)(Math.random() * 2));
            }
        }
        return monster;
    }

}
