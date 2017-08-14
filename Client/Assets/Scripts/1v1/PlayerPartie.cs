using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;
using System.Threading;

public class PlayerPartie : MonoBehaviour {

	public MonsterSetter monsterSetter;
	public StartPartie start;
	public Stats stats;

	public int nbrCarte = 30;
	public Text textNbtCart;

	public bool firstTimePoint = true;
	public int compteurCard = 0;

	public Image barrePoints;
	public List<Card> hand;
	public List<GameObject> handObject;

	void Start() {
		// Initialisation des instances
		monsterSetter = MonsterSetter.Instance;
		start = StartPartie.Instance;
		stats = Stats.Instance;
		// Deck Initialisation
		textNbtCart.text = nbrCarte + "/30";
		// Barre de chargement Initialisation
		barrePoints.fillAmount = 0.8f;
		hand = monsterSetter.cards;
		handObject = new List<GameObject>();
		// Mise à jour des données cartes
		foreach (Card card in hand) {
			GameObject c = Instantiate (Resources.Load ("Card/CardObject"), transform.position, Quaternion.identity) as GameObject;
			c.transform.SetParent (this.transform);
			c.transform.localScale = new Vector3(1f, 1f, 1f);
			c.name = "Card " + compteurCard;
			handObject.Add (c);
			Draggable d = c.GetComponent<Draggable> ();
			d.SetCard(card);
			compteurCard++;
		}
	}

	// Update is called once per frame
	void Update () {
		if (stats.isInstancied) {
			// Deck Mise A Jour
			textNbtCart.text = nbrCarte + "/30";
			// Barre de chargement Mise A Jour
			barrePoints.fillAmount = (float) stats.points / 10f;
		} else if (start.isInstancied) {
			// Deck Mise A Jour
			if(firstTimePoint) {
				firstTimePoint = false;
				foreach(GameObject c in handObject) {
					Destroy (c);
				}
				handObject = new List<GameObject>();
				nbrCarte = start.nbrcard;
				// Mise à jour des données cartes
				hand = start.cards;
				foreach (Card card in hand) {
					GameObject c = Instantiate (Resources.Load ("Card/CardObject"), transform.position, Quaternion.identity) as GameObject;
					c.transform.SetParent (this.transform);
					c.transform.localScale = new Vector3(1f, 1f, 1f);
					c.name = "Card " + compteurCard;
					handObject.Add (c);
					Draggable d = c.GetComponent<Draggable> ();
					d.SetCard(card);
					compteurCard++;
				}
			}
			textNbtCart.text = nbrCarte + "/30";
			// Barre de chargement Mise A Jour
			barrePoints.fillAmount = (float) start.points / 10f;
		} else {
			// Deck Mise A Jour
			textNbtCart.text = "";
			// Barre de chargement Mise A Jour
			barrePoints.fillAmount = (float) monsterSetter.points / 10f;
		}


	}
}
