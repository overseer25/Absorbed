using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public Button playButton;
	public Button exitButton;

	// Use this for initialization
	void Start () 
	{
		//quitMenu = quitMenu.GetComponent<Canvas>();
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	// Update is called once per frame
	void Update ()
	{

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
