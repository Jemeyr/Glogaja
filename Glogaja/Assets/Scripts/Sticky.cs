using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class Sticky : MonoBehaviour {

	Dictionary<Sticky,MassComponent> children = new Dictionary<Sticky, MassComponent>();

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
		Sticky otherSticky;


		//only player starts sticky, so run this on him.
		if(transform.GetComponent<Sticky>() == null){
			return;
		}

		GameObject part = other.gameObject;


		//remove the trigger
		part.collider.isTrigger = false;

		Rigidbody otherBody = part.transform.GetComponent<Rigidbody>();


		//I don't know why this happens sometimes, I assume it's because adding components isn't instant
		//either way, I'm just gonna return here in that case.
		if(otherBody == null){
			return;
		}


		Transform t = transform;
		while(t.parent != null){
			t = t.parent;
		}

		Rigidbody thisBody = t.GetComponent<Rigidbody>();

		float otherMass = otherBody.mass;
		float newMass = thisBody.mass + otherMass;

		//set new rigidbody mass
		thisBody.mass = newMass;


		//centers of mass
		Vector3 otherCoM = t.InverseTransformPoint(otherBody.worldCenterOfMass);
		Vector3 thisCoM = thisBody.centerOfMass;

		//difference
		Vector3 CoMDiff = otherCoM - thisCoM;

		//set new center of mass
		thisBody.centerOfMass = thisCoM + (otherMass/newMass) * CoMDiff;



		//destroy other rigidbody, they are now combined
		Destroy(part.transform.GetComponent<Rigidbody>());

		//add a sticky to the new piece
		otherSticky = part.AddComponent<Sticky>();

		//add it into heirarchy so it is connected
		part.transform.parent = transform;

		
		//add to tree
		MassComponent mc = new MassComponent(otherMass, otherCoM);
		children.Add(otherSticky,mc);
		 	

		//if booster add the rigidbody for forces
		Boost b = part.transform.GetComponent<Boost>();
		if(b != null){
			b.body = thisBody;
		}

		// Hm. If this sticky has a layer and the other doesn't, the other should inherit it.
		// That means things the player sticks to should join the player layer.
		// TODO Rest the layer if things become unstuck.
		if (gameObject.layer != 0 && otherSticky.gameObject.layer == 0) {

			otherSticky.gameObject.layer = gameObject.layer;
		}
	}


}
