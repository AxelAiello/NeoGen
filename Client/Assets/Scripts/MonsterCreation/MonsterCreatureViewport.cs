using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AssemblyCSharp
{
  public class MonsterCreatureViewport : MonoBehaviour
  {

    public Button SaveButton;
    public InputField MonsterNameField;

    public List<GameObject> Caracteristics;

    public Monster PlaceholderMonster { get; set; }



    // Use this for initialization
    void Start()
    {

      PlaceholderMonster = new Monster();

      List<CaracteristicPhys> available = new List<CaracteristicPhys> { CaracteristicPhys.Poids, CaracteristicPhys.Taille, CaracteristicPhys.Nutrition, CaracteristicPhys.Fertilite};

      for (int index = 0; index < Caracteristics.Count; index++)
      {
        Caracteristics[index].GetComponent<CaracteristicController>().SetDescription(available[index]);
        Debug.Log("Index" + index + "  Car type " + available[index]);
      }
      SaveButton.onClick.AddListener(
       delegate { SaveMonster(); });
    }
    

    public void SaveMonster()
    {
      Debug.Log("SAVING MONSTER");
      MonsterCatalog.Instance.Load();
      Debug.Log(MonsterList.Instance.monsters.Count);
      // MonsterList.Instance.monsters.Add(new Monster(2, 6, 8, "SOMETHING"));

      //Dictionary<CaracteristicGen, int> Genetics = new Dictionary<CaracteristicGen, int>();
      Dictionary<CaracteristicPhys, int> Physical = new Dictionary<CaracteristicPhys, int>();


      for (int index = 0; index < Caracteristics.Count; index++) 
      {
        GameObject c = Caracteristics[index];
        Debug.Log("Key" + c.GetComponent<CaracteristicController>().GetKeyValue().ToString()
          + " value " + c.GetComponent<CaracteristicController>().GetSliderValue());
        Physical.Add(
          c.GetComponent<CaracteristicController>().GetKeyValue(),
          c.GetComponent<CaracteristicController>().GetSliderValue());
      }

      Dictionary<CaracteristicGen, int> Genetics = new GenCaracteristicComputer().ComputeGenetics(Physical);

			Monster monsterToSave = new Monster(-1, MonsterNameField.text, "", Genetics, Physical);

      PlaceholderMonster = monsterToSave;
      MonsterList.Instance.monsters.Add(monsterToSave);
     

      Debug.Log(MonsterList.Instance.monsters[0].ToString());
      Debug.Log(MonsterList.Instance.monsters.Count);

     
   
      MonsterCatalog.Instance.Save();
    }

    // Update is called once per frame
    void Update()
    {

    }
  }

}