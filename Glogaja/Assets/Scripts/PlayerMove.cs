using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("PlayerStuff/PlayerMove")]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Sticky))]
public class PlayerMove : MonoBehaviour {
	private Sticky sticky;
	private List<ParticleSystem> particleSystems;


	public float positionSlowdown = 0.9f;
	public float rotationSlowdown = 0.9f;

	public float power = 1.0f;
	public float torque = 1.0f;


	void Start () {
		sticky = GetComponent<Sticky>();

		particleSystems = new List<ParticleSystem>();

		ParticleSystem[] systems = GetComponentsInChildren<ParticleSystem>();
		foreach(ParticleSystem system in systems){
			particleSystems.Add (system);
		}
	}


	// Update is called once per frame
	void Update () {

		//move
		if (Input.GetKey(KeyCode.W)){
			rigidbody.AddForce(power * transform.forward);

			foreach(ParticleSystem s in particleSystems){
				s.startSpeed = 5;
				s.enableEmission = true;
			}
		}
		else if (Input.GetKey(KeyCode.S)){
			rigidbody.AddForce(power * -transform.forward);

			foreach(ParticleSystem s in particleSystems){
				s.startSpeed = -5;
				s.enableEmission = true;
			}
		}
		else{
			rigidbody.AddForce(-positionSlowdown * rigidbody.velocity);

			
			foreach(ParticleSystem s in particleSystems){
				s.enableEmission = false;
			}
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


	public void AddEngine(ParticleSystem s){
		particleSystems.Add(s);
	}

	public void RemoveEngine(ParticleSystem s){
		particleSystems.Remove(s);
	}


}
