using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpWindow : MonoBehaviour {
    public GameObject window;
    public Text nameTxt;
    public Text errorTxt;

    public void Show()
    {
        window.SetActive(true);
    }


    public void Hide()
    {
        window.SetActive(false);
    }

    public void submit()
    {
        GameObject[] decklist = GameObject.FindGameObjectsWithTag("DeckList");
        int exist = 0;
        for(int i = 0; i < decklist.Length; i++)
        {
            if (decklist[i].GetComponentInChildren<Text>().text == nameTxt.text)
                exist++;
        }

        if(exist > 0)
            errorTxt.text = "Ce nom est déjà utilisé, entrez un nouveau nom !";
        else
        {
			// Enregistre le deck
			GameObject prefab = Resources.Load("Deck/deckList") as GameObject;
			GameObject panel = (GameObject)GameObject.Instantiate(prefab);
			panel.GetComponent<DeckObject> ().setDeck (new Deck(nameTxt.text));
			Transform childTransform = panel.transform;
			childTransform.SetParent(GameObject.Find("DeckListGrid").transform);
			panel.transform.localScale = new Vector3(1, 1, 1);

			GameObject.Find ("Canvas").GetComponent<SystemDeck> ().addDeck(panel);

            Hide();
        }
        
    }

    public void cancel()
    {
        Hide();
    }


}
