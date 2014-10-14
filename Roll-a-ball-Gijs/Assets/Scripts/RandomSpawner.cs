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
	public float direction; // pos = going  right, neg = going left


	void Start()
	{
		print ("RandomSpawn1");
		InvokeRepeating("randomizer", 0, 1.3f);
	}

	void randomizer()
	{
		//float delay = Random.Range (0, 0.01f);
		Invoke ("SpawnObject", 6f);

	}



	void SpawnObject()
	{
		GameObject cube = GameObject.Instantiate(car) as GameObject;
		Rigidbody rigidcube = cube.rigidbody;
		rigidcube.tag = ("Vehicle");
		//rigidcube.isKinematic = true;
		cube.transform.position = startloc;
	}


	// find the vehicle objects and move them one step to the direction
	void Update () {
		spawns = GameObject.FindGameObjectsWithTag("Vehicle");

		for(int i = 0; i < spawns.Length; i++)
		{
			spawns[i].transform.eulerAngles = new Vector3(0, 0, 0);
			spawns[i].transform.Translate(new Vector3 (0.19f, 0, 0)*direction);
		}

	}

}