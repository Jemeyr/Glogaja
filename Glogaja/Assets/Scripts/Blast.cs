using UnityEngine;
using System.Collections;

public class Blast : Effect {
	public GameObject	shot;
	public double		blastPeriod = 0.5,
						shotSpeed = 20;
	private Timer		blastTimer;
	private bool		canBlast = true;

	public override void Run ()
	{
		if (canBlast) {

			if (Input.GetKey (KeyCode.Return)) {

				var newShot = (GameObject)Instantiate(shot);
				newShot.transform.position = gameObject.transform.position;
				newShot.rigidbody.velocity = gameObject.transform.forward * (float)shotSpeed;
				Physics.IgnoreCollision(newShot.collider, gameObject.collider);

				canBlast = false;
				blastTimer = new Timer (blastPeriod);
			}

		} else {

			blastTimer.update();
			if (blastTimer.hasFired) canBlast = true;
		}
	}
}
