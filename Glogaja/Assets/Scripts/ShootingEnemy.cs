using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]
public class ShootingEnemy : MonoBehaviour {
	private Timer shotTimer;
	private float	minShotDelay	= 2,
					maxShotDelay	= 4,
					aimWiggle		= 20; // degrees to either side

	// Use this for initialization
	void Start () {
	
		shotTimer = new Timer (Random.Range (minShotDelay, maxShotDelay));
	}
	
	// Update is called once per frame
	void Update () {
	
		shotTimer.update();

		if (shotTimer.hasFired) {

			var player = GameObject.Find("ship");
			if (player) {

				var delta = (player.transform.position - transform.position);

				var direction = Mathf.Atan2(delta.z, delta.x) * Mathf.Rad2Deg;
				direction += Random.Range(-aimWiggle, aimWiggle);
				direction *= Mathf.Deg2Rad;

				var directionV = new Vector3(Mathf.Cos(direction), 0, Mathf.Sin(direction));

				var shot = (GameObject)Instantiate(Resources.Load("Prefabs/shot"));
				shot.transform.position = transform.position;
				shot.rigidbody.velocity = directionV * 20;
				shot.layer = gameObject.layer;
			}

			shotTimer = new Timer (Random.Range (minShotDelay, maxShotDelay));
		}
	}
}
