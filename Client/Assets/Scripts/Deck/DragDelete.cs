using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDelete : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, ICanvasRaycastFilter
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
		card = CardRecent.GetComponent<CardInDeckObject>().card;

        CardDrag = (GameObject)GameObject.Instantiate(CardRecent);
		CardDrag.GetComponent<CardInDeckObject> ().setCard (card, gameObject.GetComponent<CardInDeckObject>().Quantity);
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
            if (go.tag.Equals("CardGrid"))
            {
                GameObject[] cardlists = GameObject.FindGameObjectsWithTag("CardChosed");
                int num = -1;
				// On cherche si présent
                for (int i = 0; i < cardlists.Length; i++)
                {
					int cardId = cardlists[i].GetComponent<CardObject>().card.id;
                    if (cardId == card.id)
                        num = i;
                }

				// Supprimer du deck
				GameObject child = GameObject.Find ("DeckCardList");
				child.transform.parent.GetComponentInParent<DeckObject>().removeCard (card);

				// Si il n'est pas déjà présent dans l'inventaire
                if (num == -1)
                {
                    GameObject prefab = Resources.Load("Deck/card") as GameObject;
                    GameObject deckCard = (GameObject)GameObject.Instantiate(prefab);
					deckCard.GetComponent<CardObject> ().setCard (card,1);
                    Transform childTransform = deckCard.transform;
                    childTransform.SetParent(GameObject.Find("CardGrid").transform);
					deckCard.transform.localScale = new Vector3(1.4f,1,1);
                }
				// Si présent
                else
                {
                    int q = ++cardlists[num].GetComponent<CardObject>().Quantity;
                }

                Destroy(CardRecent);
				int quantity = CardDrag.transform.GetComponent<CardInDeckObject>().Quantity;
				CardDrag.transform.GetComponent<CardInDeckObject>().Quantity = quantity - 1;

                if (quantity == 1)
                    Destroy(CardDrag);
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
