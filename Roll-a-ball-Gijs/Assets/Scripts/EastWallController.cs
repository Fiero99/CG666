using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EastWallController : MonoBehaviour {

	void OnCollisionEnter (Collision hit)
	{
		if (hit.gameObject.name == "Cube") {
			Debug.Log("time to destroy!");
			Destroy(hit.gameObject);
		}
	}
}
