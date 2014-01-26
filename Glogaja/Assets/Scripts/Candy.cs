using UnityEngine;
using System.Collections;

public class Candy : Effect {

	public float power = 1.0f;

	public override void Run(){}
	
	public override float GetPower(){
		return power;
	}

}
