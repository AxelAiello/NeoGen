using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDeck : MonoBehaviour {
    public GameObject deck;
    private GameObject Window;

    public void deleteDeck()
    {
        Window = GameObject.Find("Canvas").transform.Find("PopUpDelete").gameObject;
        Window.SetActive(true);
        Window.GetComponent<ConfirmDelete>().deckDelete = deck;
       
    }
}
