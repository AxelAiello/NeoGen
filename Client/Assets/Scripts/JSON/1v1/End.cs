using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class End
	{
		private static End instance;
		public bool isInstancied;

		public string result = "Win";
		public List<Score> myScores;
		public List<Score> opponentScores;
		public Reward reward;
		public List<Card> cards;

		private End() {
			isInstancied = false;
			result = "Win";
			reward = new Reward ();
			myScores = new List<Score> ();
			myScores.Add (new Score());
			opponentScores = new List<Score> ();
			opponentScores.Add (new Score());
			cards = new List<Card> ();
			cards.Add (new Card ());
			cards.Add (new Card ());
			cards.Add (new Card ());
		}

		public void Iniciate(JSONObject obj) {
			myScores = new List<Score> ();
			opponentScores = new List<Score> ();
			cards = new List<Card> ();
			isInstancied = true;

			Debug.Log (obj);
			var mainObj = obj ["Details"];
			result = mainObj["Result"];

			var personalScore = mainObj["PersonalScore"];
			for(int j = 0; j < personalScore.Count; j++) {
				myScores.Add (new Score(personalScore[j]["Type"], personalScore[j]["Points"]));
			}	
			var scoreOpponent = mainObj["OpponentScore"];
			for(int j = 0; j < scoreOpponent.Count; j++) {
				opponentScores.Add (new Score(scoreOpponent[j]["Type"], scoreOpponent[j]["Points"]));
			}	
			var rewardObj = mainObj["Reward"];
			var hand = rewardObj["Cards"];
			for(int i = 0; i < hand.Count; i++) {
				List<string> list = new List<string>();
				var description = hand[i]["Description"];
				for(int j = 0; j < description.Count; j++) {
					list.Add (description[j]["Type"] + " " + description[j]["Modificator"]);
				}
				cards.Add (new Card(hand[i]["Id"], hand [i] ["Name"], hand[i]["Image"], hand[i]["Nature"], list, hand[i]["Cost"], hand[i]["Type"]));
			}
			reward = new Reward (cards, rewardObj ["PO"], rewardObj ["XP"]);
		}

		public static End Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new End();
				}
				return instance;
			}
		}

		public static void Reset() {
			instance = null;
		}
	}
}
