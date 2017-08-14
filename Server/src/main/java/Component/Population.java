package Component;

import Entity.CaracteristicGen;
import Entity.CaracteristicPhys;
import Entity.Player;

import java.util.Map;

/**
 * Created by Raphaël KUMAR on 14/06/17.
 */
public class Population {


    static public int computeGenerationHerbivore(Player pop1, Player pop2, int res){
        int compute = 0;
        double deathproportion = 0.1;
        compute = pop1.getPopulation();
        Map<CaracteristicPhys, Integer> caracpop1 =  pop1.getSelectedMonster().getMapPhysical();
        int Fertilite = ((caracpop1.get(CaracteristicPhys.Fertilite)*compute/2)*(caracpop1.get(CaracteristicPhys.EsperanceDeVie)-caracpop1.get(CaracteristicPhys.MaturiteSexuelle))/caracpop1.get(CaracteristicPhys.EsperanceDeVie));
        int death = (int) (compute*deathproportion + ((compute*caracpop1.get(CaracteristicPhys.Nutrition))/res));
        compute += Fertilite - death;
        return compute;
    }



    static public int Fertilite(Player monster1, int ressources){
        double value = 0;
        Map<CaracteristicPhys, Integer> caracpop1 = monster1.getSelectedMonster().getMapPhysical();
        value = caracpop1.get(CaracteristicPhys.EsperanceDeVie) - caracpop1.get(CaracteristicPhys.MaturiteSexuelle);
        value /=  (2*caracpop1.get(CaracteristicPhys.EsperanceDeVie));
        value *= caracpop1.get(CaracteristicPhys.Fertilite);
        double neddedRessources = ressources - (monster1.getPopulation()*caracpop1.get(CaracteristicPhys.Nutrition));
        neddedRessources /= (monster1.getPopulation()*caracpop1.get(CaracteristicPhys.Nutrition));
        if (neddedRessources > 0){
            return (int) value;
        }
        else {
            neddedRessources = 1 + neddedRessources;
            value *= neddedRessources;
            return (int) value;
        }
    }


    static public int computeGeneration(Player monster1, Player monster2, int resources){
        Map<CaracteristicPhys, Integer>caracphy1 = monster1.getSelectedMonster().getMapPhysical();
        Map<CaracteristicPhys, Integer>caracphy2 = monster2.getSelectedMonster().getMapPhysical();
        double nextGeneration = monster1.getPoints() + Fertilite(monster1,resources)*monster1.getPopulation();
        System.out.println(nextGeneration);
        nextGeneration -= monster1.getPopulation()*12/caracphy1.get(CaracteristicPhys.EsperanceDeVie);
        System.out.println(nextGeneration);
        double heaten = computeEaten(monster1,monster2);
        if(heaten > 0) nextGeneration -= (1-computeEaten(monster1,monster2))*(monster2.getPopulation()*caracphy2.get(CaracteristicPhys.Nutrition)/caracphy1.get(CaracteristicPhys.Poids));
        System.out.println(nextGeneration);
        return (int) nextGeneration;
    }

    static public double computeEaten(Player pop1, Player pop2){
        Map<CaracteristicPhys, Integer>caracphy1 = pop1.getSelectedMonster().getMapPhysical();
        Map<CaracteristicGen, Integer>caracgen1 = pop1.getSelectedMonster().getMapGenetics();
        Map<CaracteristicPhys, Integer>caracphy2 = pop2.getSelectedMonster().getMapPhysical();
        Map<CaracteristicGen, Integer>caracgen2 = pop2.getSelectedMonster().getMapGenetics();

        double lol = (((((((caracgen2.get(CaracteristicGen.Force)+caracgen2.get(CaracteristicGen.Degats))+caracphy2.get(CaracteristicPhys.Taille)+caracphy2.get(CaracteristicPhys.Poids))))
                -((caracgen1.get(CaracteristicGen.Force)+caracgen1.get(CaracteristicGen.Robustesse))+caracphy1.get(CaracteristicPhys.Taille)+caracphy1.get(CaracteristicPhys.Poids)))
                ))/(double)(400);
        return lol;
    }

}
