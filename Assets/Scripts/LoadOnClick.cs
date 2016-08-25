using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadOnClick : MonoBehaviour {

	public GameObject loadingImage;
	public GameObject gameOver;
	public GameObject paused;
	public GameObject airbar;
	public GameObject lifebar;
	public bool isPaused;

	private Vector2 airincrement;
	private Vector2 airdecrement;
	private bool checkAir;

	void Start()
	{
		isPaused = false;
		airdecrement = new Vector2 (0.1f, 0f);
		airincrement = new Vector2 (2f, 0f);
		checkAir = true;
	}

	/*void Awake() {

		InvokeRepeating ("loseAir", 1, 2f);

	}*/

	void FixedUpdate () {

		loseAir ();

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

	public void loseAir() {
		if (airbar.GetComponent<RectTransform> ().sizeDelta.x < 1) {
			loseLife ();
			//return false;
		} else {
			airbar.GetComponent<RectTransform> ().sizeDelta -= airdecrement;
			//return true;
		}
	}

	public void loseAllAir() {
		airbar.GetComponent<RectTransform> ().sizeDelta -= airbar.GetComponent<RectTransform> ().sizeDelta;
	}

	public void gainAir() {
		if (airbar.GetComponent<RectTransform> ().sizeDelta.x > 140) {
		} else {
			airbar.GetComponent<RectTransform> ().sizeDelta += airincrement;
		}
	}

	public void gainAllAir() {
		airbar.GetComponent<RectTransform> ().sizeDelta = new Vector2 (142f, 5.3f);
	}

	public bool hasAir() {
		Debug.Log ("airbar sizedelta.x = " + airbar.GetComponent<RectTransform> ().sizeDelta.x);
		if (airbar.GetComponent<RectTransform> ().sizeDelta.x > 0) {
			return true;
		} else {
			return false;
		}
	}




	public void loseLife() {
		if (lifebar.GetComponent<RectTransform> ().sizeDelta.x < 1) {
			DisplayGameOver ();
			//return false;
		} else {
			lifebar.GetComponent<RectTransform> ().sizeDelta -= (airdecrement * 3);
			//return true;
		}
	}

	public void gainLife() {
	}
}