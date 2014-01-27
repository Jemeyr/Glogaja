using UnityEngine;
using System.Collections;

public class HittableSticky : Hittable {

	public override void hit (GameObject hitter)
	{
		var sticky = gameObject.GetComponent<Sticky> ();

		Debug.Log ("Hit a hittable sticky");

		if (sticky == null)
						return;

		sticky.Unstick();
	}
}
