using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AssemblyCSharp
{
	public class Word
	{
		public bool isInstancied;
		private static Word instance;
		public Map map;
			// Composants....
		public List<Monster> monsters;

		private Word() {
			isInstancied = false;
			map = new Map();
			monsters = new List<Monster>();
		}

		public void Iniciate(JSONObject obj) {
			isInstancied = true;
			monsters = new List<Monster>();

			Debug.Log (obj);
			var mainObj = obj ["Details"];
			map = new Map(mainObj["Map"]);
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

		public static Word Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Word();
				}
				return instance;
			}
		}

		public static void Reset() {
			instance = null;
		}

	}
}