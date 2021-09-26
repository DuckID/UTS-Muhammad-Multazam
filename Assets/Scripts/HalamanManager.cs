using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HalamanManager : MonoBehaviour {
	public bool isEscapeToExit;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			if (isEscapeToExit) {
				Application.Quit ();
			} else {
				BackToMenu ();
			}
		}
	}
	public void Exit ()
	{
		Application.Quit ();
	}

	public void BackToMenu ()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void SelectLevel ()
	{
		SceneManager.LoadScene ("SelectLevel");
	}

	public void HowTo ()
	{
		SceneManager.LoadScene ("HowTo");
	}

	public void Retry ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}
