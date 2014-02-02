using UnityEngine;
using System.Collections;

public class Expire : MonoBehaviour {

	
	void Start () {
		StartCoroutine(WaitSeconds(10.0f));
	}
	
	IEnumerator WaitSeconds(float delay) {
		yield return new WaitForSeconds(delay);
		Destroy(gameObject);
	}
	
}
