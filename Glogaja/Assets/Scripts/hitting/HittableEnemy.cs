using UnityEngine;
using System.Collections;

public class HittableEnemy : Hittable {

	public override void hit (GameObject hitter)
	{
		var direction = hitter.rigidbody.velocity.normalized;

		var numberToDrop = Random.Range (1, 3);

		for (var i = 0; i < numberToDrop; ++i) {

			var wiggle = Random.insideUnitCircle * 0.5f;
			var velocity = (direction + new Vector3(wiggle.x, 0, wiggle.y)) * 1;

			var item = (GameObject)Object.Instantiate(Resources.Load("Prefabs/jellybean"));
			item.transform.position = transform.position;
			item.rigidbody.velocity = velocity;
		}

		Destroy (gameObject);
	}
}
