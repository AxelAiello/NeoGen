using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using UnityEngine.UI;

public class CreatureView : MonoBehaviour {

	private StartPartie start;
	private Word world;

	private Monster creature;
	private Monster creatureOpponent;
	public Image creatureImage;
	public string currentImage;
	public Text creatureName;
	public Text creatureDescription; 

	private bool isCreature;

	// Use this for initialization
	void Start () {
		isCreature = true;
		start = StartPartie.Instance;
		world = Word.Instance;
		creature = new Monster ();
		creatureOpponent = new Monster ();

		creatureName.text = "";
		creatureDescription.text = ""; 
	}
	
	// Update is called once per frame
	void Update () {
		if(world.isInstancied) {
			creature = world.monsters [0];
			creatureOpponent = world.monsters [1];
		} else if(start.isInstancied) {
			creature = start.monster;
			creatureOpponent = start.monsterOpponent;
		} else {
			// Wait Start
		}

		if (isCreature) {
			creatureName.text = creature.Name;
			currentImage = creature.Image;
			string str = "";
			foreach (KeyValuePair<CaracteristicGen, int> p in creature.MapGenetics) {
				str = str + p.Key.ToString () + " " + p.Value + "\n";
			}
				
      		creatureDescription.text = str;
		} else {
			creatureName.text = creatureOpponent.Name;
			currentImage = creatureOpponent.Image;
			string str = "";
			foreach (KeyValuePair<CaracteristicGen, int> p in creatureOpponent.MapGenetics) {
				str = str + p.Key.ToString () + " " + p.Value + "\n";
			}
			creatureDescription.text = str;
		}
		creatureImage.GetComponent<Image>().sprite = (Sprite) UnityEditor.AssetDatabase.LoadAssetAtPath(currentImage, typeof(Sprite));
	}

	public void viewOpponentCreature() {
		isCreature = false;
	}

	public void viewCreature() {
		isCreature = true;
	}
}
