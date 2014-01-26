using UnityEngine;
using System.Collections;

public class Blast : Effect {

	public override void Run ()
	{
		if (Input.GetKey (KeyCode.Space)) {

			Debug.Log("Blasting!");
		}
	}
}
