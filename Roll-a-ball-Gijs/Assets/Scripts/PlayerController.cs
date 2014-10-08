using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool isGrounded = true;
	public float speed;
	public float JumpSpeed = 100.0f;
	public Text winText;

	void Start(){
		winText.gameObject.SetActive(false);
		}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce(movement * speed * Time.deltaTime);
		
		if(Input.GetKeyDown (KeyCode.Space) && isGrounded) {
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
		if(hit.gameObject.tag == "WinPlace")
		{
			winText.gameObject.SetActive(true);

		}
	}

}