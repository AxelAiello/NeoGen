using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class SystemChooseDeck : MonoBehaviour {

	// Variables pour les instances
	ServerAccess server;
	ParseJSON parse;
	TakeDecks takeDecks;
	List<GameObject> decksObject;
	List<GameObject> inventory;
	int actualChoice = 0;

	// Use this for initialization
	void Start () {
		// Connexion socket partie 1v1
		//server = ServerAccess.Instance;
		parse = new ParseJSON();
		takeDecks = TakeDecks.Instance;

		decksObject = new List<GameObject> ();
		// Initialise les deck
		for(int i = 0; i < takeDecks.decks.Count; i++) {
			GameObject prefab = Resources.Load("Deck/chooseDeckList") as GameObject;
			GameObject panel = (GameObject)GameObject.Instantiate(prefab);
			print(takeDecks.decks[i]);
			panel.GetComponent<ChooseDeckObject> ().setDeck (takeDecks.decks[i]);
			Transform childTransform = panel.transform;
			childTransform.SetParent(GameObject.Find("DeckListGrid").transform);
			panel.transform.localScale = new Vector3(1, 1, 1);

			decksObject.Add (panel);
		}
		// Initialise l'inventaire
		inventory = new List<GameObject> ();
	}

	// Update is called once per frame
	public void setActualChoice (int choice) {
		for(int i = 0; i < takeDecks.decks.Count; i++) {
			if(takeDecks.decks[i].id == choice) {
				actualChoice = i;
			}
		}
		// Initialise l'inventaire
		for(int i = 0; i < inventory.Count; i++) {
			Destroy (inventory[i]);
		}
		inventory = new List<GameObject> ();
		for(int i = 0; i < takeDecks.decks[actualChoice].theDeck.Count; i++) {
			int place = -1;
			for (int j = 0; j < inventory.Count; j++) {
				if(inventory[j].GetComponent<CardObject> ().card.id == takeDecks.decks[actualChoice].theDeck[i].id) {
					place = j;
				}
			}

			if (place != -1) {
				inventory [place].GetComponent<CardObject> ().Quantity = inventory [place].GetComponent<CardObject> ().Quantity + 1;
			} else {
				GameObject prefab = Resources.Load ("Deck/card") as GameObject;
				GameObject deckCard = (GameObject)GameObject.Instantiate (prefab);
				deckCard.GetComponent<CardObject> ().setCard (takeDecks.decks[actualChoice].theDeck[i], 1);
				Transform childTransform = deckCard.transform;
				childTransform.SetParent (GameObject.Find ("CardGrid").transform);
				deckCard.transform.localScale = new Vector3 (1.4f, 1, 1);

				inventory.Add (deckCard);
			}
		}
	}
}