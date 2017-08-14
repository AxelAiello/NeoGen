using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckObject : MonoBehaviour {
	public List<Card> cards;
	public string Name;
	public int Id;
	public Deck deck;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Id = deck.id;
		Name = deck.name;
		cards = deck.theDeck;

		transform.Find("Name").GetComponent<Text>().text = Name;
	}

	public void setDeck(Deck d) {
		deck = d;

		// Initialise l'inventaire
		List<GameObject> inventory = new List<GameObject> ();
		for(int i = 0; i < deck.theDeck.Count; i++) {
			int place = -1;
			for (int j = 0; j < inventory.Count; j++) {
				if(inventory[j].GetComponent<CardInDeckObject> ().card.id == deck.theDeck[i].id) {
					place = j;
				}
			}

			if (place != -1) {
				inventory [place].GetComponent<CardInDeckObject> ().Quantity = inventory [place].GetComponent<CardInDeckObject> ().Quantity + 1;
			} else {
				GameObject prefab = Resources.Load ("Deck/cardInDeck") as GameObject;
				GameObject deckCard = (GameObject)GameObject.Instantiate (prefab);
				deckCard.GetComponent<CardInDeckObject> ().setCard (deck.theDeck [i], 1);
				Transform childTransform = deckCard.transform;
				foreach (Transform child in transform) {
					if (child.tag == "DeckCardScroll") {
						foreach (Transform childChild in child) {
							if (childChild.tag == "DeckCardList") {
								childTransform.SetParent (childChild);
							}
						}
					}
				}
				deckCard.transform.localScale = transform.localScale;
				inventory.Add (deckCard);
			}
		}
	}

	public void addCard(Card c) {
		deck.theDeck.Add (c);
	}

	public void removeCard(Card c) {
		for (int i = 0; i < deck.theDeck.Count; i++) {
			if(deck.theDeck[i].id == c.id) {
				deck.theDeck.RemoveAt(i);
				return;
			}
		}
	}
}