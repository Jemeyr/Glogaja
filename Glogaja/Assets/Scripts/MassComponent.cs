using UnityEngine;
using System.Collections;

public class MassComponent{
	public Vector3 centerOfMass = Vector3.zero;
	public float mass = 0.0f;

	public MassComponent(float m, Vector3 com){
		centerOfMass = com;
		mass = m;
	}
	

}
