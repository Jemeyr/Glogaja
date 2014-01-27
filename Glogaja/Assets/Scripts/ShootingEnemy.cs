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

			var player = GameObject.Find("ship");
			if (player) {

				var direction = (player.transform.position - transform.position).normalized;

				var shot = (GameObject)Instantiate(Resources.Load("Prefabs/shot"));
				shot.transform.position = transform.position;
				shot.rigidbody.velocity = direction * 20;
				shot.layer = gameObject.layer;

				Debug.Log(shot.layer + ", " + gameObject.layer + ", " + Physics.GetIgnoreLayerCollision(shot.layer, gameObject.layer));
			}

			shotTimer.restart();
		}
	}
}
