using UnityEngine;
using System.Collections;

public class SoftPlaneLock : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		Vector3 position = new Vector3(transform.position.x,0,transform.position.z);
		transform.position = position;
	}
}
