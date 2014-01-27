using UnityEngine;
using System.Collections;

public class Blast : Effect {
	public double		blastPeriod = 0.5,
						shotSpeed = 20;
	private Timer		blastTimer;
	private bool		canBlast = true;

	public override void Run ()
	{
		if (canBlast) {

			if (Input.GetKey (KeyCode.Return)) {

				var shot = (GameObject)Instantiate(Resources.Load("Prefabs/shot"));
				shot.transform.position = gameObject.transform.position;
				shot.rigidbody.velocity = gameObject.transform.forward * (float)shotSpeed;
				shot.layer = gameObject.layer;

				canBlast = false;
				blastTimer = new Timer (blastPeriod);
			}

		} else {

			blastTimer.update();
			if (blastTimer.hasFired) canBlast = true;
		}
	}
}
