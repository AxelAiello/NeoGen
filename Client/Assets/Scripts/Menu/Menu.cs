using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using AssemblyCSharp;

public class Menu : MonoBehaviour {

	public GameObject listMenu;
	public GameObject listModes;
	private bool ismenu = true;

	void Start() {
		listMenu.SetActive (ismenu);
		listModes.SetActive (!ismenu);
	}

	public void GoToProfil() {
		//LoadingControlor.SetNextScene ("Scenes/Deck");
		//SceneManager.LoadScene ("Scenes/ChargementScene");
	}

	public void GoToCreation() {
		 LoadingControlor.SetNextScene ("Scenes/CreateCreature");
		 SceneManager.LoadScene ("Scenes/ChargementScene");
	}

	public void GoToTrade() {
		//LoadingControlor.SetNextScene ("Scenes/Deck");
		//SceneManager.LoadScene ("Scenes/ChargementScene");
	}

	public void GoToParameters() {
		//LoadingControlor.SetNextScene ("Scenes/Deck");
		//SceneManager.LoadScene ("Scenes/ChargementScene");
	}

	public void GoToInventory() {
		LoadingControlor.SetNextScene ("Scenes/Deck");
		SceneManager.LoadScene ("Scenes/Inventaire");
	}

	public void GoToDeck() {
		LoadingControlor.SetNextScene ("Scenes/Deck");
		SceneManager.LoadScene ("Scenes/ChargementScene");
	}

	public void GoToFusion() {
		//LoadingControlor.SetNextScene ("Scenes/Deck");
		//SceneManager.LoadScene ("Scenes/ChargementScene");
	}

	public void PrintModes() {
		ismenu = !ismenu;
		listMenu.SetActive (ismenu);
		listModes.SetActive (!ismenu);
	}

	public void PrintMenu() {
		ismenu = !ismenu;
		listMenu.SetActive (ismenu);
		listModes.SetActive (!ismenu);
	}
}
