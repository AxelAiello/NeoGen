using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using AssemblyCSharp;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public MonsterSetter monsterSetter;
	public StartPartie start;
	public Stats stats;
	public Draw draw;

	void Start() {
		monsterSetter = MonsterSetter.Instance;
		start = StartPartie.Instance;
		stats = Stats.Instance;
		draw = Draw.Instance;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		if (eventData.pointerDrag == null)
			return;
		
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		// Si le cost te le permet tu peux bouger la carte
		if(d != null && d.isMovable) {
			d.placeholderParent = this.transform;
		}
	}
	
	public void OnPointerExit(PointerEventData eventData) {
		if (eventData.pointerDrag == null)
			return;
		
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if(d != null && d.isMovable && d.placeholderParent == this.transform) {
			d.placeholderParent = d.natalParent;
		}
	}

	public void OnDrop(PointerEventData eventData) {
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		// Si on a saisit
		if (d != null && d.isMovable) {
			// Si on est dans le début du jeu alors les cartes sont connsommées
			if (start.isInstancied) {
				// Manip Server
				ServerAccess server = ServerAccess.Instance;
				ParseJSON parse = new ParseJSON();
				server.Sender(parse.PlayCardFunction(d.card.id).ToString());

				// Manip Client
				PlayerPartie j = d.natalParent.GetComponent<PlayerPartie> ();
				if (j.nbrCarte > 0) {
					j.nbrCarte--;
					GameObject c = Instantiate (Resources.Load ("Card/CardObject"), d.placeholder.transform.position, Quaternion.identity) as GameObject;
					c.transform.SetParent (d.natalParent);
					c.transform.localScale = new Vector3(1f, 1f, 1f);
					c.name = "Card " + j.compteurCard;
					Draggable draggable = c.GetComponent<Draggable> ();
					draggable.SetCard (draw.newCard);
					j.compteurCard++;
				}

				// On détruit l'objet
				Destroy (d.placeholder);
				Destroy (d.gameObject);
			} 
			// Sinon on est dans la selectione de base, les cartes sont alors sélectionnées
			else {
				// On selectionne les cartes
				ServeurStart1V1 s = GameObject.Find("Canvas").GetComponent<ServeurStart1V1> ();
				if (d.natalParent.GetComponent<PlayerPartie> () != null) {
					// On selectionne les cartes
					s.listCard.Add (d.card.id);
				} 
				// On l'enlève
				else {
					for (int i = 0; i < s.listCard.Count; i++) {
						s.listCard.Remove (d.card.id);
					}
				}
			}

			// Gestion des points
			if (stats.isInstancied) {
				if (d.nativeParent == d.placeholderParent && d.natalParent != d.placeholderParent) {
					stats.points = stats.points + d.card.cost;
				} else if (d.nativeParent != d.placeholderParent && d.natalParent != d.placeholderParent && d.card.cost <= stats.points) {
					stats.points = stats.points - d.card.cost;
				}
			} else if (start.isInstancied) {
				if (d.nativeParent == d.placeholderParent && d.natalParent != d.placeholderParent) {
					start.points = start.points + d.card.cost;
				} else if (d.nativeParent != d.placeholderParent && d.natalParent != d.placeholderParent && d.card.cost <= start.points) {
					start.points = start.points - d.card.cost;
				}
			} else {
				if (d.nativeParent == d.placeholderParent && d.natalParent != d.placeholderParent) {
					monsterSetter.points = monsterSetter.points + d.card.cost;
				} else if (d.nativeParent != d.placeholderParent && d.natalParent != d.placeholderParent && d.card.cost <= monsterSetter.points) {
					monsterSetter.points = monsterSetter.points - d.card.cost;
				}
			}

			d.natalParent = this.transform;

		}



	}

}
