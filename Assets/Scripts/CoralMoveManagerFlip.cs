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
		speed = 0.04f;
	}

	// Update is called once per frame
	void Update () {
		if (GameManager.paused == true) {
			PauseGame ();
		} else {
			ResumeGame ();
		}

		position.Set (position.x - Time.timeScale*(speed), position.y);
		rb2d.MovePosition (position);
	}

	public void resetPosition() {
		position.Set (stageDimensions.x * 1.3f, Random.Range (stageDimensions.y - 1.2f, stageDimensions.y - .8f));
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("BarrierEnd")) {
			objectPool.PoolObject (this.gameObject);
			resetPosition ();
		}
	} 

	public void PauseGame() {
		Time.timeScale = 0f;
	}

	public void ResumeGame() {
		Time.timeScale = 1f;
	}
}
