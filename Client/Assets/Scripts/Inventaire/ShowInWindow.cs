using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInWindow : MonoBehaviour {
    public GameObject Window;
    public GameObject Card;
    private GameObject Show;
    public GameObject CloseBtn;

	// Use this for initialization
	void Start () {
        Show = (GameObject)Instantiate(Card);
        Show.transform.SetParent(Window.transform);
        Show.transform.localScale = new Vector3(3, 3, 3);
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void Close()
    {
        Window.SetActive(false);
        GameObject.Find("CloseBtn").SetActive(false);
    }
}
