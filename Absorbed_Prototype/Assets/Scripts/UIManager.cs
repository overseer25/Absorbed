using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject PausePanel;
	public GameObject reticule;
	bool paused;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		paused = false;
	}

	void Awake(){

		Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Pause"))
			SetPauseMenu (true);
	}

	public void SetPauseMenu(bool paused)
	{
		if(paused)
		{
			reticule.SetActive (false);
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0.0f;
		}
		else
		{
			reticule.SetActive (true);
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			Time.timeScale = 1.0f;
		}
		PausePanel.SetActive(paused);
	}
}
