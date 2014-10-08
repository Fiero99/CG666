using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public void OnClickStartButton(){
		Application.LoadLevel ("MiniGame");
	}
	public void OnClickQuitButton(){
		Application.Quit();
	}
}
