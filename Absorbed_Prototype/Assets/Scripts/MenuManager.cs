using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public GameObject mainPanel;
	public GameObject levelSelectPanel;

	// Use this for initialization
	void Start () {
		mainPanel.SetActive (true);
		levelSelectPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetActivePanel(string panel)
	{
		mainPanel.SetActive (false);
		levelSelectPanel.SetActive (false);

		switch (panel) {
		case "Main":
			mainPanel.SetActive (true);
			break;
		case "LevelSelect":
			levelSelectPanel.SetActive (true);
			break;
		}
	}

	public void StartGame()
	{
		Application.LoadLevel("Prototype");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
