using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool isGrounded = true;
	public float speed;
	public float JumpSpeed = 50.0f;
	public Text winText;
	public Text deathText;
	private float timer;

	void Start(){
		winText.gameObject.SetActive(false);
		deathText.gameObject.SetActive(false);
		timer = 0f;
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

	void Update () {
		timer += Time.deltaTime;
		rigidbody.transform.eulerAngles = new Vector3 (0, 180, 0);
	}

	void OnCollisionEnter (Collision hit)
	{
		if (hit.gameObject.tag == "Ground") {
			isGrounded = true;
		} else if (hit.gameObject.tag == "Vehicle") {
			deathText.gameObject.SetActive (true);
			StartCoroutine(WaitAndReturn(3));
		} else if (hit.gameObject.tag == "WinPlace") {
			winText.gameObject.SetActive (true);
			StoreHighscore(timer);
			StartCoroutine(WaitAndReturn(3));
		} else if (hit.gameObject.tag == "Water") {
			deathText.gameObject.SetActive (true);
			StartCoroutine(WaitAndReturn(3));
		}
	}

	IEnumerator WaitAndReturn(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel ("MainMenu");
	}

	void StoreHighscore(float newHighscore)
	{
		float oldHighscore = PlayerPrefs.GetFloat("highscore", 9999999999);  
		if(newHighscore < oldHighscore)
			PlayerPrefs.SetFloat("highscore", newHighscore);
	}
	
}