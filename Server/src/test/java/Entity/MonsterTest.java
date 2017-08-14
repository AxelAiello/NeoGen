package Entity;

import Entity.Card.ACard;
import Entity.Card.PartMonsterCard;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.HashMap;

import static org.junit.jupiter.api.Assertions.*;

/**
 * Created by Raphaël KUMAR on 12/06/17.
 */
class MonsterTest {

    private Monster MonsterToTest;

    @BeforeEach
    void setUp() {
        MonsterToTest = new Monster(10, "theMonster");
    }

    @Test
    void validateAddEffective() {
        assertEquals(1, MonsterToTest.getMapGenetics().get(CaracteristicGen.Force).intValue());
        ACard card = new PartMonsterCard();
        MonsterToTest.addEffective(card);
        assertEquals(2, MonsterToTest.getMapGenetics().get(CaracteristicGen.Force).intValue());
    }

    @Test
    void testSetEffective(){
        assertEquals(1, MonsterToTest.getMapGenetics().get(CaracteristicGen.Force).intValue());
        ACard first= new PartMonsterCard();
        ACard second = new PartMonsterCard();
        MonsterToTest.setEffectives(new ArrayList<ACard>(){{
            add(first);
            add(second);
        }});
        assertEquals(3, MonsterToTest.getMapGenetics().get(CaracteristicGen.Force).intValue());
    }

    @Test
    void testAnalyseValue() {
        assertEquals(28, MonsterToTest.valueAnnalyses());
    }
}