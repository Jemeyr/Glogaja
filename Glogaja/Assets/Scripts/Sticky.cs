using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class Sticky : MonoBehaviour {
	Dictionary<Sticky,FixedJoint> children = new Dictionary<Sticky, FixedJoint>();
	Boost booster;


	public void Run(){
		foreach(Sticky child in children.Keys){
			child.Run();
		}

		if(booster != null){
			booster.Run();
		}

	}

	void Start(){
		booster = GetComponent<Boost>();
	}

	void OnTriggerEnter(Collider other){
		GameObject part = other.gameObject;

		Sticky otherSticky = part.GetComponent<Sticky>();

		//add to tree if sticky

			Debug.Log("adding " + part.transform.name + " to " + transform.name);
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
