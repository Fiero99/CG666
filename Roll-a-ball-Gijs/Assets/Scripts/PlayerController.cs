using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool isGrounded = true;
	public float speed;
	public float JumpSpeed = 100.0f;
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		//float moveUp = Input.GetAxis ("Jump");
		//float moveUp = Input.GetKey (KeyCode.Space);
		
		//Vector3 jumper = new Vector3 (1, 1, 1);
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce(movement * speed * Time.deltaTime);
		
		if(Input.GetKeyUp (KeyCode.Space) && isGrounded) {
			rigidbody.AddForce(Vector3.up * JumpSpeed);
			isGrounded = false;
		}
	}

	void OnCollisionEnter (Collision hit)
	{
		if(hit.gameObject.tag == "Ground")
		{
			isGrounded = true;
		}
	}
}