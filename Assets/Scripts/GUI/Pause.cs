using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public bool isPause = false;
	public int width = 300;
	public int height = 100;

	public Vector3 tempCameraPos;
	public Vector3 tempPos;

	//scripts we'll need to pause to truly pause the game
	public GameObject player;
	public GameObject camera;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find("Main Camera");
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(!isPause)
			{
				PauseGame();
			}
		}
	}

	void OnGUI()
	{
		if(isPause)
		{
			if(GUI.Button(new Rect((Screen.width/2) - (width/2),(Screen.height/2) - (height/2) - 200, width, height),"Continue"))
			{
				UnPause();
			}
			if(GUI.Button(new Rect((Screen.width/2) - (width/2),(Screen.height/2) - (height/2), width, height),"Start Menu"))
			{
				UnPause();
			}
			if(GUI.Button(new Rect((Screen.width/2) - (width/2),(Screen.height/2) - (height/2) + 200, width, height),"Quit"))
			{
				Application.Quit();
				//UnityEditor.EditorApplication.isPlaying = false;
			}
		}
	}

	void PauseGame()
	{
		isPause = true;
		Time.timeScale = 0;
		tempCameraPos = camera.transform.position;
		tempPos = player.transform.position;
		tempPos.z += 5;
		camera.transform.position = tempPos;
		camera.transform.LookAt(player.transform);
	}

	void UnPause()
	{
		isPause = false;
		Time.timeScale = 1;
		camera.transform.position = tempCameraPos;
	}
}
