using UnityEngine;
using System.Collections;

[AddComponentMenu("PlayerStuff/PlayerMove")]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Sticky))]
public class PlayerMove : MonoBehaviour {
	private Sticky sticky;

	public float positionSlowdown = 0.9f;
	public float rotationSlowdown = 0.9f;

	public float power = 1.0f;
	public float torque = 1.0f;


	void Start () {
		sticky = GetComponent<Sticky>();
	}


	// Update is called once per frame
	void Update () {

		//move
		if (Input.GetKey(KeyCode.W)){
			rigidbody.AddForce(power * transform.forward);
		}
		else if (Input.GetKey(KeyCode.S)){
			rigidbody.AddForce(power * -transform.forward);
		}
		else{
			rigidbody.AddForce(-positionSlowdown * rigidbody.velocity);
		}

		//turn
		if (Input.GetKey(KeyCode.A)){
			rigidbody.AddTorque(torque * -transform.up);
		}
		else if (Input.GetKey(KeyCode.D)){
			rigidbody.AddTorque(torque * transform.up);
		}
		else{
			rigidbody.AddTorque(-rotationSlowdown * rigidbody.angularVelocity);
		}

		//test power value
		if (Input.GetKeyDown(KeyCode.Space)){
			Debug.Log(sticky.GetPower());
		}


		sticky.Run();
	}

}
