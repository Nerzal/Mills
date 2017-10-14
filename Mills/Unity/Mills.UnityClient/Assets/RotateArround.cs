using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RotateArround : MonoBehaviour {

	public Camera Camera;
	public Transform Target;

	// Use this for initialization
	void Start () {
		this.Camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		float rotation = Input.GetAxis("Horizontal");
		float mouseRotation = Input.GetAxis("Mouse X");
		float usedRotation = 0;
		float rotationspeed = 5;
		if (Input.GetMouseButton(1)) {
			usedRotation = mouseRotation;
			Debug.Log(string.Format("Mouse moved by {0}", mouseRotation));
		} else {
			usedRotation = rotation;
		}

		usedRotation *= rotationspeed;
		this.Camera.transform.RotateAround(this.Target.position, Vector3.up, usedRotation);
	}
}
