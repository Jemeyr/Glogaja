using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float distance = 10.0f;
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.UpArrow)){
			distance *= 0.99f;
		} else if(Input.GetKey(KeyCode.DownArrow)){
			distance *= 1.01f;
		}


		transform.position = target.position + Vector3.up * distance;
		transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);

	}
}
