using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

	public Transform sun;
	public float speed;

	public void Init(Transform _sun)
	{
		sun = _sun;

		if (Random.Range(1, 10) >= 5)
		{
			speed = Random.Range(-15, -0.000001f);
		}
		else
		{
			speed = Random.Range(15, 0.000001f);
		}
	}

	// Update is called once per frame
	void Update () {
		transform.RotateAround(sun.position, new Vector3(0,1,0), speed * Time.deltaTime);
	}

}

	

