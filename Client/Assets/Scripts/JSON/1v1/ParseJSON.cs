using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class ParseJSON {

	public MonsterSetter monsterSetter = MonsterSetter.Instance;
	public StartPartie start = StartPartie.Instance;
    public MonsterList monsterList = MonsterList.Instance;
	public Stats stats = Stats.Instance;
	public Word word = Word.Instance;
	public Draw draw = Draw.Instance;
	public End end = End.Instance;

	public ParseJSON() {
		monsterSetter = MonsterSetter.Instance;
		start = StartPartie.Instance;
		monsterList = MonsterList.Instance;
		stats = Stats.Instance;
		word = Word.Instance;
		draw = Draw.Instance;
		end = End.Instance;
	}

	public void ReadJSON(JSONObject obj) {
		string type = obj ["Type"];
		switch (type) {
		case "MonsterSetter":
			monsterSetter.Iniciate (obj);
			Debug.Log (obj);
			break;
        case "MonsterList":
            monsterList.Iniciate(obj);
			Debug.Log (obj);
            break;
		case "Start":
			start.Iniciate(obj);
			Debug.Log (obj);
			break;
		case "Stats":
			stats.Iniciate(obj);
			Debug.Log (obj);
			break;
		case "World":
			word.Iniciate(obj);
			Debug.Log (obj);
			break;
		case "Draw":
			draw.Iniciate(obj);
			Debug.Log (obj);
			break;
		case "End":
			end.Iniciate(obj);
			Debug.Log (obj);
			break;
		case "TakeDecks":
			end.Iniciate(obj);
			Debug.Log (obj);
			break;
		default :
			break;
		}
	}

	public JSONObject InitialisationFunction(string token, string match, int monster, int deck) {
		JSONObject mainObj = new JSONObject();
		mainObj.Add ("Type", "InitialisationMonster");

		JSONObject obj = new JSONObject();
		obj.Add("Token", token);
		obj.Add("Match", match);
		obj.Add("Monster", monster);
		obj.Add("Deck", deck);
		mainObj.Add ("Details", obj);
		Debug.Log (mainObj);
		return mainObj;
	}

	public JSONObject InitialisationUser(string token, string match)
	{
		JSONObject mainObj = new JSONObject();
		mainObj.Add("Type", "InitialisationUser");

		JSONObject obj = new JSONObject();
		obj.Add("Token", token);
		obj.Add("Match", match);
		mainObj.Add("Details", obj);
		Debug.Log(mainObj);
		return mainObj;
	}

	public JSONObject InitialCardsFunction(List<int> list) {
		JSONObject mainObj = new JSONObject();
		mainObj.Add ("Type", "InitialCards");

		JSONArray obj = new JSONArray();
		for (int i = 0; i < list.Count; i++) {
			obj.Add ("Card", list[i]);
		}

		JSONObject objSon = new JSONObject();
		objSon.Add("Cards", obj);

		mainObj.Add ("Details", objSon);
		Debug.Log (mainObj);
		return mainObj;
	}

	public JSONObject SaveDeckFunction(List<Deck> decks) {
		JSONObject mainObj = new JSONObject();
		mainObj.Add ("Type", "SaveDeck");

		JSONArray obj = new JSONArray();
		for (int i = 0; i < decks.Count; i++) {
			JSONObject deck = new JSONObject ();
			JSONArray cardsArray = new JSONArray();
			for(int j = 0; j < decks[i].theDeck.Count; j++) {
				cardsArray.Add ("Card", decks[i].theDeck[j].id);
			}
			deck.Add ("Cards", cardsArray);
			deck.Add ("Id", decks[i].id);
			deck.Add ("Name", decks[i].name);
			obj.Add ("Deck", deck);
		}

		JSONObject objSon = new JSONObject();
		objSon.Add("Decks", obj);

		mainObj.Add ("Details", objSon);
		Debug.Log (mainObj);
		return mainObj;
	}

	public JSONObject PlayCardFunction(int nbr) {
		JSONObject mainObj = new JSONObject();
		mainObj.Add ("Type", "PlayCard");

		JSONObject obj = new JSONObject();
		obj.Add("Card", nbr);
		mainObj.Add ("Details", obj);
		Debug.Log (mainObj);
		return mainObj;
	}
}
