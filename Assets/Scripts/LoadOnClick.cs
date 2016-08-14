using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;
	public GameObject gameOver;
	public GameObject paused;
	public bool isPaused;

	void Start()
	{
		isPaused = false;
	}

	public void LoadScene(int scene)
	{
		loadingImage.SetActive (true);
		SceneManager.LoadScene (scene);
	}

	public void DisplayGameOver()
	{
		gameOver.SetActive (true);
	}

	public void ClearGameOver()
	{
		gameOver.SetActive (false);
	}

	public void PauseGame()
	{
		isPaused = true;
		paused.SetActive (true);
	}

	public void ResumeGame()
	{
		isPaused = false;
		paused.SetActive (false);
	}
}