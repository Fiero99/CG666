using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSpawner : MonoBehaviour
{
	public GameObject[] spawnObject;
	public GameObject car;
	public List<GameObject> spawns;
	public Vector3 startloc; // the starting location of the block
	public Vector3 endloc;
	public float speed;
	public float anglecorr;
	public float mindelay;

	
	void Start()
	{
		float delay = Random.Range (2* speed, 25*speed);
		Invoke("randomizer", delay);
	}
	
	void randomizer()
	{
		float delay = Random.Range ( 0.1f/speed, 1f + 0.3f/speed);
		print (delay);
		Invoke ("SpawnObject", delay);		
	}

	void SpawnObject()
	{
		GameObject cube = GameObject.Instantiate(car) as GameObject;
		Rigidbody rigidcube = cube.rigidbody;
		rigidcube.tag = ("Vehicle");
		rigidcube.isKinematic = true;
		cube.transform.position = startloc;
		spawns.Add (cube);
		float delay = Random.Range ( 0.1f/speed, 1f + 0.2f/speed);
		Invoke ("randomizer", delay);	
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
