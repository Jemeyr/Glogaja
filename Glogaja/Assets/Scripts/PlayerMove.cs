using UnityEngine;
using System.Collections;

[AddComponentMenu("PlayerStuff/PlayerMove")]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Sticky))]
public class PlayerMove : MonoBehaviour {
	private Sticky sticky;


	void Start () {
		sticky = GetComponent<Sticky>();
	}


	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.W)){
			rigidbody.AddForce(transform.forward);
		}
		else if (Input.GetKey(KeyCode.S)){
			rigidbody.AddForce(-transform.forward);
		}
		if (Input.GetKey(KeyCode.A)){
			rigidbody.AddTorque(-transform.up);
		}
		else if (Input.GetKey(KeyCode.D)){
			rigidbody.AddTorque(transform.up);
		}

		//slow down eventually
		rigidbody.AddForce(-0.1f * rigidbody.velocity);
		rigidbody.AddTorque(-0.1f * rigidbody.angularVelocity);

		sticky.Run();
	}

}
