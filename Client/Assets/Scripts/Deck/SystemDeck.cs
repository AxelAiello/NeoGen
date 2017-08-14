using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class SystemDeck : MonoBehaviour {

	// Variables pour les instances
	ServerAccess server;
	ParseJSON parse;
	TakeDecks takeDecks;
	List<GameObject> decksObject;
	List<GameObject> inventory;

	// Use this for initialization
	void Start () {
		// Connexion socket partie 1v1
		//server = ServerAccess.Instance;
		parse = new ParseJSON();
		takeDecks = TakeDecks.Instance;

		decksObject = new List<GameObject> ();
		// Initialise les deck
		for(int i = 0; i < takeDecks.decks.Count; i++) {
			GameObject prefab = Resources.Load("Deck/deckList") as GameObject;
			GameObject panel = (GameObject)GameObject.Instantiate(prefab);
			panel.GetComponent<DeckObject> ().setDeck (takeDecks.decks[i]);
			Transform childTransform = panel.transform;
			childTransform.SetParent(GameObject.Find("DeckListGrid").transform);
			panel.transform.localScale = new Vector3(1, 1, 1);

			decksObject.Add (panel);
		}
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
				GameObject prefab = Resources.Load ("Deck/card") as GameObject;
				GameObject deckCard = (GameObject)GameObject.Instantiate (prefab);
				deckCard.GetComponent<CardObject> ().setCard (takeDecks.inventory [i], 1);
				Transform childTransform = deckCard.transform;
				childTransform.SetParent (GameObject.Find ("CardGrid").transform);
				deckCard.transform.localScale = new Vector3 (1.4f, 1, 1);

				inventory.Add (deckCard);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		List<Deck> decks = new List<Deck> ();
		for(int i = 0; i < decksObject.Count; i++) {
			decks.Add (decksObject [i].GetComponent<DeckObject> ().deck);
		}
		takeDecks.decks = decks;

		List<Card> cards = new List<Card> ();
		inventory = new List<GameObject> ();
		GameObject[] list = GameObject.FindGameObjectsWithTag("CardChosed");
		for(int i = 0; i < list.Length; i++) {
			for (int j = 0; j < list [i].GetComponent<CardObject> ().Quantity; j++) {
				cards.Add (list [i].GetComponent<CardObject> ().card);
				inventory.Add (list [i]);
			}
		}
		takeDecks.inventory = cards;
	}

	public void deleteDeck(GameObject g) {
		decksObject.Remove (g);
	}

	public void addDeck(GameObject g) {
		decksObject.Add (g);
	}
}