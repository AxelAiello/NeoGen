using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseDeckObject : MonoBehaviour {
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
	}
}