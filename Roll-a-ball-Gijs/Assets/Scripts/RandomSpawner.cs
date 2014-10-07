using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour
{
	public GameObject[] spawnObject;    //somehow change this to incorporate multiple gameobject prefabs, will an array support that?
	
	//Would I create public variables for each prefab I want to be randomly chosen from, or would those be contained in the array above?
	
	public float xRange = 1.0f;
	public float yRange = 1.0f;
	public float minSpawnTime = 1.0f;
	public float maxSpawnTime = 10.0f;
	public float spawnSpeed = 4.0f;
	
	void Start()
	{
		InvokeRepeating("SpawnObject", Random.Range(minSpawnTime,maxSpawnTime), spawnSpeed);
	}
	
	void SpawnObject()
	{
		float xOffset = Random.Range(-xRange, xRange);
		float yOffset = Random.Range(-yRange, yRange);
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.AddComponent<Rigidbody>();
		Rigidbody rigidcube = cube.rigidbody;
		Vector3 pos = new Vector3 (0, 1, 0);
		cube.transform.position = pos;
		//Rigidbody newObstacle = GameObject.Instantiate(rigidcube,pos, Quaternion.identity) as Rigidbody;
		cube.renderer.material.color = Color.red;
		cube.velocity = new Vector3(20, 0, 0);
	}
}