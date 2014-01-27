using UnityEngine;
using System.Collections;

public class HittableSticky : Hittable {

	public override void hit (GameObject hitter)
	{
		var sticky = gameObject.GetComponent<Sticky> ();

		if (sticky == null)
						return;

		sticky.Unstick();
	}
}
