using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	private int some_random_num;
	private GameObject objectPool;
	private int numFish;
	private Vector3 stageDimensions;

	public GameObject pufferfish;
	public bool gameOver;
	public static bool paused;

	void Start() {
		gameOver = false;
		paused = false;
		numFish = 0;
		stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
	}

	void spawnFlipCoral() {

		if(!paused) {
		//if (gameOver != true) {
			some_random_num = Random.Range (1, 9);
			switch (some_random_num) {

			case 1:
				GetComponent<ObjectPool>().GetObjectForType("coral_bg_0f", true);
				break;

			case 2:
				//GetComponent<ObjectPool>().GetObjectForType("coral_bg_1f", true);
				GetComponent<ObjectPool>().GetObjectForType("coral_bg_0f", true);
				break;

			case 3:
				GetComponent<ObjectPool>().GetObjectForType("coral_bg_2f", true);
				break;

			case 4:
				GetComponent<ObjectPool>().GetObjectForType("coral_bg_3f", true);
				break;

			case 6:
				GetComponent<ObjectPool>().GetObjectForType("coral_fg_0f", true);
				break;

			case 7:
				//GetComponent<ObjectPool>().GetObjectForType("coral_fg_1f", true);
				GetComponent<ObjectPool>().GetObjectForType("coral_fg_0f", true);
				break;

			case 8:
				GetComponent<ObjectPool>().GetObjectForType("coral_fg_2f", true);
				break;

			case 9:
				GetComponent<ObjectPool> ().GetObjectForType ("coral_fg_3f", true);
				break;
			}
		}
	}

	void spawnCoral() {

		if (!paused) {
		//if (gameOver != true) {
			//Debug.Log ("Invoking moreFish()");
			some_random_num = Random.Range (1, 9);
			//Debug.Log (some_random_num.ToString ());
			switch (some_random_num) {

			case 1:
				GetComponent<ObjectPool>().GetObjectForType("coral_bg_0", true);
				break;

			case 2:
				//GetComponent<ObjectPool> ().GetObjectForType ("coral_bg_1", true);
				GetComponent<ObjectPool>().GetObjectForType("coral_bg_0", true);
				break;

			case 3:
				GetComponent<ObjectPool>().GetObjectForType("coral_bg_2", true);
				break;

			case 4:
				GetComponent<ObjectPool>().GetObjectForType("coral_bg_3", true);
				break;

			case 5:
				GetComponent<ObjectPool>().GetObjectForType("coral_fg_0", true);
				break;

			case 6:
				GetComponent<ObjectPool>().GetObjectForType("coral_fg_0", true);
				//GetComponent<ObjectPool>().GetObjectForType("coral_fg_1", true);
				break;

			case 7:
				GetComponent<ObjectPool>().GetObjectForType("coral_fg_2", true);
				break;

			case 8:
				GetComponent<ObjectPool>().GetObjectForType("coral_fg_3", true);
				break;
			}
		}
	}

	// Use this for initialization
	void Awake () {
		InvokeRepeating("moreFish", 1, 1F);
		InvokeRepeating ("spawnCoral", 1, 1f);
		InvokeRepeating ("spawnFlipCoral", 1, 1f);
		InvokeRepeating ("morePufferfish", 1, 8f);
	}

	public void GameOver() {
		gameOver = true;
	}

	public void PauseGame() {
		paused = true;
	}

	public void ResumeGame() {
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void moreFish(){

		if (!paused) {
		//if (gameOver != true) {
			//Debug.Log ("Invoking moreFish()");
			some_random_num = Random.Range (1, 6);
			//Debug.Log (some_random_num.ToString ());
			switch (some_random_num) {

			case 1:
				//Instantiate (bluefish);
				GameObject obj = ObjectPool.instance.GetObjectForType ("BlueFish", true);
				if (obj == null)
					return;
				obj.transform.position = new Vector2 (10f, Random.Range (-stageDimensions.y, stageDimensions.y));
				obj.SetActive (true);
				//Debug.Log ("GetObjectForType");
				break;

			case 2:
				//Instantiate (greenfish);
				//ObjectPool.instance.GetObjectForType("GreenFish", true);
				break;

			case 3:
				//Instantiate (purplefish);
				//ObjectPool.instance.GetObjectForType("PurpleFish", true);
				break;

			case 4:
				//ObjectPool.instance.GetObjectForType ("Goldfish", true);
				break;

			case 5:
				//ObjectPool.instance.GetObjectForType ("Peachfish", true);
				break;

			}
		}
	}

	void morePufferfish(){
		//Instantiate (pufferfish);
	}
}
