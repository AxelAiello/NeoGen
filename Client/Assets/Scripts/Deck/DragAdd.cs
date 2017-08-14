using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAdd : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, ICanvasRaycastFilter
{

    private static Transform canvasTra;
    private Transform nowParent;
    private bool isRaycastLocationValid = true;
    private Camera canvasCamera = null;
    private GameObject CardDrag;
    private int index;
	private Card card;
    private GameObject CardRecent;

    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        return isRaycastLocationValid;
    }

    public void OnBeginDrag(PointerEventData eventData) //begin drag
    {
		CardRecent = transform.gameObject;
		index = CardRecent.transform.GetSiblingIndex();
		card = gameObject.GetComponent<CardObject>().card;

        CardDrag = (GameObject)GameObject.Instantiate(CardRecent);
		//CardDrag.SetActive (false);
		CardDrag.GetComponent<CardObject> ().setCard (card, gameObject.GetComponent<CardObject>().Quantity);
        CardDrag.transform.SetParent(CardRecent.transform.parent);
		CardDrag.transform.localScale = transform.localScale;
        CardDrag.transform.SetSiblingIndex(index);

        if (canvasTra == null)
            canvasTra = GameObject.Find("Canvas").transform;
        canvasCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        nowParent = CardRecent.transform.parent; //init parent of object
        CardRecent.transform.SetParent(canvasTra); // drag object on the canvas

        isRaycastLocationValid = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GameObject.FindGameObjectsWithTag("DeckCardList") != null)
            CardRecent.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject go = eventData.pointerCurrentRaycast.gameObject;

        if (go != null)
        {
            if (go.tag.Equals("DeckCardList"))
            {
                GameObject[] cardlists = GameObject.FindGameObjectsWithTag("CardInDeck");
                int num = -1;
				// On cherche si déjà présent
                for (int i = 0; i < cardlists.Length; i++)
                {
					int cardId = cardlists[i].GetComponent<CardInDeckObject>().card.id;
                    if (cardId == card.id)
                        num = i;
                }
				// Si il n'est pas déjà présent dans l'inventaire
                if (num == -1)
                {
                    GameObject prefab = Resources.Load("Deck/cardInDeck") as GameObject;
                    GameObject deckCard = (GameObject)GameObject.Instantiate(prefab);
					deckCard.GetComponent<CardInDeckObject> ().setCard (card,1);
                    Transform childTransform = deckCard.transform;
					GameObject g = GameObject.Find ("DeckCardList");
					childTransform.SetParent(g.transform);
					deckCard.transform.localScale = transform.localScale;
                }
				// Si déjà présent
                else
                {
					int q = ++cardlists[num].GetComponent<CardInDeckObject>().Quantity;
                }

				// on ajoute au deck
				GameObject child = GameObject.Find ("DeckCardList");
				child.transform.parent.GetComponentInParent<DeckObject>().addCard (card);

				// on détruit l'ancienne carte
                Destroy(CardRecent);
                int quatity = CardDrag.transform.GetComponent<CardObject>().Quantity;
                CardDrag.transform.GetComponent<CardObject>().Quantity = quatity - 1;
				// si il y en a plus on détruit la carte fantome
                if (quatity == 1)
                    Destroy(CardDrag);
				//else
					//CardDrag.SetActive (true);
            }
            else
            {
                Destroy(CardRecent);
            }
        }
        else
        {
            Destroy(CardRecent);
        }
        isRaycastLocationValid = true;
    }


    private void SetParentAndPosition(Transform child, Transform parent)
    {
        child.SetParent(parent);
        child.position = parent.position;
        child.SetSiblingIndex(index);
    }
}
