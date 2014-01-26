using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	
	// Update is called once per frame
	void Update () {

		transform.position = target.position;
		transform.position += Vector3.up * 10.0f;



	}
}
