package Entity.Card;

import Entity.CaracteristicGen;

import java.io.Serializable;
import java.lang.reflect.AccessibleObject;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * Created by Raphaël KUMAR on 30/05/17.
 */
public class PartMonsterCard extends ACard {

    public static List<ACard> bareCards = new ArrayList<ACard>() {{
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Temperature_Ideale, 0);}},
                "Fourrure", "Assets/Resources/Images/Cartes_Genetiques/fourrure.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Temperature_Ideale, -10);}},
                "Ecailles", "Assets/Resources/Images/Cartes_Genetiques/ecailles.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Robustesse, 3);}},
                "Carapace", "Assets/Resources/Images/Cartes_Genetiques/carapace.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 4);}},
                "Griffes", "Assets/Resources/Images/Cartes_Genetiques/griffes.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 5);}},
                "Corne", "Assets/Resources/Images/Cartes_Genetiques/corne.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Temperature_Ideale, 25);}},
                "Fourrure Epaisse", "Assets/Resources/Images/Cartes_Genetiques/fourrure_epaisse.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Temperature_Ideale, -30);}},
                "Peau", "Assets/Resources/Images/Cartes_Genetiques/peau.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 3);}},
                "Crocs", "Assets/Resources/Images/Cartes_Genetiques/crocs.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Robustesse, 5);}},
                "Carapace Fortifiee", "Assets/Resources/Images/Cartes_Genetiques/carapace_fortifiee.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 2);}},
                "Petites Griffes", "Assets/Resources/Images/Cartes_Genetiques/griffes_petites.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 3);}},
                "Petites Cornes", "Assets/Resources/Images/Cartes_Genetiques/cornes_petites.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 4);}},
                "Dents Affutees", "Assets/Resources/Images/Cartes_Genetiques/dents_affutees.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 1);}},
                "Camouflage", "Assets/Resources/Images/Cartes_Genetiques/camouflage.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 3);}},
                "Tentacules", "Assets/Resources/Images/Cartes_Genetiques/tentacules.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 3);}},
                "Ailes Legeres", "Assets/Resources/Images/Cartes_Genetiques/ailes_legeres.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 5);}},
                "Ailes", "Assets/Resources/Images/Cartes_Genetiques/ailes.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 6);}},
                "Ailes Nocturnes", "Assets/Resources/Images/Cartes_Genetiques/ailes_nocturnes.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 3);
            put(CaracteristicGen.Robustesse, 3);}},
                "Pics", "Assets/Resources/Images/Cartes_Genetiques/pics.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 4);}},
                "Dard", "Assets/Resources/Images/Cartes_Genetiques/dard.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 2);}},
                "Pinces", "Assets/Resources/Images/Cartes_Genetiques/pince.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 1);}},
                "Queue", "Assets/Resources/Images/Cartes_Genetiques/queue.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 2);
            put(CaracteristicGen.Temperature_Ideale, 18);}},
                "Plumes", "Assets/Resources/Images/Cartes_Genetiques/plumes.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Temperature_Ideale, 0);}},
                "Fourrure", "Assets/Resources/Images/Cartes_Genetiques/fourrure.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Temperature_Ideale, -10);}},
                "Ecailles", "Assets/Resources/Images/Cartes_Genetiques/ecailles.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Robustesse, 3);}},
                "Carapace", "Assets/Resources/Images/Cartes_Genetiques/carapace.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 4);}},
                "Griffes", "Assets/Resources/Images/Cartes_Genetiques/griffes.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 5);}},
                "Corne", "Assets/Resources/Images/Cartes_Genetiques/corne.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Temperature_Ideale, 25);}},
                "Fourrure Epaisse", "Assets/Resources/Images/Cartes_Genetiques/fourrure_epaisse.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Temperature_Ideale, -30);}},
                "Peau", "Assets/Resources/Images/Cartes_Genetiques/peau.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 3);}},
                "Crocs", "Assets/Resources/Images/Cartes_Genetiques/crocs.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Robustesse, 5);}},
                "Carapace Fortifiee", "Assets/Resources/Images/Cartes_Genetiques/carapace_fortifiee.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 2);}},
                "Petites Griffes", "Assets/Resources/Images/Cartes_Genetiques/griffes_petites.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 3);}},
                "Petites Cornes", "Assets/Resources/Images/Cartes_Genetiques/cornes_petites.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 4);}},
                "Dents Affutees", "Assets/Resources/Images/Cartes_Genetiques/dents_affutees.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 1);}},
                "Camouflage", "Assets/Resources/Images/Cartes_Genetiques/camouflage.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 3);}},
                "Tentacules", "Assets/Resources/Images/Cartes_Genetiques/tentacules.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 3);}},
                "Ailes Legeres", "Assets/Resources/Images/Cartes_Genetiques/ailes_legeres.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 5);}},
                "Ailes", "Assets/Resources/Images/Cartes_Genetiques/ailes.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 6);}},
                "Ailes Nocturnes", "Assets/Resources/Images/Cartes_Genetiques/ailes_nocturnes.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 3);
            put(CaracteristicGen.Robustesse, 3);}},
                "Pics", "Assets/Resources/Images/Cartes_Genetiques/pics.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 4);}},
                "Dard", "Assets/Resources/Images/Cartes_Genetiques/dard.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 2);}},
                "Pinces", "Assets/Resources/Images/Cartes_Genetiques/pince.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 1);}},
                "Queue", "Assets/Resources/Images/Cartes_Genetiques/queue.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 2);
            put(CaracteristicGen.Temperature_Ideale, 18);}},
                "Plumes", "Assets/Resources/Images/Cartes_Genetiques/plumes.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Temperature_Ideale, 0);}},
                "Fourrure", "Assets/Resources/Images/Cartes_Genetiques/fourrure.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Temperature_Ideale, -10);}},
                "Ecailles", "Assets/Resources/Images/Cartes_Genetiques/ecailles.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Robustesse, 3);}},
                "Carapace", "Assets/Resources/Images/Cartes_Genetiques/carapace.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 4);}},
                "Griffes", "Assets/Resources/Images/Cartes_Genetiques/griffes.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 5);}},
                "Corne", "Assets/Resources/Images/Cartes_Genetiques/corne.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Temperature_Ideale, 25);}},
                "Fourrure Epaisse", "Assets/Resources/Images/Cartes_Genetiques/fourrure_epaisse.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Temperature_Ideale, -30);}},
                "Peau", "Assets/Resources/Images/Cartes_Genetiques/peau.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 3);}},
                "Crocs", "Assets/Resources/Images/Cartes_Genetiques/crocs.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Robustesse, 5);}},
                "Carapace Fortifiee", "Assets/Resources/Images/Cartes_Genetiques/carapace_fortifiee.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 2);}},
                "Petites Griffes", "Assets/Resources/Images/Cartes_Genetiques/griffes_petites.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 3);}},
                "Petites Cornes", "Assets/Resources/Images/Cartes_Genetiques/cornes_petites.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 4);}},
                "Dents Affutees", "Assets/Resources/Images/Cartes_Genetiques/dents_affutees.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 1);}},
                "Camouflage", "Assets/Resources/Images/Cartes_Genetiques/camouflage.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 3);}},
                "Tentacules", "Assets/Resources/Images/Cartes_Genetiques/tentacules.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 3);}},
                "Ailes Legeres", "Assets/Resources/Images/Cartes_Genetiques/ailes_legeres.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 5);}},
                "Ailes", "Assets/Resources/Images/Cartes_Genetiques/ailes.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 6);}},
                "Ailes Nocturnes", "Assets/Resources/Images/Cartes_Genetiques/ailes_nocturnes.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 3);
            put(CaracteristicGen.Robustesse, 3);}},
                "Pics", "Assets/Resources/Images/Cartes_Genetiques/pics.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 4);}},
                "Dard", "Assets/Resources/Images/Cartes_Genetiques/dard.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Degats, 2);}},
                "Pinces", "Assets/Resources/Images/Cartes_Genetiques/pince.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 1);}},
                "Queue", "Assets/Resources/Images/Cartes_Genetiques/queue.jpg"));
        add(new PartMonsterCard(new HashMap<CaracteristicGen, Integer>() {{
            put(CaracteristicGen.Vitesse, 2);
            put(CaracteristicGen.Temperature_Ideale, 18);}},
                "Plumes", "Assets/Resources/Images/Cartes_Genetiques/plumes.jpg"));
    }};

    private Map<CaracteristicGen, Integer> caracteristiques;

    public PartMonsterCard(Map<CaracteristicGen, Integer> map, String name, String image) {
        super(name, image);
        caracteristiques = map;

        int power = 0;
        for(Map.Entry<CaracteristicGen, Integer> entry : caracteristiques.entrySet()){
            if(entry.getKey() == CaracteristicGen.Temperature_Ideale) {
                power = power + 5;
            } else {
                power = power + entry.getValue();
            }
        }
        cost = (int) power/caracteristiques.size();
    }

    public PartMonsterCard() {
        super("Inconnu", "Inconnu");
        caracteristiques = new HashMap<>();
        caracteristiques.put(CaracteristicGen.Force, 1);

        int power = 0;
        for(Map.Entry<CaracteristicGen, Integer> entry : caracteristiques.entrySet()){
            if(entry.getKey() == CaracteristicGen.Temperature_Ideale) {
                power = power + 5;
            } else {
                power = power + entry.getValue();
            }
        }
        cost = (int) power/caracteristiques.size();
    }

    public PartMonsterCard(PartMonsterCard toCopy){
        super(toCopy.name, toCopy.image);
        cost = toCopy.cost;
        caracteristiques = toCopy.caracteristiques;
    }

    public Map<CaracteristicGen, Integer> getCaracteristiques() {
        return caracteristiques;
    }

    @Override
    public String getType() {
        return "GENETIC";
    }

}
