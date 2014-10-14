using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour
{
	public GameObject[] spawnObject;
	public GameObject car;
	public float minSpawnTime = 0.1f;
	public float spawnSpeed = 1.0f;
	public GameObject[] spawns;
	public Vector3 startloc; // the starting location of the block
	public Vector3 endloc;
	public int speed;

	
	void Start()
	{
		print ("RandomSpawn1");
		InvokeRepeating("randomizer", 0, 2f);
	}

	void randomizer()
	{
		//float delay = Random.Range (0, 0.01f);
		Invoke ("SpawnObject", 0);

	}



	void SpawnObject()
	{
		GameObject cube = GameObject.Instantiate(car) as GameObject;
		Rigidbody rigidcube = cube.rigidbody;
		rigidcube.tag = ("Vehicle");
		rigidcube.isKinematic = true;
		cube.transform.position = startloc;
	}


	// find the vehicle objects and move them one step to the direction
	void Update () {
		        Vector3 diff = (endloc - startloc)/100;
				spawns = GameObject.FindGameObjectsWithTag ("Vehicle");

				for (int i = 0; i < spawns.Length; i++) {
						spawns [i].transform.eulerAngles = new Vector3 (0, 0, 0);
						spawns [i].transform.Translate (diff* speed);
						if (spawns [i].transform.position.x > 12) {
								Destroy (spawns [i]);
						}

				}
		}

}