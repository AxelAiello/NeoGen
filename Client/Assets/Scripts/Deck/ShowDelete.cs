using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDelete : MonoBehaviour {
    private GameObject[] deleteBtns;
    public GameObject deleteDeckBtn;

    

    // Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void showBtn()
    {
        GameObject[] decks = GameObject.FindGameObjectsWithTag("DeckList");
        deleteBtns = new GameObject[decks.Length];
        for (int i = 0; i < decks.Length; i++)
        {
            Transform deckTran = decks[i].transform;
            Transform delete = deckTran.Find("DeleteBtn");
            deleteBtns[i] = delete.gameObject;
        }

        if (deleteDeckBtn.GetComponentInChildren<Text>().text == "Supprimer" && deleteBtns.Length != 0)
        {
            for (int i = 0; i < deleteBtns.Length; i++)
            {
                deleteBtns[i].SetActive(true);
            }
            deleteDeckBtn.GetComponentInChildren<Text>().text = "Annuler";
        }
        else
        {
            for (int i = 0; i < deleteBtns.Length; i++)
            {
                deleteBtns[i].SetActive(false);
            }
            deleteDeckBtn.GetComponentInChildren<Text>().text = "Supprimer";
        }
        
        
    }
}
