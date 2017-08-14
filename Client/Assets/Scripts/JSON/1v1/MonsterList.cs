using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace AssemblyCSharp
{
    public class MonsterList 
    {
		public bool isInstancied;
        private static MonsterList instance;
        public List<Monster> monsters;
        private MonsterList()
        {
			isInstancied = false;
            monsters = new List<Monster>();
        }

		public void Iniciate(JSONObject obj)
		{
			isInstancied = true;
			Debug.Log(obj);

			var mainObj = obj ["Details"];
			var m = mainObj["Monsters"];
			for(int j = 0; j < m.Count; j++) {
				var mapPhy = m[j]["MapPhysical"];
				Dictionary<CaracteristicPhys, int> MapPhysical = new Dictionary<CaracteristicPhys, int>();
				for(int i  = 0; i < mapPhy.Count; i++) {
					MapPhysical.Add (EnumParse.GetValueCaracteristicPhys(mapPhy [i] ["Type"].Value), mapPhy [i] ["Value"]);
				}
				var mapGen = m[j]["MapGenetics"];
				Dictionary<CaracteristicGen, int> MapGenetics = new Dictionary<CaracteristicGen, int>();
				for(int i  = 0; i < mapGen.Count; i++) {
					MapGenetics.Add (EnumParse.GetValueCaracteristicGen(mapGen [i] ["Type"].Value), mapGen[i]["Value"]);
				}
				monsters.Add (new Monster(m[j]["Id"], m[j]["Name"], m[j]["Image"], MapGenetics, MapPhysical));
			}
		}

		public static MonsterList Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new MonsterList();
				}
				return instance;
			}
		}

		public static void Reset() {
			instance = null;
		}
    }
}
