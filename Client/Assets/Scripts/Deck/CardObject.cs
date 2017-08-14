using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour {
	public int Id;
	public string Name;
	public string Description;
	public string Image;
	public int Cost;
	public int Quantity;
	public Card card;

	// Update is called once per frame
	void Update () {
		transform.Find("Name").GetComponent<Text>().text = Name;
		transform.Find ("Description").GetComponentInChildren<Text> ().text = Description;
		transform.Find ("Image").GetComponentInChildren<Image> ().sprite = (Sprite) UnityEditor.AssetDatabase.LoadAssetAtPath(Image, typeof(Sprite)); 
		transform.Find("Cost").GetComponentInChildren<Text>().text = Cost.ToString();
		transform.Find("Quantity").GetComponentInChildren<Text>().text = Quantity.ToString();
	}


	public void setCard(Card c, int q) {
		card = c;
		Id = card.id;
		Name = card.name;
		//Description = card.description;
		Image = card.image;
		Cost = card.cost;
		Quantity = q;
	}


}