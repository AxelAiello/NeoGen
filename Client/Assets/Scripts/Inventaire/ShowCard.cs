using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCard : MonoBehaviour {
    //public GameObject window;
    public GameObject card;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showCard()
    {
        GameObject window = GameObject.Find("Canvas").transform.Find("Window").gameObject;
        window.SetActive(true);
        GameObject.Find("Canvas").transform.Find("CloseBtn").gameObject.SetActive(true);

        window.GetComponent<ShowInWindow>().Card = card;
        //Debug.Log("open");
    }
}
