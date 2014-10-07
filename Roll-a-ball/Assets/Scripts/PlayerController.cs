using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text scoreText;
	public Text winText;

	private int count;
	private int totalPickupCount;

	void Start(){
		count = 0;
		totalPickupCount = GameObject.FindGameObjectsWithTag ("Pickup").Length;
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Pickup") {
			other.gameObject.SetActive (false);
			count = count + 1;
			scoreText.text = "Score: " + count;
			if(count >= totalPickupCount){
				winText.gameObject.SetActive(true);
			}
		}
	}

	void OnCollisionEnter (Collision hit)
	{
		if(hit.gameObject.tag == "WinPlace")
		{
			winText.gameObject.SetActive(true);
		}
	}
}
