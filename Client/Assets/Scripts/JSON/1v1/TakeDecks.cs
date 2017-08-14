using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class TakeDecks
	{
		public bool isInstancied;
		private static TakeDecks instance;
		public List<Deck> decks;
		public List<Card> inventory;

		private TakeDecks() {
			isInstancied = false;

			List<Card> cards1 = new List<Card> ();
			cards1.Add (new Card(1, "Fourrure", "Assets/Resources/Images/Cartes_Genetiques/fourrure.jpg", "", new List<string>(), 3, ""));
			cards1.Add (new Card(1, "Fourrure", "Assets/Resources/Images/Cartes_Genetiques/fourrure.jpg", "", new List<string>(), 3, ""));
			cards1.Add (new Card(1, "Fourrure", "Assets/Resources/Images/Cartes_Genetiques/fourrure.jpg", "", new List<string>(), 3, ""));
			cards1.Add (new Card(2, "Canicule", "Assets/Resources/Images/Cartes_Climats/canicule.jpg", "", new List<string>(), 3, ""));
			cards1.Add (new Card(2, "Canicule", "Assets/Resources/Images/Cartes_Climats/canicule.jpg", "", new List<string>(), 3, ""));
			cards1.Add (new Card(3, "Carapace", "Assets/Resources/Images/Cartes_Genetiques/carapace.jpg", "", new List<string>(), 3, ""));
			List<Card> cards2 = new List<Card> ();
			cards2.Add (new Card(4, "Griffes", "Assets/Resources/Images/Cartes_Genetiques/griffes.jpg", "", new List<string>(), 3, ""));
			cards2.Add (new Card(1, "Fourrure", "Assets/Resources/Images/Cartes_Genetiques/fourrure.jpg", "", new List<string>(), 3, ""));
			cards2.Add (new Card(2, "Ecailles", "Assets/Resources/Images/Cartes_Genetiques/ecailles.jpg", "", new List<string>(), 3, ""));
			cards2.Add (new Card(4, "Griffes", "Assets/Resources/Images/Cartes_Genetiques/griffes.jpg", "", new List<string>(), 3, ""));
			cards2.Add (new Card(1, "Fourrure", "Assets/Resources/Images/Cartes_Genetiques/fourrure.jpg", "", new List<string>(), 3, ""));
			cards2.Add (new Card(7, "Tsunami", "Assets/Resources/Images/Cartes_Climats/tsunami.jpg", "", new List<string>(), 3, ""));
			List<Card> cards3 = new List<Card> ();
			cards3.Add (new Card(5, "Corne", "Assets/Resources/Images/Cartes_Genetiques/corne.jpg", "", new List<string>(), 3, ""));
			cards3.Add (new Card(6, "Secheresse", "Assets/Resources/Images/Cartes_Climats/secheresse.jpg", "", new List<string>(), 3, ""));
			cards3.Add (new Card(5, "Corne", "Assets/Resources/Images/Cartes_Genetiques/corne.jpg", "", new List<string>(), 3, ""));
			cards3.Add (new Card(9, "Incendie", "Assets/Resources/Images/Cartes_Climats/incendie.jpg", "", new List<string>(), 3, ""));
			cards3.Add (new Card(11, "Ecailles", "Assets/Resources/Images/Cartes_Genetiques/ecailles.jpg", "", new List<string>(), 3, ""));
			cards3.Add (new Card(11, "Ecailles", "Assets/Resources/Images/Cartes_Genetiques/ecailles.jpg", "", new List<string>(), 3, ""));

			decks = new List<Deck> ();
			decks.Add (new Deck(0, "Deck 0", cards1));
			decks.Add (new Deck(1, "Deck 1", cards2));
			inventory = cards3;
		}

		public void Iniciate(JSONObject obj) {
			isInstancied = true;
			decks = new List<Deck> ();
			inventory = new List<Card> ();

			Debug.Log (obj);
			var mainObj = obj ["Details"];
			var decksObj = mainObj["Decks"];
			for(int i = 0; i < decksObj.Count; i++) {
				List<Card> cards = new List<Card> ();
				var deckObj = decksObj[i];
				for(int k = 0; k < deckObj.Count; k++) {
					List<string> list = new List<string>();
					var description = deckObj[k]["Description"];
					for(int j = 0; j < description.Count; j++) {
						list.Add (description[j]["Type"] + " " + description[j]["Modificator"]);
					}
					cards.Add (new Card(deckObj[k]["Id"], deckObj[k]["Name"], deckObj[k]["Image"], deckObj[k]["Nature"], list, deckObj[k]["Cost"], deckObj[k]["Type"]));
				}
				decks.Add (new Deck(decksObj[i]["Id"], decksObj [i] ["Name"], cards));
			}
			inventory = new List<Card> ();
			var invent = mainObj["Inventory"];
			for (int k = 0; k < invent.Count; k++) {
				List<string> list = new List<string> ();
				var description = invent [k] ["Description"];
				for (int j = 0; j < description.Count; j++) {
					list.Add (description [j] ["Type"] + " " + description [j] ["Modificator"]);
				}
				inventory.Add (new Card (invent [k] ["Id"], invent [k] ["Name"], invent [k] ["Image"], invent [k] ["Nature"], list, invent [k] ["Cost"], invent [k] ["Type"]));
			}
		}

		public static TakeDecks Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new TakeDecks();
				}
				return instance;
			}
		}

		public static void Reset() {
			instance = null;
		}
	}
}