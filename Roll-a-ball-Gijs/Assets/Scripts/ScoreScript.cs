using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText.text += " "+PlayerPrefs.GetFloat("highscore", 9999999999)+" seconds.";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
