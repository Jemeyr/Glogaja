using UnityEngine;
using System.Collections;

[AddComponentMenu("PlayerStuff/PlayerMove")]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Sticky))]
public class PlayerMove : MonoBehaviour {
	private Sticky sticky;

	public float positionSlowdown = 0.9f;
	public float rotationSlowdown = 0.9f;


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
		else{
			rigidbody.AddForce(-positionSlowdown * rigidbody.velocity);
		}


		if (Input.GetKey(KeyCode.A)){
			rigidbody.AddTorque(-transform.up);
		}
		else if (Input.GetKey(KeyCode.D)){
			rigidbody.AddTorque(transform.up);
		}
		else{
			rigidbody.AddTorque(-rotationSlowdown * rigidbody.angularVelocity);
		}

		sticky.Run();
	}

}
