using UnityEngine;
using System.Collections;

public class Blast : Effect {
	public double	blastPeriod = 0.5;
	private Timer	blastTimer;
	private bool	canBlast = true;

	public override void Run ()
	{
		if (canBlast) {

			if (Input.GetKey (KeyCode.Return)) {

					Debug.Log ("Blasting!");

					canBlast = false;
					blastTimer = new Timer (blastPeriod);
			}

		} else {

			blastTimer.update();
			if (blastTimer.hasFired) canBlast = true;
		}
	}
}
