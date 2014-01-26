using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class Sticky : MonoBehaviour {

	Dictionary<Sticky,FixedJoint> children = new Dictionary<Sticky, FixedJoint>();

	Effect effect;


	public void Run(){
		foreach(Sticky child in children.Keys){
			child.Run();
		}

		if(effect != null){
			effect.Run();
		}
	}

	//recursively collect all the candy powers
	public float GetPower(){
		float pow = 0.0f;

		if(effect != null){
			pow += effect.GetPower();
		}

		foreach(Sticky child in children.Keys){
			pow += child.GetPower();
		}

		return pow;
	}


	void Awake(){
		effect = GetComponent<Effect>();
	}

	void OnTriggerEnter(Collider other){
		GameObject part = other.gameObject;

		Sticky otherSticky = part.GetComponent<Sticky>();


		//remove the trigger
		part.collider.isTrigger = false;

		//add fixed joint to make them move together
		FixedJoint joint = transform.gameObject.AddComponent<FixedJoint>();
		joint.connectedBody = part.rigidbody;

		otherSticky = part.AddComponent<Sticky>();

		//add to tree
		children.Add(otherSticky,joint);
		 	


	}


}
