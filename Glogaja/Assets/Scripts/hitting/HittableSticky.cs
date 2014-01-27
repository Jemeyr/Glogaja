using UnityEngine;
using System.Collections;

public class HittableSticky : Hittable {

	public override void hit (GameObject hitter)
	{
		var sticky = GetComponent<Sticky> ();

		if (sticky == null)
						return;

		sticky.Unstick();
	}
}
