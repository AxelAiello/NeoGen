using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour {

	public Image Loadingbar;
	public Text Loadingtext;
	private float timeToWait = 0.5f;
	private int counter = 0;

	// Use this for initialization
	void Start () {
		Loadingbar.fillAmount = 0f;
		Loadingtext.text = "Loading 00%";
		StartCoroutine (LoadGameSceneFalse());
	}

	private IEnumerator LoadGameSceneFalse() {
		while(counter < 6) {
			yield return new WaitForSeconds(timeToWait);
			counter++;
			float progress = Mathf.Clamp01(counter * 0.05f);
			Loadingbar.fillAmount = progress;
			Loadingtext.text = "Loading " + (progress * 100) + "%";
		}
		StartCoroutine (LoadGameSceneTrue());
	}

	private IEnumerator LoadGameSceneTrue() {
		AsyncOperation result = LoadingControlor.LoadNextLevel ();
		while(result.isDone) {
			float progress = Mathf.Clamp01(result.progress/0.99f);
			if(progress < 0.3f) {
				progress = Mathf.Clamp01(counter * 0.3f);
				Loadingbar.fillAmount = progress;
				Loadingtext.text = "Loading " + (progress * 100) + "%";
			} else {
				Loadingbar.fillAmount = progress;
				Loadingtext.text = "Loading " + (progress * 100) + "%";
			}
			yield return null;
		}
		yield return null;
	}

}
