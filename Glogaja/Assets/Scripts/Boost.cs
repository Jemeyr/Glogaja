using UnityEngine;
using System.Collections;

public class Boost : Effect {

	public float power = 1.0f;

	public override void Run () {
		if (Input.GetKey(KeyCode.W)){
			rigidbody.AddForce(power * transform.forward);
		}
		else if (Input.GetKey(KeyCode.S)){
			rigidbody.AddForce(power * -transform.forward);
		}
	}

	public override float GetPower() {
		return 0.0f;
	}

}
