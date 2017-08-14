using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;
using UnityEngine.SceneManagement;

public class SystemInventory : MonoBehaviour {

	// Variables pour les instances
	ServerAccess server;
	ParseJSON parse;
	TakeDecks takeDecks;
	List<GameObject> inventory;

	// Use this for initialization
	void Start () {
		// Connexion socket partie 1v1
		//server = ServerAccess.Instance;
		parse = new ParseJSON();
		takeDecks = TakeDecks.Instance;

		// Initialise l'inventaire
		inventory = new List<GameObject> ();
		for(int i = 0; i < takeDecks.inventory.Count; i++) {
			int place = -1;
			for (int j = 0; j < inventory.Count; j++) {
				if(inventory[j].GetComponent<CardObject> ().card.id == takeDecks.inventory [i].id) {
					place = j;
				}
			}

			if (place != -1) {
				inventory [place].GetComponent<CardObject> ().Quantity = inventory [place].GetComponent<CardObject> ().Quantity + 1;
			} else {
				GameObject prefab = Resources.Load ("Deck/cardInventory") as GameObject;
				GameObject deckCard = (GameObject)GameObject.Instantiate (prefab);
				deckCard.GetComponent<CardObject> ().setCard (takeDecks.inventory [i], 1);
				Transform childTransform = deckCard.transform;
				childTransform.SetParent (GameObject.Find ("CardGrid").transform);
				deckCard.transform.localScale = new Vector3 (1.4f, 1, 1);

				inventory.Add (deckCard);
			}
		}
	}

	public void GoToMenu()
	{
		// Sauvegarder les decks
		//SaveDeckFunction()
		LoadingControlor.SetNextScene("Scenes/MenuScene");
		SceneManager.LoadScene("Scenes/ChargementScene");
	}
}