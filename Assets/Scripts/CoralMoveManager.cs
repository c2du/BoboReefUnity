using UnityEngine;
using System.Collections;

public class CoralMoveManager : MonoBehaviour {

	public float speed;
	public bool isFlipped;

	private Rigidbody2D rb2d;
	private Vector2 position;
	private Vector3 stageDimensions;
	//private ObjectPool objectPool;
	//private Transform transform;
	private Vector3 scale;
	private float scaleXY;
	private float minscale;
	private SpriteRenderer spriterend;


	private float startYPos;






	// Use this for initialization
	void Start () {
		// Get components
		rb2d = GetComponent<Rigidbody2D> ();
		stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
		//transform = this.gameObject.transform;
		spriterend = this.gameObject.GetComponent<SpriteRenderer> ();
		//objectPool = GameObject.Find ("GameManager").GetComponent<ObjectPool> ();


		if (!isFlipped) {
			// Randomly set position
			startYPos = Random.Range (-stageDimensions.y + .8f, -stageDimensions.y + 1.2f);

			position = new Vector2 (stageDimensions.x * 1.3f, startYPos );
		
		} else {
			// Randomize position top Coral
			startYPos = Random.Range (stageDimensions.y - 1.2f, stageDimensions.y - .8f);

			position = new Vector2 (stageDimensions.x * 1.3f, startYPos );
		
		}


		// Randomize size
		minscale = transform.localScale.x * .3f;
		scaleXY = Random.Range (-1*minscale, minscale);
		transform.localScale += new Vector3 (scaleXY, scaleXY, 0);


		// Randomly flip object
		if (Random.Range (1, 3) > 1) {
			spriterend.flipX = true;
		}

		// Randomly rotate
		transform.Rotate (Vector3.forward * (Random.Range (-20, 20)));

		// Set speed
		speed = 0.16f;



	}





	// Update is called once per frame
	void Update () {
		// check if game is paused
		if (GameManager.paused == true) {
			PauseGame ();
		} else {
			ResumeGame ();
		}


		Debug.Log ("position.x: " + position.x);


		if ( position.x > -14 ) {
			
			position.Set (position.x - (Time.timeScale * speed), position.y);
			rb2d.MovePosition (position);

		} else {

			//position.x = 10;
			//position.y = -stageDimensions.y + .8f;


			if (isFlipped) {

				//Top Coral
				position.Set (Random.Range (15, 30), Random.Range (startYPos - .5f, startYPos + .5f));
					//Random.Range (stageDimensions.y - .5f, stageDimensions.y + .5f));
				rb2d.MovePosition (position);


			} else {


				position.Set (Random.Range (15, 30), Random.Range (startYPos - .5f, startYPos + .5f));
				rb2d.MovePosition (position);

			}
			/*
			position.Set ( Screen.width * 1.3f, Random.Range (-stageDimensions.y + .8f, -stageDimensions.y + 1.2f));
/*

			rb2d.MovePosition (position);

			ResetFlag = false;
			*/

		}


		/*
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);



		Debug.Log ("Main X: "+ pos.x + "~ Coral X: "+ position.x);

		if(pos.x < 0.0) Debug.Log("I am left of the camera's view.");
		if(1.0 < pos.x) Debug.Log("I am right of the camera's view.");
		if(pos.y < 0.0) Debug.Log("I am below the camera's view.");
		if(1.0 < pos.y) Debug.Log("I am above the camera's view.");

		*/
	}





	public void resetPosition() {

	

		//gameObject.transform.position.Set ( stageDimensions.x * 1.3f, Random.Range (-stageDimensions.y + .8f, -stageDimensions.y + 1.2f), 0);

		//rb2d.MovePosition (gameObject.transform.position);
	
	}



	void OnTriggerEnter2D(Collider2D other) {



		if ( other.gameObject.CompareTag ("BarrierEnd")) {

			Debug.Log ("Barrier End Hit By Bottom Corral");

			this.resetPosition ();

			//this.gameObject.SetActive (false);
			//objectPool.PoolObject (this.gameObject);
			//
		}
	} 



	public void PauseGame() {
		Time.timeScale = 0f;
	}



	public void ResumeGame() {
		Time.timeScale = 1f;
	}
}
