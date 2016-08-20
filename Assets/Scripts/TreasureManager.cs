using UnityEngine;
using System.Collections;

public class TreasureManager : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Vector2 startPos;
	private Vector2 position;
	private Vector3 stageDimensions;
	private float speed;
	private Animator animator;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
		startPos = new Vector2 (stageDimensions.x * 1.3f, -4.4f);
		position = startPos;
		speed = CoralMoveManager.speed;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (GameManager.paused == true) {
			CoralMoveManager.PauseGame ();
		} else {
			CoralMoveManager.ResumeGame ();
		}*/

		position.Set (position.x - (Time.timeScale * speed), position.y);
		rb2d.MovePosition (position);

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("COLLIDED WITH PLAYER");
			animator.SetBool ("open", true);
		}

		if (other.gameObject.CompareTag ("BarrierEnd")) {
			Destroy (this.gameObject);
		}
	}
}
