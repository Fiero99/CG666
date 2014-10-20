#pragma strict

var isPause = false;
var PauseMenu : Rect = Rect(10,10,200, 200);
var oldTimeScale = 5;
var hide = true;
//var oldHide = false;

function Update () {
	Debug.Log(hide + ", " + isPause + ", " + oldTimeScale);
	
	if(Input.GetKeyDown(KeyCode.Escape) && oldTimeScale == 5){
		isPause = true;
		hide = false;
		oldTimeScale = Time.timeScale;
		Time.timeScale = 0;
	}
	
	
	
	
	/*
	if(Input.GetKeyDown(KeyCode.Escape)){
		isPause = !isPause;
		if(isPause && hide == false){
			oldTimeScale = Time.timeScale;
			Time.timeScale = 0;
		}
		else{
			Time.timeScale = oldTimeScale;
		}
	}
	if(!isPause){
		oldHide = hide;
		hide = false;
	}
	if(oldHide == false && hide == true){
		Time.timeScale = 5;
	}
	*/
	
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
		//oldHide = hide;
		hide = true;
		isPause = false;
		Time.timeScale = oldTimeScale;
	}
	
}