using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Delayer : MonoBehaviour {


	private bool notmove;
	public GameObject player;
	public Text OneText;
	public Text TwoText;
	public Text ThreeText;
	public Text FourText;
	public Text FiveText;

	void Start()
	{
		Time.timeScale = 5.0F;
		player.GetComponent<PlayerController>().stopmove(true);
		StartCoroutine(WaitAndFive(Time.timeScale));
	}

	void WaitAndGo() {
		OneText.gameObject.SetActive (false);
		notmove = false;
		player.GetComponent<PlayerController>().stopmove(false);
		Time.timeScale = 1.0F;
		player.GetComponent<PlayerController>().resettime();
		}


	IEnumerator WaitAndOne(float waitTime) {
		TwoText.gameObject.SetActive (false);
		OneText.gameObject.SetActive (true);
		yield return new WaitForSeconds(waitTime);
		Invoke ("WaitAndGo",0);
	}

	IEnumerator WaitAndTwo(float waitTime) {
		ThreeText.gameObject.SetActive (false);
		TwoText.gameObject.SetActive (true);
		yield return new WaitForSeconds(waitTime);
		StartCoroutine(WaitAndOne(waitTime));
	}


	IEnumerator WaitAndThree(float waitTime) {
		FourText.gameObject.SetActive (false);
		ThreeText.gameObject.SetActive (true);
		yield return new WaitForSeconds(waitTime);
		StartCoroutine(WaitAndTwo(waitTime));
	}


	IEnumerator WaitAndFour(float waitTime) {
		FiveText.gameObject.SetActive (false);
		FourText.gameObject.SetActive (true);
		yield return new WaitForSeconds(waitTime);
		StartCoroutine(WaitAndThree(waitTime));
	}

	IEnumerator WaitAndFive(float waitTime) {
		FiveText.gameObject.SetActive (true);
		yield return new WaitForSeconds(waitTime);
		StartCoroutine(WaitAndFour(waitTime));
	}
	


}
