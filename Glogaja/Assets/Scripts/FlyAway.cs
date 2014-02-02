using UnityEngine;
using System.Collections;

public class FlyAway : MonoBehaviour {

	public float speed = 5.0f;

	private Vector3 direction = Vector3.zero;

	void Start() {
		Fly();
	}

	public void Fly () {

		GameObject player = GameObject.Find("ship");

		Vector3 direction = Vector3.MoveTowards(transform.position, player.transform.position, 1.0f);
		direction.Normalize();

		if(rigidbody != null){
			rigidbody.AddForce(direction * speed);
		}

	}

}
