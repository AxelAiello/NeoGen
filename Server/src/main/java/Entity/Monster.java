package Entity;


import Entity.Card.ACard;
import Entity.Card.PartMonsterCard;


import java.util.*;

/**
 * Created by Raphaël KUMAR on 29/05/17.
 */
public class Monster {
    public static List<Monster> bareMonsters = new ArrayList<Monster>(){{
        add(new Monster(0,
                "Lapin",
                "Assets/Resources/Images/Creatures/lapin.jpg",
                new HashMap<CaracteristicPhys, Integer>(){{

                    put(CaracteristicPhys.Taille, 40);
                    put(CaracteristicPhys.Poids, 2000);
                    put(CaracteristicPhys.Nutrition, 150000);
                    put(CaracteristicPhys.Fertilite, 30);
                    put(CaracteristicPhys.EsperanceDeVie, 108);
                    put(CaracteristicPhys.MaturiteSexuelle, 6);
                }},
                new HashMap<CaracteristicGen, Integer>(){{
                    put(CaracteristicGen.Vitesse, 38);
                    put(CaracteristicGen.Degats, 2);
                    put(CaracteristicGen.Force, 2);
                    put(CaracteristicGen.Robustesse, 2);
                    put(CaracteristicGen.Temperature_Ideale, 15);
                }}
        ));
        add(new Monster(1,
                "Serpent",
                "Assets/Resources/Images/Creatures/serpent.jpg",
                new HashMap<CaracteristicPhys, Integer>(){{
                    put(CaracteristicPhys.Taille, 120);
                    put(CaracteristicPhys.Poids, 8000);
                    put(CaracteristicPhys.Nutrition, 6000);
                    put(CaracteristicPhys.Fertilite, 12);
                    put(CaracteristicPhys.EsperanceDeVie, 120);
                    put(CaracteristicPhys.MaturiteSexuelle, 36);
                }},
                new HashMap<CaracteristicGen, Integer>(){{
                    put(CaracteristicGen.Vitesse, 15);
                    put(CaracteristicGen.Degats, 6);
                    put(CaracteristicGen.Force, 5);
                    put(CaracteristicGen.Robustesse, 3);
                    put(CaracteristicGen.Temperature_Ideale, 25);
                }}
        ));
        add(new Monster(2,
                "Renard",
                "Assets/Resources/Images/Creatures/renard.jpg",
                new HashMap<CaracteristicPhys, Integer>(){{
                    put(CaracteristicPhys.Taille, 90);
                    put(CaracteristicPhys.Poids, 7000);
                    put(CaracteristicPhys.Nutrition, 180000);
                    put(CaracteristicPhys.Fertilite, 10);
                    put(CaracteristicPhys.EsperanceDeVie, 120);
                    put(CaracteristicPhys.MaturiteSexuelle, 10);
                }},
                new HashMap<CaracteristicGen, Integer>(){{
                    put(CaracteristicGen.Vitesse, 50);
                    put(CaracteristicGen.Degats, 5);
                    put(CaracteristicGen.Force, 5);
                    put(CaracteristicGen.Robustesse, 5);
                    put(CaracteristicGen.Temperature_Ideale, 20);
                }}
        ));
    }};

    private int id;
    private String name;
    private String image;
    private Map<CaracteristicGen, Integer> mapGenetics;
    private Map<CaracteristicPhys, Integer> mapPhysical;
    private Map<CaracteristicWorld, Integer> mapEnvPropice;
    private List<ACard> effectives;

    public Monster(int id, String name, String image, Map<CaracteristicPhys, Integer> mapPhysical) {
        this.id = id;
        this.name = name;
        this.image = image;
        this.mapGenetics = new HashMap<CaracteristicGen, Integer>();
        this.mapPhysical = mapPhysical;
        mapGenetics.put(CaracteristicGen.Force, 2);
        this.effectives = new ArrayList<>();
        this.mapEnvPropice = new HashMap<CaracteristicWorld, Integer>();
        mapEnvPropice.put(CaracteristicWorld.Temperature, 25);
        mapEnvPropice.put(CaracteristicWorld.Precipitations, 45);
        mapEnvPropice.put(CaracteristicWorld.Atmosphere, 500);

    }

    public Monster(int id, String name) {
        this.id = id;
        this.name = name;
        this.image = "";
        this.mapPhysical = new HashMap<CaracteristicPhys, Integer>();
        mapPhysical.put(CaracteristicPhys.Poids, 1);
        mapPhysical.put(CaracteristicPhys.Fertilite, 1);
        mapPhysical.put(CaracteristicPhys.Nutrition, 1);
        mapPhysical.put(CaracteristicPhys.Taille, 1);

        this.mapGenetics = new HashMap<CaracteristicGen, Integer>();
        mapGenetics.put(CaracteristicGen.Vitesse, 1);
        mapGenetics.put(CaracteristicGen.Degats, 1);
        mapGenetics.put(CaracteristicGen.Robustesse, 1);
        mapGenetics.put(CaracteristicGen.Force, 1);
        mapGenetics.put(CaracteristicGen.Temperature_Ideale, 20);
        this.effectives = new ArrayList<>();
        this.mapEnvPropice = new HashMap<CaracteristicWorld, Integer>();
        mapEnvPropice.put(CaracteristicWorld.Temperature, 25);
        mapEnvPropice.put(CaracteristicWorld.Precipitations, 45);
        mapEnvPropice.put(CaracteristicWorld.Atmosphere, 500);
    }

    public Monster(int id, String name, String image, Map<CaracteristicPhys, Integer> mapPhysical, Map<CaracteristicGen, Integer> mapGenetics) {
        this.id = id;
        this.name = name;
        this.image = image;
        this.mapPhysical = mapPhysical;
        this.mapGenetics = mapGenetics;
        this.effectives = new ArrayList<>();
        this.mapEnvPropice = new HashMap<CaracteristicWorld, Integer>();
        mapEnvPropice.put(CaracteristicWorld.Temperature, 25);
        mapEnvPropice.put(CaracteristicWorld.Precipitations, 45);
        mapEnvPropice.put(CaracteristicWorld.Atmosphere, 500);
    }

    public Monster(Monster toCopy){
        id = toCopy.id;
        name = toCopy.name;
        image = toCopy.image;
        mapGenetics = toCopy.mapGenetics;
        mapPhysical = toCopy.mapPhysical;
        effectives = toCopy.effectives;
        mapEnvPropice = toCopy.mapEnvPropice;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public String getImage() {
        return image;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Map<CaracteristicGen, Integer> getMapGenetics() {
        return mapGenetics;
    }

    public void setMapGenetics(Map<CaracteristicGen, Integer> mapGenetics) {
        this.mapGenetics = mapGenetics;
    }

    public Map<CaracteristicPhys, Integer> getMapPhysical() {
        return mapPhysical;
    }

    public void setMapPhysical(Map<CaracteristicPhys, Integer> mapPhysical) {
        this.mapPhysical = mapPhysical;
    }

    public List<ACard> getEffectives() {
        return effectives;
    }

    public void setEffectives(List<ACard> effectives) {
        this.effectives = new ArrayList<>();
        for (int i = 0; i < effectives.size(); i++) {
            this.addEffective(effectives.get(i));
        }
    }

    public void addEffective(ACard effective) {
        effectives.add(effective);
        if(!effective.getType().equals("CLIMATIC")){
            for(Map.Entry<CaracteristicGen, Integer> entry : ((PartMonsterCard)effective).getCaracteristiques().entrySet()) {
                if (entry.getKey() != CaracteristicGen.Temperature_Ideale) {
                    mapGenetics.put(entry.getKey(), mapGenetics.get(entry.getKey()) + entry.getValue());
                } else {
                    mapGenetics.put(entry.getKey(), entry.getValue());
                }
            }
        }
    }

    public int valueAnnalyses(){
        int compute = 0;
        for(Map.Entry<CaracteristicPhys, Integer> entry : mapPhysical.entrySet()){
            compute += entry.getValue();
        }
        for(Map.Entry<CaracteristicGen, Integer> entry : mapGenetics.entrySet()){
            compute += entry.getValue();
        }
        return compute;
    }
}
