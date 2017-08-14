using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
  public class Caracteristics
  {

    public float Health { get; set; }
    public float Strength { get; set; }
    public float Level { get; set; }
    public int ID;


    public Dictionary<CaracteristicPhys, int> MapPhysical;
    public Dictionary<CaracteristicGen, int> MapGenetics;

    //public Caracteristics() : this(0, 0, 0) { }
   // public Caracteristics(float defense, float attack) : this(defense, attack, 0) { }
    //public Caracteristics(float defense, float attack, float level) : this(defense, attack, level, Mathf.CeilToInt(level)) { }
    public Caracteristics(int id,
      Dictionary<CaracteristicPhys, int> mapPhysical,
      Dictionary<CaracteristicGen, int> mapGenetics)
    {
      ID = id;
      MapGenetics = mapGenetics;
      MapPhysical = mapPhysical;
    }

    public Caracteristics(float defense, float attack, float level, int id)
    {
      this.Health = defense;
      this.Strength = attack;
      this.Level = level;
      this.ID = id;
    }


    public override string ToString()
    {
      string result = "";
      foreach (KeyValuePair<CaracteristicPhys, int> entry in MapPhysical)
      {
        result += "Caracteristic " + entry.Key.ToString() + " \t -> \t" + entry.Value + "\n";
      }
      result += "\n";
      foreach (KeyValuePair<CaracteristicGen, int> entry in MapGenetics)
      {
        result += "Caracteristic " + entry.Key.ToString() + " \t -> \t" + entry.Value + "\n";
      }
      return result;
    /*  return
          "Strength : " + Strength + '\n'
        + "Health : " + Health + '\n'
        + "Level : " + Level;
        */
    }


  }

}