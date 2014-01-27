using UnityEngine;
using System.Collections;

public class FlyAway : MonoBehaviour {

	public float speed = 0.05f;

	private Vector3 direction = Vector3.zero;

	void Start () {
		float x = Random.Range(-1.0f, 1.0f);
		float z = Random.Range(-1.0f, 1.0f);

		direction = new Vector3(x,0.0f,z);
		direction.Normalize();


		if(rigidbody != null){
			rigidbody.AddForce(direction * 100 * speed);
		}

	}

}
