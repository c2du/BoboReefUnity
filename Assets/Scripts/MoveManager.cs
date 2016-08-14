using UnityEngine;
using System.Collections;

public class MoveManager : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb2d;
	private Vector2 position;
	private ObjectPool objectPool;
	private Vector3 stageDimensions;
	private float pausespeed;
	//private bool resetFlag;

	// Use this for initialization
	void Start () {
		stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));

		rb2d = GetComponent<Rigidbody2D> ();
		position = new Vector2 (10f, Random.Range (-stageDimensions.y, stageDimensions.y));
		speed = Random.Range(0.03f, 0.09f);
		objectPool = GameObject.Find ("GameManager").GetComponent<ObjectPool> ();
		//resetFlag = false;

	}



	// Update is called once per frame
	void Update () {
		if (GameManager.paused == true) {
			PauseGame ();
		} else {
			ResumeGame ();
		}

		/*if (resetFlag == true) {
			resetPosition ();
			objectPool.PoolObject (this.gameObject);
		}*/

		position.Set (position.x - Time.timeScale*(speed), position.y);
		rb2d.MovePosition (position);

	}

	public void resetPosition() {
		Debug.Log ("resetPosition()");
		position.Set (10f, Random.Range (-3f, 3f));
		speed = Random.Range(0.03f, 0.09f);
		//resetFlag = false;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("BarrierEnd") || other.gameObject.CompareTag ("Player")) {
			Debug.Log ("Collision with barrierend or player");

			//resetFlag = true;

			resetPosition ();
			objectPool.PoolObject (this.gameObject);
			//gameObject.SetActive (false);

			//objectPool.PoolObject (this.gameObject);
		}
	} 

	public void PauseGame() {
		Time.timeScale = 0f;
	}

	public void ResumeGame() {
		Time.timeScale = 1f;
	}
}
