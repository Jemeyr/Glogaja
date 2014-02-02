using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class Sticky : MonoBehaviour {

	public float explodeForce = 15.0f;


	public Dictionary<Sticky,MassComponent> children = new Dictionary<Sticky, MassComponent>();

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


		//remove the trigger, Tom: I don't know why, but doing this makes all the balls hit and none stick.
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


		//get new parent part
		Sticky toBeParent = GetNearest(part.transform.position, t.GetComponent<Sticky>());

		
		//add it into heirarchy so it is connected
		part.transform.parent = toBeParent.transform;


		//add to tree
		MassComponent mc = new MassComponent(otherMass, otherCoM);
		toBeParent.children.Add(otherSticky,mc);
		 	

		//if booster add the rigidbody for forces
		Boost b = part.transform.GetComponent<Boost>();
		if(b != null){
			b.body = thisBody;
		}

		// Hm. If this sticky has a layer and the other doesn't, the other should inherit it.
		// That means things the player sticks to should join the player layer.
		// TODO Reset the layer if things become unstuck.
		if (gameObject.layer != 0 && otherSticky.gameObject.layer == 0) {

			otherSticky.gameObject.layer = gameObject.layer;
		}
	}

	public void Unstick() {
		//HACK HACK HACK HACK HACK HACK HACK HACK HACK HACK HACK HACK 


		//go through all the children, undo the sticking, collect the masscomponents
		List<MassComponent> detachedMasses = new List<MassComponent>();



		//list of stickies to destroy after iterating everything
		List<Sticky> toDestroy = new List<Sticky>();

		Queue<Sticky> toDetach = new Queue<Sticky>();
		toDetach.Enqueue(this);

		while(toDetach.Count > 0){
			Sticky sticky = toDetach.Dequeue();

			GameObject part = sticky.gameObject;


			//A lot of this doesn't apply to the toplevel ship entity
			if(sticky.transform.name != "ship"){//sticky.transform.parent != null){

				//reset layer?
				part.layer = 0;
				
				//reset trigger
				part.AddComponent<BecomeTriggerAgain>();



				Sticky parent = sticky.transform.parent.GetComponent<Sticky>();
				MassComponent mc = parent.children[sticky];

				detachedMasses.Add (mc);
				parent.children.Remove(sticky);

				//add a rigidbody and give it the mass
				Rigidbody partbody = part.AddComponent<Rigidbody>();

				//Sometimes the physics fails the first try because this gets interrupted or something
				partbody.mass = mc.mass;
				partbody.centerOfMass = Vector3.zero;

				partbody.useGravity = false;




			
				//no force for now. I think there is an issue where the force is applied before the mass is set
				partbody.AddForce( (partbody.position - this.transform.position) * explodeForce); 


				
				//remove it from the heirarchy
				part.transform.parent = null;
				
				//add children
				foreach (Sticky s in sticky.children.Keys){
					toDetach.Enqueue(s);
				}

				//destroy
				toDestroy.Add(sticky);

			}else {

				//just add children
				foreach (Sticky s in sticky.children.Keys){
					toDetach.Enqueue(s);
				}
			}


		}

		//kill the stickies
		foreach(Sticky s in toDestroy){
			Destroy (s);
		}



		//get toplevel rigidbody
		Transform t = transform;
		while(t.parent != null){
			t = t.parent;
		}

		Rigidbody body = t.GetComponent<Rigidbody>();



		foreach(MassComponent mc in detachedMasses){
			float lostMass = mc.mass;
			Vector3 lostCoM = mc.centerOfMass;

			float oldMass = body.mass;

			//fix mass
			body.mass = oldMass - lostMass;



			Vector3 oldCoM = body.centerOfMass;

			//vector pointing from mass lost to center of mass now
			Vector3 coMDiff = oldCoM - lostCoM;

			//fix center of mass
			body.centerOfMass = oldCoM + coMDiff * (lostMass/oldMass); 

		}

	}

	//get nearest sticky to the position giving, pass in the toplevel sticky you are checking from
	private Sticky GetNearest(Vector3 inPos, Sticky sticky){
		Sticky closest = null;
		float minDist = float.MaxValue;

		Queue<Sticky> toCheck = new Queue<Sticky>();
		toCheck.Enqueue(sticky);
		
		//gross flat queue recursion.
		while(toCheck.Count > 0){
			
			Sticky testing  = toCheck.Dequeue();
			Vector3 testPos = testing.gameObject.transform.position;
			
			float testDist = Vector3.Distance(testPos,inPos);
			
			if(testDist < minDist){
				minDist = testDist;
				closest = testing;
			}
			
			foreach(Sticky s in testing.children.Keys){
				toCheck.Enqueue(s);
			}
		

		}
		return closest;
	}



}
