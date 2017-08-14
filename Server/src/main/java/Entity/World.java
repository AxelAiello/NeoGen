package Entity;

import Entity.Card.ClimaticCard;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Raphaël KUMAR on 12/06/17.
 */
public class World {
    private Map<CaracteristicWorld, Integer> caracteristicParty;
    private int resourcesHerbivore = 1000000000;
    private int resourcesCarnivore = 100000;

    public World() {
        caracteristicParty = new HashMap<>();
        caracteristicParty.put(CaracteristicWorld.Atmosphere, 500);
        caracteristicParty.put(CaracteristicWorld.Temperature, 30);
        caracteristicParty.put(CaracteristicWorld.Precipitations, 45);
    }

    public World(Monster monster){
        caracteristicParty = new HashMap<>();
        caracteristicParty.put(CaracteristicWorld.Atmosphere, 500);
        caracteristicParty.put(CaracteristicWorld.Temperature, 30);
        caracteristicParty.put(CaracteristicWorld.Precipitations, 45);
    }



    public void alterWorld(ClimaticCard climaticCard){
        for (Map.Entry<CaracteristicWorld, Integer> entry : climaticCard.getCaracteristiques().entrySet())
        {
            caracteristicParty.put(entry.getKey(), entry.getValue());
        }
    }

    public Map<CaracteristicWorld, Integer> getCaracteristicParty(){
        return caracteristicParty;
    }

    public int getResourcesHerbivore() {
        return resourcesHerbivore;
    }

    public void setResourcesHerbivore(int resourcesHerbivore) {
        this.resourcesHerbivore = resourcesHerbivore;
    }

    public int getResourcesCarnivore() {
        return resourcesCarnivore;
    }

    public void setResourcesCarnivore(int resourcesCarnivore) {
        this.resourcesCarnivore = resourcesCarnivore;
    }
}
