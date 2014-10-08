using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour
{
	public float minSpawnTime = 1.0f;
	public float maxSpawnTime = 2.0f;
	public float spawnSpeed = 4.0f;
	
	void Start()
	{
		InvokeRepeating("SpawnObject", Random.Range(minSpawnTime,maxSpawnTime), spawnSpeed);
	}
	
	void SpawnObject()
	{
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.AddComponent<Rigidbody>();
		Rigidbody rigidcube = cube.rigidbody;
		Vector3 pos = new Vector3 (0, 1, 0);
		cube.transform.position = pos;
		rigidcube.renderer.material.color = Color.red;
		rigidcube.velocity = new Vector3(30, 0, 0);
	}

}