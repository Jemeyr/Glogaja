using UnityEngine;
using System.Collections;

public abstract class Hittable : MonoBehaviour {
		
	public abstract void hit(GameObject hitter);
}