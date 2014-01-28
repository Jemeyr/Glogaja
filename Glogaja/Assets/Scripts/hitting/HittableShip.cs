using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HittableShip : Hittable {

	
	public override void hit(GameObject hitter){
		Vector3 hitterPos = hitter.transform.position;

		//get toplevel sticky
		Sticky sticky = transform.GetComponent<Sticky>();
		if(sticky == null){
			return;
		}

		
		float minDist = float.MaxValue;
		Sticky closest = null;

		Queue<Sticky> toCheck = new Queue<Sticky>();
		toCheck.Enqueue(sticky);

		//gross flat queue recursion.
		while(toCheck.Count > 0){

			Sticky testing  = toCheck.Dequeue();
			Vector3 testPos = testing.gameObject.transform.position;

			float testDist = Vector3.Distance(testPos,hitterPos);

			if(testDist < minDist){
				minDist = testDist;
				closest = testing;
			}
			
			foreach(Sticky s in testing.children.Keys){
				toCheck.Enqueue(s);
			}

		}

		//unstick that dude
		closest.Unstick();





	}


}
