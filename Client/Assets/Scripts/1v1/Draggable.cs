using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using AssemblyCSharp;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public MonsterSetter monsterSetter;
	public StartPartie start;
	public Stats stats;
	// Variables pour les cartes
	public Card card;
	public Text Name;
	public Image Image;
	public Text Description;
	public Text Cost;

	// Variables pour le changement de placement
	public bool isMovable = false;
	public GameObject placeholder = null;
	public Transform nativeParent = null;
	public Transform natalParent = null;
	public Transform placeholderParent = null;

	void Start() {
		// Initialise le parent
		natalParent = this.transform.parent;
		placeholderParent = natalParent;
		nativeParent = natalParent;
		monsterSetter = MonsterSetter.Instance;
		start = StartPartie.Instance;
		stats = Stats.Instance;
	}

	// Mise à jour de la carte grâce
	public void SetCard(Card c) {
		card = c;

		Name.text = c.name;
		transform.Find ("CardObjectImageBorder").GetComponentInChildren<Image> ().sprite = (Sprite) UnityEditor.AssetDatabase.LoadAssetAtPath(c.image, typeof(Sprite));
		Description.text = "";
		foreach(string str in c.description) {
			Description.text = Description.text + str + "\n";
		}
		Cost.text = c.cost.ToString();
	}

	// Lorsqu'on saisi
	public void OnBeginDrag (PointerEventData eventData) {
		if (stats.isInstancied) {
			if (nativeParent != natalParent) {
				isMovable = true;
			} else if (nativeParent == placeholderParent && card.cost <= stats.points) {
				isMovable = true;
			}
		} else if (start.isInstancied) {
			if (nativeParent != natalParent) {
				isMovable = true;
			} else if (nativeParent == placeholderParent && card.cost <= start.points) {
				isMovable = true;
			}
		} else {
			if (nativeParent != placeholderParent) {
				isMovable = true;
			} else if (nativeParent == placeholderParent && card.cost <= monsterSetter.points) {
				isMovable = true;
			}
		}
	
		if (isMovable) {
			// Créer un espace vide quand la carte est selectionnée
			placeholder = new GameObject ();
			placeholder.name = "Vide";
			placeholder.transform.SetParent (this.transform.parent);
			LayoutElement le = placeholder.AddComponent<LayoutElement> ();
			le.preferredWidth = this.GetComponent<LayoutElement> ().preferredWidth;
			le.preferredHeight = this.GetComponent<LayoutElement> ().preferredHeight;
			le.flexibleWidth = 0;
			le.flexibleHeight = 0;
			placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());

			// Initialise le parent
			natalParent = this.transform.parent;
			placeholderParent = natalParent;
			this.transform.SetParent (this.transform.parent.parent);
			// Bloquant = false
			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
	}

	// Lors de la saisie
	public void OnDrag (PointerEventData eventData) {
		if (isMovable) {
			// Suit la position du pointeur de la souris
			this.transform.position = eventData.position;
			// Si différent de l'endroit de base alors on met à jour la place
			if (placeholder.transform.parent != placeholderParent)
				placeholder.transform.SetParent (placeholderParent);

			int newSiblingIndex = placeholderParent.childCount;

			// Decale les cartes
			for (int i = 0; i < placeholderParent.childCount; i++) {
				if (this.transform.position.x < placeholderParent.GetChild (i).position.x) {
					newSiblingIndex = i;

					if (placeholder.transform.GetSiblingIndex () < newSiblingIndex) {
						newSiblingIndex--;
					}

					break;
				} 
			}
			// Enlève le blocage
			placeholder.transform.SetSiblingIndex (newSiblingIndex);
		}
	}

	// Quand on lache l'objet
	public void OnEndDrag (PointerEventData eventData) {
		if (isMovable) {
			// On le place chez son parent
			this.transform.SetParent (natalParent);
			// A la place souhaitée
			this.transform.SetSiblingIndex (placeholder.transform.GetSiblingIndex ());
			// Bloquant = true
			GetComponent<CanvasGroup> ().blocksRaycasts = true;

			// Detruit l'espace vide
			Destroy (placeholder);
		}
		isMovable = false;
	}


}
