using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Draw
	{
		public bool isInstancied;
		private static Draw instance;
		public Card newCard;

		private Draw() {
			isInstancied = false;
			newCard = new Card ();
		}

		public void Iniciate(JSONObject obj) {
			isInstancied = true;
			Debug.Log (obj);
			var mainObj = obj ["Details"];
			var card = mainObj["Card"];
			List<string> list = new List<string>();
			var description = card["Description"];
			for(int j = 0; j < description.Count; j++) {
				list.Add (description[j]["Type"] + " " + description[j]["Modificator"]);
			}
			newCard = new Card(card["Id"], card["Name"], card["Image"], card["Nature"], list, card["Cost"], card["Type"]);
		}

		public static Draw Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Draw();
				}
				return instance;
			}
		}

		public static void Reset() {
			instance = null;
		}

	}
}
