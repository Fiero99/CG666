using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSpawner : MonoBehaviour
{
	public GameObject[] spawnObject;
	public GameObject car;
	public float minSpawnTime = 0.1f;
	public float spawnSpeed = 1.0f;
	public List<GameObject> spawns;
	public Vector3 startloc; // the starting location of the block
	public Vector3 endloc;
	public float speed;
	public float anglecorr;
	public float mindelay;

	
	void Start()
	{
		float delay = Random.Range (0, 1f);
		print ("RandomSpawn1");
		InvokeRepeating("randomizer", delay, 2f);
	}
	
	void randomizer()
	{
		float delay = Random.Range (0, 0.01f);
		Invoke ("SpawnObject", 0);		
	}

	void SpawnObject()
	{
		GameObject cube = GameObject.Instantiate(car) as GameObject;
		Rigidbody rigidcube = cube.rigidbody;
		rigidcube.tag = ("Vehicle");
		rigidcube.isKinematic = true;
		cube.transform.position = startloc;
		spawns.Add (cube);
	}


	// find the vehicle objects and move them one step to the direction
	void Update () {
				//spawns = GameObject.FindGameObjectsWithTag ("Vehicle");
				Vector3 diff = (endloc - startloc);
				Vector3 UnitDiff = diff / diff.magnitude;
				float theta = Mathf.Rad2Deg * Mathf.Atan (diff.z / diff.x);
		
				foreach(var spawn in spawns.ToArray ()){
						Vector3 curr = startloc - spawn.transform.position;
						float dist = curr.magnitude;

						spawn.transform.eulerAngles = new Vector3 (0, -theta + anglecorr , 0);
				        spawn.transform.Translate( UnitDiff*speed, Space.World);


						if (dist >= diff.magnitude) {
							spawns.Remove(spawn);				
							Destroy(spawn);
						}
				}
		}
}
