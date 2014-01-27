using UnityEngine;
using System.Collections;

public class Hitter : MonoBehaviour
{
	public bool destroyOnHit = true;
	
	void OnCollisionEnter(Collision collision){

		hit (collision.gameObject);
	}

	void OnTriggerEnter(Collider other) {

		hit (other.gameObject);
	}

	private void hit(GameObject other) {

		var hittable = other.GetComponent<Hittable> ();
		
		if (hittable == null)
			return;
		
		hittable.hit(gameObject);
		
		if (destroyOnHit)
			Destroy (gameObject);
	}
}