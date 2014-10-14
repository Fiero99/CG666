using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WestWallController : MonoBehaviour {
	
	void OnCollisionEnter (Collision hit)
	{
		if (hit.gameObject.tag == "Vehicle") {
			//Debug.Log("time to destroy!");
			Destroy(hit.gameObject);
		}
	}
}
