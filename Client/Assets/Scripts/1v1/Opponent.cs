using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class Opponent : MonoBehaviour {

	public int nbrCarte = 30;
	public Text textNbtCart;

	// Premier Passage
	public bool firstTimePoint = true;

	public Image barrePoints;
	public List<Card> hand;
	public string Name = "Inconnu";
	public string avatar = "Inconnu";

	void Start() {
		// Deck Initialisation
		textNbtCart.text = nbrCarte + "/30";
		// Barre de chargement Initialisation
		barrePoints.fillAmount = 0.8f;

		Name = "Inconnu";
		avatar = "Inconnu";
	}

	// Update is called once per frame
	void Update () {
		// Initialisation des instances
		StartPartie start = StartPartie.Instance;
		Stats stats = Stats.Instance;
		// Si le jeu a commencé
		if (stats.isInstancied) {
			// Deck Mise A Jour
			textNbtCart.text = nbrCarte + "/30";
			// Barre de chargement Mise A Jour
			barrePoints.fillAmount = (float)stats.pointsOpponent / 10f;
		} 
		// Si le jeu commence
		else if (start.isInstancied) {
			// Mise à jour des fenêtres
			barrePoints.gameObject.SetActive (true);
			gameObject.SetActive (true);
			// Initialisation des données
			if(firstTimePoint) {
				firstTimePoint = false;
				hand = new List<Card> ();
				hand.Add (new Card ());
				hand.Add (new Card ());
				hand.Add (new Card ());
				hand.Add (new Card ());
				hand.Add (new Card ());

				int i = 0;
				foreach (Card card in hand) {
					GameObject c = Instantiate (Resources.Load ("Card/CardBack"), transform.position, Quaternion.identity) as GameObject;
					c.transform.SetParent (this.transform);
					c.transform.localScale = new Vector3(1f, 1f, 1f);
					c.name = "Card " + i;
					i++;
				}
				nbrCarte = start.nbrcardOpponent;
			}
			textNbtCart.text = nbrCarte + "/30";
			// Barre de chargement Mise A Jour
			barrePoints.fillAmount = (float)start.pointsOpponent / 10f;
			Name = start.nameOpponent;
			avatar = start.avatarOpponent;
		} else {
			// Mise à jour des fenêtres
			barrePoints.gameObject.SetActive (false);
		}
	}
}
