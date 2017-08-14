using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using AssemblyCSharp;
using System.Threading;

public class MatchMaking : MonoBehaviour {

	ServerAccess server;
	ParseJSON parse;
	private float timeToWait = 5f;
    // Use this for initialization
    void Start()
	{
		server = ServerAccess.Instance;
		parse = new ParseJSON ();
		Debug.Log ("Match Making");
		server.Sender (parse.InitialisationFunction (TemporalPerso.getToken (), "1v1", 0, 0).ToString ());
	}
	void Update() {
		/*print ("up");*/
		string val = server.Reciever();
		if (val != "")
		{
			parse.ReadJSON ((JSONObject)JSON.Parse (val));
			SceneManager.LoadScene ("Scenes/Mode1v1");
            StartCoroutine(LoadMatchMaking());
		}
		

	}

	private IEnumerator LoadMatchMaking() {
		yield return new WaitForSeconds(timeToWait);
		SceneManager.LoadScene ("Scenes/Mode1v1");
	}

}