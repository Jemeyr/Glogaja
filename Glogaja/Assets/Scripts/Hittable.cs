using UnityEngine;
using System.Collections;

public class Hittable : MonoBehaviour {
	
	public bool destroyOnHit = true;
	
	public void hit() {

		Debug.Log ("Hit!");
	}
}