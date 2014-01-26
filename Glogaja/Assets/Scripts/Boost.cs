using UnityEngine;
using System.Collections;

public class Boost : Effect {

	public float power = 1.0f;

	private ParticleSystem emitter;

	public Rigidbody body = null;

	
	public void Awake(){
		emitter = GetComponentInChildren<ParticleSystem>();	
		emitter.enableEmission = false;
	}


	public override void Run () {
		if (Input.GetKey(KeyCode.W)){
			emitter.startSpeed = 5;
			emitter.enableEmission = true;

			body.AddForceAtPosition(power * transform.forward, transform.position);
		}
		else if (Input.GetKey(KeyCode.S)){
			emitter.startSpeed = -5;
			emitter.enableEmission = true;

			body.AddForceAtPosition(power * -transform.forward, transform.position);
		}
		else{
			emitter.enableEmission = false;
		}
	}

	public override float GetPower() {
		return 0.0f;
	}

}
