using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalNumber : MonoBehaviour {
    private int number;

	// Use this for initialization
	void Start () {
        GameObject[] cards = GameObject.FindGameObjectsWithTag("CardChosed");
        number = 0;
        for(int i = 0; i < cards.Length; i++)
        {
            number += cards[i].GetComponent<CardObject>().Quantity;
        }

        
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("Number").GetComponent<Text>().text = number.ToString();

    }
}
