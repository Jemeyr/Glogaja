using UnityEngine;
using System.Collections;

public class HittableEnemy : Hittable {

	public override void hit ()
	{
		var numberToDrop = Random.Range (1, 3);

		for (var i = 0; i < numberToDrop; ++i) {

			var initialVelocity = Random.insideUnitCircle * 2;

			var item = (GameObject)Object.Instantiate(Resources.Load("Prefabs/jellybean"));
			item.transform.position = transform.position;
			item.rigidbody.velocity = initialVelocity;
		}
	}
}
