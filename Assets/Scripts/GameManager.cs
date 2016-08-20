using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	private int some_random_num;
	private GameObject objectPool;
	//private int numFish;
	private Vector3 stageDimensions;

	public GameObject pufferfish;
	public GameObject treasure;
	public bool gameOver;
	public static bool paused;

	void Start() {
		gameOver = false;
		paused = false;
		//numFish = 0;
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
		InvokeRepeating ("moreFish", 1, 1f);
		InvokeRepeating ("spawnCoral", .2f, 1f);
		InvokeRepeating ("spawnFlipCoral", 1f, 1f);
		InvokeRepeating ("morePufferfish", 1, 8f);
		InvokeRepeating ("moreTreasure", 1, 10f);
		InvokeRepeating ("moreBubbles", 1, 1f);
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
			GameObject obj;
		//if (gameOver != true) {
			//Debug.Log ("Invoking moreFish()");
			some_random_num = Random.Range (1, 6);
			//Debug.Log (some_random_num.ToString ());
			switch (some_random_num) {

			case 1:
				//Instantiate (bluefish);
				obj = ObjectPool.instance.GetObjectForType ("BlueFish", true);
				setFishPosition (obj);
				break;

			case 2:
				//Instantiate (greenfish);
				obj = ObjectPool.instance.GetObjectForType("GreenFish", true);
				setFishPosition (obj);
				break;

			case 3:
				//Instantiate (purplefish);
				obj = ObjectPool.instance.GetObjectForType("PurpleFish", true);
				setFishPosition (obj);
				break;

			case 4:
				obj = ObjectPool.instance.GetObjectForType ("Peachfish", true);
				setFishPosition (obj);
				break;

			case 5:
				obj = ObjectPool.instance.GetObjectForType ("Goldfish", true);
				setFishPosition (obj);
				break;

			}
		}
	}

	void moreBubbles() {

		if (!paused) {
			GameObject obj;
			//if (gameOver != true) {
			//Debug.Log ("Invoking moreFish()");
			some_random_num = Random.Range (1, 4);
			//Debug.Log (some_random_num.ToString ());
			switch (some_random_num) {

			case 1:
				obj = ObjectPool.instance.GetObjectForType ("RealBubble1", true);
				setFishPosition (obj);
				break;

			case 2: 
				obj = ObjectPool.instance.GetObjectForType ("RealBubble2", true);
				setFishPosition (obj);
				break;

			case 3: 
				obj = ObjectPool.instance.GetObjectForType ("RealBubble3", true);
				setFishPosition (obj);
				break;
			}
				
		}
	}

	void setFishPosition(GameObject obj){

		if (obj == null)
			return;
		obj.transform.position = new Vector2 (10f, Random.Range (-stageDimensions.y, stageDimensions.y));
		obj.SetActive (true);

	}

	void morePufferfish(){
		Instantiate (pufferfish);
	}

	void moreTreasure() {
		Instantiate (treasure);
	}
}
