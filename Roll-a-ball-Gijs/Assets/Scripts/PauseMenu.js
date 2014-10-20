#pragma strict

var isPause = false;
var PauseMenu : Rect = Rect(10,10,200, 200);
var oldTimeScale = 1;
var hide = true;


function Update () {
	//Debug.Log(hide + ", " + isPause + ", " + oldTimeScale);
	if(Input.GetKeyDown(KeyCode.Escape) && (!isPause)){
		oldTimeScale = Time.timeScale;
		isPause = true;
		hide = false;
		Time.timeScale = 0;
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