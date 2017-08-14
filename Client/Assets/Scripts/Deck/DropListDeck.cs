using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropListDeck : MonoBehaviour {
    public GameObject DeckCardList;
    public GameObject DeckList;
    private GameObject[] decklists;
    private GameObject CreateBtn;
    private GameObject DeleteBtn;

    public void Awake()
    {
        decklists = GameObject.FindGameObjectsWithTag("DeckList");
        CreateBtn = GameObject.Find("CreateBtn");
        DeleteBtn = GameObject.Find("DeleteDeckBtn");
    }

    public void Click()
    {
        
        if (DeckCardList.activeSelf == true)
        {
            DeckCardList.SetActive(false);
            CreateBtn.SetActive(true);
            DeleteBtn.SetActive(true);
            HideOrPresent(true);
        }

        else
        {
            DeckCardList.SetActive(true);
            CreateBtn.SetActive(false);
            DeleteBtn.SetActive(false);
            HideOrPresent(false);

        }
    }

    public void HideOrPresent(bool b)
    {
        int selfIndex = DeckList.transform.GetSiblingIndex();

        for (int i = selfIndex+1; i < decklists.Length; i++)
        {
            DeckList.transform.parent.GetChild(i).gameObject.SetActive(b);
            
        }
    }
}
