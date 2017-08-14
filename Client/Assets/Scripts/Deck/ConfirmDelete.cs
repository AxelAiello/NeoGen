using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmDelete : MonoBehaviour {
    public GameObject deckDelete;
    public GameObject Window;

	// Use this for initialization
	void Start () {
        //Debug.Log(deckDelete.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Delete()
    {
        List<GameObject> deletecards = new List<GameObject>();
		foreach(Transform child in deckDelete.transform.Find("DeckCardScroll").Find("DeckCardList"))
        {
            deletecards.Add(child.gameObject);
        }

        GameObject[] cardlists = GameObject.FindGameObjectsWithTag("CardChosed");
        for(int i = 0; i < deletecards.Count; i++)
        {
			Card card = deletecards [i].GetComponent<CardInDeckObject> ().card;
			int quantity = deletecards [i].GetComponent<CardInDeckObject> ().Quantity;

            int num = -1;
            for(int j = 0; j < cardlists.Length; j++)
            {
                if(cardlists[j].GetComponent<CardObject>().Id == card.id)
                {
                    num = j;
                    break;
                }
            }

            Debug.Log(num);
            if(num == -1)
            {
                GameObject prefab = Resources.Load("Deck/card") as GameObject;
                GameObject deckCard = (GameObject)GameObject.Instantiate(prefab);
				deckCard.GetComponent<CardObject>().setCard(card, quantity);
                Transform childTransform = deckCard.transform;
                childTransform.SetParent(GameObject.Find("CardGrid").transform);
				deckCard.transform.localScale = new Vector3(1.4f,1,1);
            }
            else
            {
                cardlists[num].GetComponent<CardObject>().Quantity += quantity;
                cardlists[num].transform.Find("Quantity").GetComponentInChildren<Text>().text = cardlists[num].GetComponent<CardObject>().Quantity.ToString() ;
            }
        }


		GameObject.Find ("Canvas").GetComponent<SystemDeck> ().deleteDeck(deckDelete);
        Destroy(deckDelete);
        Debug.Log("Suppression reussie");
        Window.SetActive(false);
    }

    public void Cancel()
    {
        Window.SetActive(false);
    }
}
