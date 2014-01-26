using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {

	public float power = 1.0f;

	public void Run () {
		if (Input.GetKey(KeyCode.W)){
			rigidbody.AddForce(power * transform.forward);
		}
		else if (Input.GetKey(KeyCode.S)){
			rigidbody.AddForce(power * -transform.forward);
		}
	}
	

}
