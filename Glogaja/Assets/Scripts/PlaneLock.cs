using UnityEngine;
using System.Collections;

public class PlaneLock : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Vector3 position = new Vector3(transform.position.x,0,transform.position.z);
		Vector3 rotation = new Vector3(0,transform.rotation.eulerAngles.y,0);

		transform.position = position;
		transform.rotation = Quaternion.Euler(rotation);

	}
}
