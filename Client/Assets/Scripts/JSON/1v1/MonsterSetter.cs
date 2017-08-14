using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class MonsterSetter
	{
		public bool isInstancied;
		private static MonsterSetter instance;

		public int points = 6;
		public float time = 15f;
		public List<Card> cards;

		private MonsterSetter() {
			isInstancied = false;
			points = 6;
			time = 15f;
			cards = new List<Card>();
		}

		public void Iniciate(JSONObject obj) {
			isInstancied = true;
			cards = new List<Card>();

			Debug.Log (obj);
			var mainObj = obj ["Details"];
			points = mainObj["Points"];
			time = mainObj["Time"];

			var hand = mainObj["Hand"];
			for(int i = 0; i < hand.Count; i++) {
				List<string> list = new List<string>();
				var description = hand[i]["Description"];
				for(int j = 0; j < description.Count; j++) {
					list.Add (description[j]["Type"] + " " + description[j]["Modificator"]);
				}
				cards.Add (new Card(hand[i]["Id"], hand [i] ["Name"], hand[i]["Image"], hand[i]["Nature"], list, hand[i]["Cost"], hand[i]["Type"]));
			}
		}

		public static MonsterSetter Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new MonsterSetter();
				}
				return instance;
			}
		}

		public static void Reset() {
			instance = null;
		}
	}
}

