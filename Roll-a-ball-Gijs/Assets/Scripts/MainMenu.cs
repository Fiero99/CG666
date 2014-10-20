using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public void OnClickStartButton(){
		Invoke ("CountDown", 0);
		Application.LoadLevel ("MiniGame");
	}
	public void OnClickQuitButton(){
		Application.Quit();
	}
	public void OnClickBackButton(){
		Application.LoadLevel ("MainMenu");
	}
	public void OnClickScoreButton(){
		Application.LoadLevel ("ScoreMenu");
	}
	public void OnClickResetButton(){
		PlayerPrefs.SetFloat("highscore", 9999999);
		Application.LoadLevel ("ScoreMenu");
	}



void CountDown()
{
	print("Woohoo");
	
	
}

}