using UnityEngine;
using System.Collections;

public class BecomeTriggerAgain : MonoBehaviour {

	public float Delay = 1.0f;


	void Start () {
		StartCoroutine(WaitSeconds());
	}

	IEnumerator WaitSeconds() {
		yield return new WaitForSeconds(Delay);
		this.transform.collider.isTrigger = true;
		Destroy(this);
	}


}
