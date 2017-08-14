using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Account : MonoBehaviour {

	public Text errortext;
	public InputField pseudo;
	public InputField password;
	public InputField mail;

	// Use this for initialization
	void Start () {
		errortext.text = "";
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown ("return")) {
			Create ();
		}
	}

	//Connexion avec le mot de passe et le pseudo
	public void Create() {
		// Si le speudo n'est pas déjà prit
		if(pseudo.text != "" && pseudo.text != "a") {
			// Si le mail est déjà attribué
			if (mail.text != "" && mail.text != "a") {
				// Si le mdp est correct
				if (password.text != "") {
					errortext.text = "";
					LoadingControlor.SetNextScene ("Scenes/ConnexionScene");
					SceneManager.LoadScene("Scenes/ChargementScene");
				} else {
					errortext.text = "Le mot de passe n'est pas correcte";
				}
			} else {
				errortext.text = "Le mail \"" + mail.text + "\" est déjà attribué";
			}
		} else {
			errortext.text = "Le pseudo \"" + pseudo.text + "\" est déjà attribué";
		}
	}
}