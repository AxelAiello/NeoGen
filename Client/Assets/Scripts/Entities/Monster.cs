using System;
using System.Collections.Generic;

namespace AssemblyCSharp {

  [Serializable]
  public class Monster
  {

		public int ID;
		public string Name;
		public string Image;
    	public Dictionary<CaracteristicPhys, int> MapPhysical;
    	public Dictionary<CaracteristicGen, int> MapGenetics;

   		/*public Monster(int ID, int health, int strenght, string name = "")
		{
			MapGenetics = new Dictionary<CaracteristicGen, int> ();
			MapPhysical = new Dictionary<CaracteristicPhys, int> ();
			this.ID = ID;
			this.Name = name;

			this.MapGenetics.Add (CaracteristicGen.Health, health);
			this.MapGenetics.Add (CaracteristicGen.Strength, strenght);
		}*/

		public Monster() : this(0, "", "", new Dictionary<CaracteristicGen, int> (), new Dictionary<CaracteristicPhys, int> ()) { }

		public Monster(int ID, string name, string image, Dictionary<CaracteristicGen, int> dG, Dictionary<CaracteristicPhys, int> dP)
		{
			MapGenetics = dG;
			MapPhysical = dP;

			this.ID = ID;
			this.Name = name;
			this.Image = image;
		}


    public override string ToString()
    {
      string result = "Physical Caracteristics : \n";
      foreach(KeyValuePair<CaracteristicPhys,int> entry in MapPhysical)
      {
        result += "Caracteristic " + entry.Key.ToString() + " \t -> \t" + entry.Value +"\n";
      }
      result += "\n" + "Genetic Caracteristics\n";
      foreach (KeyValuePair<CaracteristicGen, int> entry in MapGenetics)
      {
        result += "Caracteristic " + entry.Key.ToString() + " \t -> \t" + entry.Value + "\n";
      }
      return result;
    }

  }
}