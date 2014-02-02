using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JellybeanGenerator : MonoBehaviour {

	public float clearDistance = 100.0f;

	public Material[] colors;

	public GameObject[] candies;
	public GameObject[] parts;
	public GameObject[] enemies;


	public Vector3 offset = Vector3.zero;

	private int level = 1;


	private List<GameObject> spawned;

	void Start () {
		spawned = new List<GameObject>();
		StartCoroutine(WaitSeconds(10));
	}

	IEnumerator WaitSeconds(float delay) {
		yield return new WaitForSeconds(delay);
		IncrementLevel();
	}


	void IncrementLevel(){

		
		GameObject player = GameObject.Find ("ship");

		//yay teleport
		this.transform.position = player.transform.position;

		ClearList();

		int num = 80 + 5 * level;
		num = num > 400 ? 400 : num;
		Generate(num);


		Debug.Log ("Level: " + level + " with " + spawned.Count + " objects");


		level += 1;
		StartCoroutine(WaitSeconds(20));
	}


	void ClearList(){
		List<GameObject> removed = new List<GameObject>();

		GameObject player = GameObject.Find ("ship");
		//todo: conditional here if attached to player?
		foreach(GameObject go in spawned){

			//remove objects that aren't connected and are far enough away
			if(go.transform.parent == null && 
			   	Vector3.Distance(go.transform.position, player.transform.position) > clearDistance){
					removed.Add(go);
				}

		}

		

		foreach(GameObject go in removed){
			spawned.Remove(go);
			Destroy(go);
		}



	}


	void Generate (int amount) {

		float range = Mathf.Sqrt(level);

		//each level gives some parts and some enemies
		int partNum = amount/33;
		partNum = partNum < 1 ? 1 : partNum;

		int enemyNum = (amount - 100) / 25;
		enemyNum = enemyNum < 1 ? 1 : enemyNum;


		//generate parts
		for(int i = 0; i < partNum; i++){
			Vector3 place = transform.position;
			
			//random angle/distance
			place += Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f) * 
				(Vector3.forward * (1.0f + Random.Range (0.0f, range)) * clearDistance);

			GameObject part = Instantiate(parts[Random.Range(0,parts.Length)], Vector3.zero, Quaternion.identity) as GameObject;
			part.transform.position = place; 

			//parts are added to spawn count
			spawned.Add(part);
		}



		//generate enemies
		for(int i = 0; i < enemyNum; i++){
			Vector3 place = transform.position;
			
			//random angle/distance
			place += Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f) * 
				(Vector3.forward * (1.0f + Random.Range (0.0f, range)) * clearDistance);
			
			
			
			GameObject enemy = Instantiate(enemies[Random.Range(0,enemies.Length)], Vector3.zero, Quaternion.identity) as GameObject;
			enemy.transform.position = place; 
		}


		//generate candy
		for(int i = 0; i < amount; i++){

			Vector3 place = transform.position;

			//random angle/distance
			place += Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f) * 
				(Vector3.forward * (1.0f + Random.Range (0.0f, range)) * clearDistance);


			Quaternion rot = new Quaternion();

			GameObject current = Instantiate(candies[Random.Range(0,candies.Length)], place, rot) as GameObject;
			spawned.Add (current);
			current.renderer.material = colors[Random.Range(0,colors.Length)];
		}

	}


}
