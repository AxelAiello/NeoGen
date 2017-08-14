using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour {

	public Text errortext;
	public InputField pseudo;
	public InputField password;

	// Use this for initialization
	void Start () {
		errortext.text = "";
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown ("return")) {
			LoginAccount();
		}
	}

	//Connexion avec le mot de passe et le pseudo
	public void LoginAccount() {
		// Si c'est le bon mot de passe pour le bon compte
		if (pseudo.text == "Baal" || pseudo.text == "Enlil") {
			AssemblyCSharp.TemporalPerso.setToken (pseudo.text);
			errortext.text = "";
			LoadingControlor.SetNextScene ("Scenes/MenuScene");
			SceneManager.LoadScene("Scenes/ChargementScene");
		}
		// Si le compte n'existe pas
		else if (pseudo.text != "a") {
			errortext.text = "Le pseudo \"" + pseudo.text + "\" est inconnu";
		} 
		// Si le compte existe mais ce n'est pas le bon mot de passe
		else if (password.text != "a") {
			errortext.text = "Mauvais mot de passe";
		} 
	}

	//Connexion avec le mot de passe et le pseudo
	public void CreateAccount() {
		errortext.text = "";
		LoadingControlor.SetNextScene ("Scenes/CompteScene");
		SceneManager.LoadScene("Scenes/ChargementScene");
	}

	//Connexion avec le mot de passe et le pseudo
	public void ForgetAccount() {
		//errortext.text = "";
		//LoadingControlor.SetNextScene ("Scenes/...");
		//SceneManager.LoadScene("Scenes/ChargementScene");
	}

}
