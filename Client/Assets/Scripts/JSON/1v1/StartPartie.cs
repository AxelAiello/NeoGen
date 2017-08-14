using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AssemblyCSharp
{
	public class StartPartie
	{

		private static StartPartie instance;
		public bool isInstancied;
		public float time = 0f;
		public Map map;
			// Composants....

		public int points = 0;
		public int nbrcard = 0;
		public Monster monster;
		public List<Card> cards = new List<Card>();

		public int pointsOpponent = 0;
		public int nbrcardOpponent = 0;
		public string nameOpponent = "Inconnu";
		public string avatarOpponent = "Inconnu";
			// Composants....
		public Monster monsterOpponent;

		private StartPartie() {
			isInstancied = false;
			time = 0;
			map = new Map();

			points = 0;
			nbrcard = 0;
			monster = new Monster();

			pointsOpponent = 0;
			nbrcardOpponent = 0;
			nameOpponent = "Inconnu";
			avatarOpponent = "Inconnu";
			monsterOpponent = new Monster();

			cards = new List<Card>();
		}

		public void Iniciate(JSONObject obj) {
			isInstancied = true;
			cards = new List<Card>();

			Debug.Log (obj);
			var mainObj = obj ["Details"];
			time = mainObj["Time"];
			map = new Map(mainObj["Map"]);

			points = mainObj["Points"];
			nbrcard = mainObj["Nbrcard"] + 1;

			var m = mainObj["Monster"];
			var mapPhy = m["MapPhysical"];
			Dictionary<CaracteristicPhys, int> MapPhysical = new Dictionary<CaracteristicPhys, int>();
			for(int i  = 0; i < mapPhy.Count; i++) {
				MapPhysical.Add ((CaracteristicPhys)Enum.Parse (typeof(CaracteristicPhys), mapPhy[i]["Type"].Value), mapPhy[i]["Value"]);

			}
			var mapGen = m["MapGenetics"];
			Dictionary<CaracteristicGen, int> MapGenetics = new Dictionary<CaracteristicGen, int>();
			for(int i  = 0; i < mapGen.Count; i++) {
				MapGenetics.Add ((CaracteristicGen)Enum.Parse (typeof(CaracteristicGen), mapGen [i] ["Type"].Value), mapGen [i] ["Value"]);
			}
			monster = new Monster(m["Id"], m["Name"], m["Image"], MapGenetics, MapPhysical);

			var opponent = mainObj["Opponent"];
			nameOpponent = opponent ["Name"];
			avatarOpponent = opponent["Avatar"];
			pointsOpponent = opponent["Points"];
			nbrcardOpponent = opponent["Nbrcard"] + 1;

			var mOpponent = opponent["Monster"];
			var mapPhyOpponent = mOpponent["MapPhysical"];
			Dictionary<CaracteristicPhys, int> MapPhysicalOpponent = new Dictionary<CaracteristicPhys, int>();
			for(int i  = 0; i < mapPhyOpponent.Count; i++) {
				MapPhysicalOpponent.Add (EnumParse.GetValueCaracteristicPhys(mapPhyOpponent [i] ["Type"].Value), mapPhyOpponent[i]["Value"]);
			}
			var mapGenOpponent = mOpponent["MapGenetics"];
			Dictionary<CaracteristicGen, int> MapGeneticsOpponent = new Dictionary<CaracteristicGen, int>();
			for(int i  = 0; i < mapGenOpponent.Count; i++) {
				MapGeneticsOpponent.Add ((CaracteristicGen)Enum.Parse (typeof(CaracteristicGen), mapGenOpponent [i] ["Type"].Value), mapGenOpponent [i] ["Value"]);
			}
			monsterOpponent = new Monster(mOpponent["Id"], mOpponent["Name"], mOpponent["Image"], MapGeneticsOpponent, MapPhysicalOpponent);

			var hand = mainObj["Hand"];
			// 5 cartes pour la main
			for(int i = 0; i < hand.Count - 1; i++) {
				List<string> list = new List<string>();
				var description = hand[i]["Description"];
				for(int j = 0; j < description.Count; j++) {
					list.Add (description[j]["Type"] + " " + description[j]["Modificator"]);
				}
				cards.Add (new Card(hand[i]["Id"], hand [i] ["Name"], hand[i]["Image"], hand[i]["Nature"], list, hand[i]["Cost"], hand[i]["Type"]));
			}
			// Une pour piocher
			List<string> listDraw = new List<string>();
			var descriptionDraw = hand[hand.Count - 1]["Description"];
			for(int j = 0; j < descriptionDraw.Count; j++) {
				listDraw.Add (descriptionDraw[j]["Type"] + " " + descriptionDraw[j]["Modificator"]);
			}
			// Instancie Draw
			Draw draw = Draw.Instance;
			draw.newCard = new Card(hand[hand.Count - 1]["Id"], hand [hand.Count - 1] ["Name"], hand[hand.Count - 1]["Image"], hand[hand.Count - 1]["Nature"], listDraw, hand[hand.Count - 1]["Cost"], hand[hand.Count - 1]["Type"]);
			isInstancied = true;
		}

		public static StartPartie Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new StartPartie();
				}
				return instance;
			}
		}

		public static void Reset() {
			instance = null;
		}
	}
}
