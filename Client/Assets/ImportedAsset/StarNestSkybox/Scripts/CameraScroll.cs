using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraScroll : MonoBehaviour {
	public float lookSensitivity = 5;
	float yaw = 0;
	float pitch = 0;
	public static CameraScroll main;

	void Awake() { main = this; }
	
	void Update() {
		transform.rotation = Quaternion.Euler(pitch, yaw, 0);

		if (Input.GetMouseButton(1)) {
			yaw += Input.GetAxis("Mouse X") * lookSensitivity;
			pitch -= Input.GetAxis("Mouse Y") * lookSensitivity;
			if (yaw > 360) { yaw -= 360; }
			if (yaw < 0) { yaw += 360; }
			pitch = Mathf.Clamp(pitch, -89, 89);
		}
	}
}
