using UnityEngine;
using System.Collections;

public class JellybeanGenerator : MonoBehaviour {

	public Material[] colors;
	public GameObject jellybean;
	public Vector3 offset = Vector3.zero;

	//TODO: make this not generate a line
	void Start () {


		for(int i = -50; i < 50; i++){
			Vector3 place = new Vector3(i*3, 0, 0) + offset;
			Quaternion rot = new Quaternion();

			GameObject current = Instantiate(jellybean, place, rot) as GameObject;
			current.renderer.material = colors[(i+100)%colors.Length];
		}



	}

}
