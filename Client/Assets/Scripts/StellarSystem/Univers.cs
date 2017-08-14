using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Univers : MonoBehaviour {

	public StellarSystem system;
	public Object[] mats;

	[System.Serializable]
	public class StellarSystem
	{
		public string nameOfSystem;
		public int planetsOnSystem;
		public Vector3 stellarOfSystem;
		public List<GameObject> planets = new List<GameObject>();

		public void Generate()
		{
			GameObject stellar = Instantiate(Resources.Load("StellarSystem/Stellar"), stellarOfSystem, Quaternion.identity) as GameObject;
			stellar.name = "Stellar : " + nameOfSystem;
			stellar.transform.parent = GameObject.Find("StellarSystem").transform;

			for (int i = 0; i < planetsOnSystem; i++)
			{
				Vector3 planetPos = new Vector3(Random.Range (stellarOfSystem.x - 200, stellarOfSystem.x - 50), stellarOfSystem.y, Random.Range (stellarOfSystem.z - 200, stellarOfSystem.z - 50));
				GameObject planet = Instantiate(Resources.Load("StellarSystem/Planet"), planetPos, Quaternion.identity) as GameObject;
				planet.transform.parent = stellar.transform;
				planet.GetComponent<Planet>().Init(stellar.transform);
				planets.Add(planet);
			}
		}
	}
		
	// Use this for initialization
	void Start () {
		mats = Resources.LoadAll("StellarSystem/Materials/");

		system = new StellarSystem ();
		system.nameOfSystem = "System " + Random.Range (0, 9) + "Z" + Random.Range (0, 9);
		system.planetsOnSystem = Random.Range (0, 6);
		system.stellarOfSystem = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		system.Generate ();
		foreach (GameObject planet in system.planets) {
			planet.GetComponent<Renderer> ().material = (Material)mats [Random.Range (0, mats.Length)];
		}
	}
}