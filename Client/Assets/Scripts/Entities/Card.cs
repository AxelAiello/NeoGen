using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {
	public int id;
	public string name;
	public string image;
	public string nature;
	public List<string> description;
	// text ???
	public int cost;
	public string type;
	// Composants....

	public Card(int id, string name, string image, string nature, List<string> description, int cost, string type) {
		this.id = id;
		this.name = name;
		this.image = image;
		this.nature = nature;
		this.description = description;
		this.cost = cost;
		this.type = type;
	}

	public Card() {
		this.id = -1;
		this.name = "Inconnu";
		this.image = "Inconnu";
		this.nature = "Inconnu";
		this.description = new List<string>();
		this.cost = 0;
		this.type = "Inconnu";
	}


}
