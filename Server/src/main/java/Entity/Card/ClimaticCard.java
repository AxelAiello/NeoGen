package Entity.Card;


import Entity.CaracteristicWorld;

import java.io.Serializable;
import java.util.*;

/**
 * Created by Raphaël KUMAR on 30/05/17.
 */
public class ClimaticCard extends ACard {

    public static List<ACard> bareCards = new ArrayList<ACard>() {{
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Precipitations, 0);}},
                "Secheresse", "Assets/Resources/Images/Cartes_Climats/secheresse.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Temperature, 30);}},
                "Canicule", "Assets/Resources/Images/Cartes_Climats/canicule.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Temperature, 40);
            put(CaracteristicWorld.Precipitations, 0);}},
                "Desert", "Assets/Resources/Images/Cartes_Climats/desert.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Temperature, -15);}},
                "Vague de froid", "Assets/Resources/Images/Cartes_Climats/vague_froid.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Temperature, 5);}},
                "Hivers doux", "Assets/Resources/Images/Cartes_Climats/hivers_doux.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Precipitations, 100);}},
                "Inondation", "Assets/Resources/Images/Cartes_Climats/inondation.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Temperature, -40);}},
                "Glaciation", "Assets/Resources/Images/Cartes_Climats/glaciation.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Precipitations, 50);}},
                "Averse", "Assets/Resources/Images/Cartes_Climats/averse.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Temperature, 20);}},
                "Douceur", "Assets/Resources/Images/Cartes_Climats/douceur.jpg"));

        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Catastrophe, 50);}},
                "Tsunami", "Assets/Resources/Images/Cartes_Climats/tsunami.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Catastrophe, 30);}},
                "Cyclone", "Assets/Resources/Images/Cartes_Climats/cyclone.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Catastrophe, 20);}},
                "Incendie", "Assets/Resources/Images/Cartes_Climats/incendie.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Catastrophe, 10);}},
                "Seisme", "Assets/Resources/Images/Cartes_Climats/seisme.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Precipitations, 0);}},
                "Secheresse", "Assets/Resources/Images/Cartes_Climats/secheresse.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Temperature, 30);}},
                "Canicule", "Assets/Resources/Images/Cartes_Climats/canicule.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Temperature, 40);
            put(CaracteristicWorld.Precipitations, 0);}},
                "Desert", "Assets/Resources/Images/Cartes_Climats/desert.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Temperature, -15);}},
                "Vague de froid", "Assets/Resources/Images/Cartes_Climats/vague_froid.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Temperature, 5);}},
                "Hivers doux", "Assets/Resources/Images/Cartes_Climats/hivers_doux.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Precipitations, 100);}},
                "Inondation", "Assets/Resources/Images/Cartes_Climats/inondation.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Temperature, -40);}},
                "Glaciation", "Assets/Resources/Images/Cartes_Climats/glaciation.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Precipitations, 50);}},
                "Averse", "Assets/Resources/Images/Cartes_Climats/averse.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Temperature, 20);}},
                "Douceur", "Assets/Resources/Images/Cartes_Climats/douceur.jpg"));

        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Catastrophe, 50);}},
                "Tsunami", "Assets/Resources/Images/Cartes_Climats/tsunami.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Catastrophe, 30);}},
                "Cyclone", "Assets/Resources/Images/Cartes_Climats/cyclone.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Catastrophe, 20);}},
                "Incendie", "Assets/Resources/Images/Cartes_Climats/incendie.jpg"));
        add(new ClimaticCard(new HashMap<CaracteristicWorld, Integer>() {{
            put(CaracteristicWorld.Catastrophe, 10);}},
                "Seisme", "Assets/Resources/Images/Cartes_Climats/seisme.jpg"));
    }};

    private Map<CaracteristicWorld, Integer> caracteristiques;

    public Map<CaracteristicWorld, Integer> getCaracteristiques() {
        return caracteristiques;
    }

    public ClimaticCard(Map<CaracteristicWorld, Integer> map, String name, String image){
        super(name, image);
        caracteristiques = map;

        cost = 5;
    }

    public ClimaticCard() {
        super("Inconnu", "Inconnu");
        caracteristiques = new HashMap<>();
        caracteristiques.put(CaracteristicWorld.Temperature, 1);
        caracteristiques.put(CaracteristicWorld.Atmosphere, 1);

        cost = 5;
    }

    @Override
    public String getType() {
        return "CLIMATIC";
    }

}
