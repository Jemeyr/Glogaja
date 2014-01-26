using UnityEngine;
using System.Collections;

public class Hitter : MonoBehaviour
{
	public bool destroyOnHit = true;
	
	void OnCollisionEnter(Collision collision){

		var other = collision.gameObject;
		var hittable = other.GetComponent<Hittable> ();
		
		if (hittable == null)
			return;
		
		hittable.hit();
		
		if (hittable.destroyOnHit)
			Destroy (hittable.gameObject);
		
		if (destroyOnHit)
			Destroy (gameObject);
	}
}