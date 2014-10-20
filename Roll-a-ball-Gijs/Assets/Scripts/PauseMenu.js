#pragma strict

var isPause = false;
var PauseMenu : Rect = Rect(10,10,200, 200);
var oldTimeScale = 1;
var hide = false;

function Update () {
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
	if(!isPause){
		hide = false;
	}
}

function OnGUI(){
	if(isPause){
		if(!hide){
			GUI.Window(0, PauseMenu, ThePauseMenu, "Pause Menu");
		}
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
		hide = true;
		isPause = false;
	}
	
}