#pragma strict

var isPause = false;
var PauseMenu : Rect = Rect(10,10,200, 200);
var oldTimeScale;
var hide = true;

function Update () {
	Debug.Log(hide + ", " + isPause + ", " + oldTimeScale);
	if(Input.GetKeyDown(KeyCode.Escape) && !isPause){
		isPause = true;
		hide = false;
		oldTimeScale = Time.timeScale;
		Time.timeScale = 0;
	}
	else if(Input.GetKeyDown(KeyCode.Escape) && isPause){
		isPause = false;
		hide = true;
		Time.timeScale = oldTimeScale;
	}
}

function OnGUI(){
	if(isPause && hide === false){
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
		hide = true;
		isPause = false;
		Time.timeScale = oldTimeScale;
	}
	
}