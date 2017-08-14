using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mode : MonoBehaviour {

	public void GoToZoo() {
		//LoadingControlor.SetNextScene ("Scenes/...");
		//SceneManager.LoadScene ("Scenes/ChargementScene");
	}

	public void GoToIA() {
		//LoadingControlor.SetNextScene ("Scenes/...");
		//SceneManager.LoadScene ("Scenes/ChargementScene");
	}

	public void GoTo1v1() {
		LoadingControlor.SetNextScene ("Scenes/Mode1v1");
		SceneManager.LoadScene("Scenes/ChooseCreature");
	}
}
