using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingControlor : MonoBehaviour {

	private static string nextScene = "Scenes/ConnexionScene";

	public static AsyncOperation LoadNextLevel() {
		return SceneManager.LoadSceneAsync(nextScene);
	}

	public static string GetNextScene() {
		return nextScene;
	}

	public static void SetNextScene(string str) {
		nextScene = str;
	}
}
