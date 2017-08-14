using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Deck {
	public int id;
	public string name;
	public List<Card> theDeck;


	public Deck(int id, string name, List<Card> theDeck) {
		this.id = id;
		this.name = name;
		this.theDeck = theDeck;
	}

	public Deck() {
		this.id = -1;
		this.name = "Inconnu";
		this.theDeck = new List<Card>();
	}
		
	public Deck(string name) {
		System.Random r = new System.Random ();
		this.id = r.Next(0,1000000000);
		this.name = name;
		this.theDeck = new List<Card>();
	}
}