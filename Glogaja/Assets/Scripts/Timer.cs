using System;
using UnityEngine;

// Ugh, Unity *has* to have something like this built in,
// but the first couple google hits didn't show any, so here we go
public class Timer {
	private double	period,
					elapsed;

	public Timer (double periodInSeconds) {

		period	= periodInSeconds;
		elapsed	= 0;
	}

	public void update() {

		elapsed += Time.deltaTime;
	}

	public bool hasFired {
		get { return elapsed >= period; }
	}
}
