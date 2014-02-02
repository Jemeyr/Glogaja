using UnityEngine;
using System.Collections;

public class FloatAway : MonoBehaviour {

	public float speed = 5;
	public float spin = 500;

	void Start(){
		Float();
	}

	public void Float () {
		float x = Random.Range(-1.0f, 1.0f);
		float z = Random.Range(-1.0f, 1.0f);

		float a = Random.Range(-1.0f, 1.0f);
		float b = Random.Range(-1.0f, 1.0f);
		float c = Random.Range(-1.0f, 1.0f);

		speed *= Random.Range(0.0f, 1.0f);
		spin *= Random.Range(0.0f, 1.0f);

		Vector3 direction = new Vector3(x,0.0f,z);
		direction.Normalize();

		Vector3 rot = new Vector3(a, b, c) *  spin;
		
		if(rigidbody != null){
			rigidbody.AddForce(direction * speed);
			rigidbody.AddTorque(rot);
		}
		
	}
	
}
