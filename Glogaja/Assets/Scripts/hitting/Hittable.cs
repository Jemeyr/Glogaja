using UnityEngine;
using System.Collections;

public abstract class Hittable : MonoBehaviour {
	
	public bool destroyOnHit = true;
	
	public abstract void hit();
}