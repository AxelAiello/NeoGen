using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Stats
	{
		public bool isInstancied;
		private static Stats instance;
		public int points = 0;
		public int pointsOpponent = 0;
		public Dictionary<int, int> populations = new Dictionary<int, int>();

		private Stats() {
			isInstancied = false;
			points = 0;
			pointsOpponent = 0;
			populations = new Dictionary<int, int>();
		}

		public void Iniciate(JSONObject obj) {
			isInstancied = true;

			Debug.Log (obj);
			var mainObj = obj ["Details"];
			points = mainObj["PersonalPoints"];
			pointsOpponent = mainObj["OpponentPoints"];

			var evolutions = mainObj["Populations"];
			/*for(int j = 0; j < evolutions.Count; j++) {
				populations.Add (evolutions[j]["MonsterID"],evolutions[j]["Population"]);
			}*/
		}

		public static Stats Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Stats();
				}
				return instance;
			}
		}

		public static void Reset() {
			instance = null;
		}
	}
}