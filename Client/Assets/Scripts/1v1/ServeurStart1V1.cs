using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class ServeurStart1V1 : MonoBehaviour {

	// Variables pour les instances
	ServerAccess server;
	ParseJSON parse;
	MonsterSetter monsterSetter;
	StartPartie start;
	End end;

	// Deck
	public GameObject deck1;	
	public GameObject deck2;
	// Temps timer
	public Text timer;
	public float time = 600f;

	// Fenêtres éphémères 
	public GameObject windowloading;
	public GameObject windowCheck;
	public GameObject windowHand;
	public GameObject windowDropZone;

	// Fenetre View
	public GameObject windowCreatures;
	public GameObject windowMap;
	public GameObject windowGraph;
	public GameObject windowMutation;

	// List de cartes selectionnées
	public List<int> listCard;

	// Fenêtre de résultat
	public GameObject windowScore;
	public Text result;
	public Text score;
	public Text totalScore;
	public Text opponentScore;
	public Text opponentTotalScore;

	// Fenêtre des récompenses
	public bool firstTimePoint = true;
	public GameObject windowReward;
	public Text xpText;
	public Text poText;
	public GameObject cardsReward;

	void Start () {
		// Connexion socket partie 1v1
        server = ServerAccess.Instance;
        parse = new ParseJSON();
		monsterSetter = MonsterSetter.Instance;
		start = StartPartie.Instance;
		end = End.Instance;

    	// Timer Initialisation
   	 	timer.text = "";
		time = 0f;

		windowCreatures.gameObject.SetActive (false);
		/*windowMap.gameObject.SetActive (false);
		windowGraph.gameObject.SetActive (false);
		windowMutation.gameObject.SetActive (false);*/

		windowCheck.gameObject.SetActive (true);
		deck1.gameObject.SetActive (false);
		deck2.gameObject.SetActive (false);
		windowloading.gameObject.SetActive (false);
		windowScore.gameObject.SetActive (false);
		windowReward.gameObject.SetActive (false);
  }

  // Update is called once per frame
  void Update () {
		// Lecture du serveur
		Listen();
		// Si on est à la fin
		if (end.isInstancied) {
			UpdateEnd ();
		} 
		// Si on recoit les infos de la partie
		else if (start.isInstancied) {
			UpdateStart ();
		} 
		// Sinon on a les infos de base
		else {
			UpdateMonsterSetter ();
		}

		// Timer Mise A Jour
		int minutes = ((int)time / 60);
		int secondes = ((int)time % 60);

		if (minutes == 0) {
			timer.text = "00";
		} else if (minutes < 10) {
			timer.text = "0" + minutes;
		} else {
			timer.text = "" + minutes;
		}
		if (secondes < 10) {
			timer.text = timer.text  + ":0" + secondes;
		} else {
			timer.text = timer.text  + ":" + secondes;
		}
	}
		
	private void UpdateMonsterSetter() {
		// Mise à jour des données
		monsterSetter.time =  monsterSetter.time - Time.deltaTime;
		if(monsterSetter.time < 0) {
			monsterSetter.time = 0;
		}
		time = monsterSetter.time;
	}

	private void UpdateStart() {
		// Mise à jour des fenêtres
		windowHand.gameObject.SetActive (true);
		windowDropZone.gameObject.SetActive (true);
		deck1.gameObject.SetActive (true);
		deck2.gameObject.SetActive (true);
		windowloading.gameObject.SetActive (false);
		windowCheck.gameObject.SetActive (false);
		// Mise à jour des données
		start.time =  start.time - Time.deltaTime;
		if(start.time < 0) {
			windowloading.gameObject.SetActive (true);
			start.time = 0;
		}
		time = start.time;
	}

	private void UpdateEnd() {
		// Mise à jour des fenêtres
		windowScore.gameObject.SetActive (true);

		// Mise à jour des réultats
		result.text = end.result;
		// Score
		score.text = "";
		int points = 0;
		foreach(Score s in end.myScores) {
			score.text = score.text + s.type + "\t" + s.points + " points\n";
			points = points + s.points;
		}
		totalScore.text = "TOTAL = " + points + " points";
		// Score de l'adversaire
		opponentScore.text = "";
		int opponentPoints = 0;
		foreach(Score s in end.opponentScores) {
			opponentScore.text = opponentScore.text + s.type + "\t" + s.points + " points\n";
			opponentPoints = opponentPoints + s.points;
		}
		opponentTotalScore.text = "TOTAL = " + opponentPoints + " points";

		//Mise à jour des récompenses
		poText.text = "PO : " + end.reward.po;
		xpText.text = "XP : " + end.reward.xp;
		if (firstTimePoint) {
			firstTimePoint = false;
			List<Card> hand = end.cards;
			// Mise à jour des données cartes
			int compteurCard = 0;
			foreach (Card card in hand) {
				GameObject c = Instantiate (Resources.Load ("Card/CardObject"), cardsReward.transform.position, Quaternion.identity) as GameObject;
				c.transform.SetParent (cardsReward.transform);
				c.transform.localScale = new Vector3(1f, 1f, 1f);
				c.name = "Card " + compteurCard;
				Draggable d = c.GetComponent<Draggable> ();
				d.SetCard (card);
				compteurCard++;
			}
		}
	}

	public void CheckMonsterSetter() {
		windowloading.gameObject.SetActive (true);
		windowCheck.gameObject.SetActive (false);
		windowHand.gameObject.SetActive (false);
		windowDropZone.gameObject.SetActive (false);
		// Manip Server pour envoyer les cartes selectionnées
		server.Sender(parse.InitialCardsFunction(listCard).ToString());
	}


	private void Listen() {
		string val = server.Reciever();
		if (val != "")
		{
			Debug.Log(val);
			parse.ReadJSON((JSONObject)JSON.Parse(val));
		}
	}

	public void LoadReward() {
		windowScore.gameObject.SetActive (false);
		windowReward.gameObject.SetActive (true);
	}

	public void LoadMenu() {
		LoadingControlor.SetNextScene ("Scenes/MenuScene");
		SceneManager.LoadScene ("Scenes/ChargementScene");
	}

	void OnDestroy() {
		server.StopConnection ();
		Draw.Reset ();
		End.Reset ();
		MonsterList.Reset ();
		MonsterSetter.Reset ();
		StartPartie.Reset ();
		Stats.Reset ();
		Word.Reset ();
	}


	public void viewCreatures() {
		windowCreatures.gameObject.SetActive (true);
		/*windowMap.gameObject.SetActive (false);
		windowGraph.gameObject.SetActive (false);
		windowMutation.gameObject.SetActive (false);*/
	}

	public void viewMap() {
		windowCreatures.gameObject.SetActive (false);
		/*windowMap.gameObject.SetActive (true);
		windowGraph.gameObject.SetActive (false);
		windowMutation.gameObject.SetActive (false);*/
	}

	public void viewGraph() {
		windowCreatures.gameObject.SetActive (false);
		/*windowMap.gameObject.SetActive (false);
		windowGraph.gameObject.SetActive (true);
		windowMutation.gameObject.SetActive (false);*/
	}

	public void viewMutation() {
		windowCreatures.gameObject.SetActive (false);
		/*windowMap.gameObject.SetActive (false);
		windowGraph.gameObject.SetActive (false);
		windowMutation.gameObject.SetActive (true);*/
	}

}
