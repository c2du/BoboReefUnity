using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadOnClickMain : MonoBehaviour {

	public GameObject loadingImage;
	public GameObject mainMenuObject;
	public GameObject settingsObject;

	private Vector2 movePosition;
	private float timeToRun;
	private float timer;
	private bool moveMainMenuAwayBoolean;

	void Start()
	{
		timeToRun = 20f;
		movePosition = new Vector2 (0.5f, 0f);
		moveMainMenuAwayBoolean = false;
	}

	public void LoadScene(int scene)
	{
		loadingImage.SetActive (true);
		SceneManager.LoadScene (scene);
	}

	void Update() 
	{
		if (moveMainMenuAwayBoolean) {
			mainMenuObject.GetComponent<Transform> ().Translate (Time.deltaTime*20, 0, 0);
		}
	}

	private IEnumerator move_MainMenuObject_Away() 
	{
		yield return new WaitForSeconds (1f);
		moveMainMenuAwayStop ();
	}

	private void moveMainMenuAwayStop()
	{
		moveMainMenuAwayBoolean = false;
		settingsObject.SetActive (true);
	}

	public void moveMainMenuAway()
	{
		moveMainMenuAwayBoolean = true;
		StartCoroutine (move_MainMenuObject_Away ());
	}
}
