#pragma strict

var isPause = false;
var PauseMenu : Rect = Rect(10,10,200, 200);
var oldTimeScale = 1;

function Update () {
	Debug.Log(oldTimeScale);
	if(Input.GetKeyDown(KeyCode.Escape)){
		isPause = !isPause;
		if(isPause){
			oldTimeScale = Time.timeScale;
			Time.timeScale = 0;
		}
		else{
			Time.timeScale = oldTimeScale;
		}
		
	}
}

function OnGUI(){
	if(isPause){
		GUI.Window(0, PauseMenu, ThePauseMenu, "Pause Menu");
	}
}

function ThePauseMenu(){
	if(GUILayout.Button("Main Menu")){
		Application.LoadLevel("MainMenu");
	}
	if(GUILayout.Button("Restart")){
		Application.LoadLevel("MiniGame");
	}
	if(GUILayout.Button("Quit")){
		Application.Quit();
	}
	if(GUILayout.Button("Cancel")){
		//when pressing the escape button again it
		// closes the windows, but it should work with a button too.
	}
	
}