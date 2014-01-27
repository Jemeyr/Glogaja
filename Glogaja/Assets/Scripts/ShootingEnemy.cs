using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]
public class ShootingEnemy : MonoBehaviour {
	private Timer shotTimer;

	// Use this for initialization
	void Start () {
	
		shotTimer = new Timer (2);
	}
	
	// Update is called once per frame
	void Update () {
	
		shotTimer.update();

		if (shotTimer.hasFired) {

			Debug.Log("Firing!");

			var player = GameObject.Find("ship");
			if (player) {

				Debug.Log("Player found!");

				var direction = (player.transform.position - transform.position).normalized;

				var shot = (GameObject)Instantiate(Resources.Load("Prefabs/shot"));
				shot.transform.position = transform.position;
				shot.rigidbody.velocity = direction * 20;

				Physics.IgnoreCollision(gameObject.collider, shot.collider);
			}

			shotTimer.restart();
		}
	}
}
