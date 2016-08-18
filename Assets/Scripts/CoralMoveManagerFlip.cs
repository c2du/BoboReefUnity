using UnityEngine;
using System.Collections;

public class CoralMoveManagerFlip : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb2d;
	private Vector2 position;
	private Vector3 stageDimensions;
	private ObjectPool objectPool;
	//private Transform transform;
	private Vector3 scale;
	private float scaleXY;
	private float minscale;
	private SpriteRenderer spriterend;

	private bool ResetFlag;

	// Use this for initialization
	void Start () {


		// Get components
		rb2d = GetComponent<Rigidbody2D> ();
		stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
		objectPool = GameObject.Find ("GameManager").GetComponent<ObjectPool> ();
		//transform = this.gameObject.transform;
		spriterend = this.gameObject.GetComponent<SpriteRenderer> ();

		// Randomize position
		position = new Vector2 (stageDimensions.x * 1.3f, Random.Range (stageDimensions.y - 1.2f, stageDimensions.y - .8f));

		// Randomize size
		minscale = transform.localScale.x * .15f;
		scaleXY = Random.Range (-1*minscale, minscale);
		transform.localScale += new Vector3 (scaleXY, scaleXY, 0);

		// Randomly flip object
		if (Random.Range (1, 3) > 1) {
			spriterend.flipX = true;
		}

		// Randomly rotate
		transform.Rotate (Vector3.forward * (Random.Range (-20, 20)));

		// Set speed
		speed = 0.1f;

		ResetFlag = false;

	}

	// Update is called once per frame
	void Update () {
		if (GameManager.paused == true) {
			PauseGame ();
		} else {
			ResumeGame ();
		}

		if (!ResetFlag) {
			position.Set (position.x - Time.timeScale * (speed), position.y);
			rb2d.MovePosition (position);

		} else {
			/*
			Debug.Log ("Stage.x: " + stageDimensions.x+"  ~ vs ~ Screen.Width: "+ Screen.width);

			position.Set ( (Screen.width ) * 1.3f, Random.Range (-stageDimensions.y + .8f, -stageDimensions.y + 1.2f));
			rb2d.MovePosition (position);

			Debug.Log ("Position.x: " + position.x+"  ~ vs ~ Screen.Width: "+ Screen.width);


			ResetFlag = false;

			*/
		}



	}





	public void resetPosition() {


		ResetFlag = true;
		//gameObject.transform.position =  new Vector2( stageDimensions.x * 1.3f, Random.Range (stageDimensions.y - 1.2f, stageDimensions.y - .8f));
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("BarrierEnd")) {
			
			Debug.Log ("Barrier End Hit By Flip Corral");
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
