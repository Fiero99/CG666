using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour
{
	public GameObject[] spawnObject;
	public GameObject car;
	public float minSpawnTime = 0.1f;
	public float spawnSpeed = 1.0f;
	public GameObject[] spawns;
	public Vector3 startloc = new Vector3 (-9, 0.5f, 0);// the starting location of the block
	public float direction  =  1; // pos = going  right, neg = going left


	void Start()
	{
		InvokeRepeating("SpawnObject", minSpawnTime, minSpawnTime);
	}
	
	void SpawnObject()
	{
		//GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		GameObject cube = GameObject.Instantiate(car) as GameObject;
		//cube.AddComponent<Rigidbody>();
		Rigidbody rigidcube = cube.rigidbody;
		rigidcube.tag = ("Vehicle");
		cube.transform.position = startloc;
		//rigidcube.renderer.material.color = Color.red;
	}


	// find the vehicle objects and move them one step to the direction
	void Update () {
		spawns = GameObject.FindGameObjectsWithTag("Vehicle");
		Vector3 pos = new Vector3 (0, 0.1f, 0);

		for(int i = 0; i < spawns.Length; i++)
		{
			spawns[i].transform.eulerAngles = new Vector3(0, 0, 0);
			spawns[i].transform.Translate(new Vector3 (0.14f, 0, 0)*direction);
		}

	}

}