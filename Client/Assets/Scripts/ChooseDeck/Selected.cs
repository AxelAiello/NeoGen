 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour {
    public GameObject selectBtn;
    private GameObject check;
    private GameObject[] buttons;

	// Use this for initialization
	void Start () {
        check = selectBtn.transform.Find("Image").gameObject;
        buttons = GameObject.FindGameObjectsWithTag("SelectBtn");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void select()
	{
		for (int i = 0; i < buttons.Length; i++) {
			buttons [i].transform.Find ("Image").gameObject.SetActive (false);
		}
		check.SetActive (true);
		GameObject.Find ("Canvas").GetComponent<SystemChooseDeck> ().setActualChoice (transform.parent.GetComponent<ChooseDeckObject> ().Id);
     
	}
}
