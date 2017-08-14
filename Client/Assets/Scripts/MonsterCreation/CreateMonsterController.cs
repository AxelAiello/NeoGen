using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateMonsterController : MonoBehaviour {

  public Button HomeButton;

  // Use this for initialization
  void Start () {

    HomeButton.onClick.AddListener(delegate { GoHome(); });
    
  }
	
  void GoHome()
  {
    SceneManager.LoadScene("Scenes/MenuScene");
  }
	// Update is called once per frame
	void Update () {
		
	}
}
