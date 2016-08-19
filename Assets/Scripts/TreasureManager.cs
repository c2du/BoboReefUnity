using UnityEngine;
using System.Collections;

public class TreasureManager : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Vector2 startPos;
	private Vector2 position;
	private Vector3 stageDimensions;
	private float speed;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
		startPos = new Vector2 (stageDimensions.x * 1.3f, -4.4f);
		position = startPos;
		speed = CoralMoveManager.speed;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (GameManager.paused == true) {
			CoralMoveManager.PauseGame ();
		} else {
			CoralMoveManager.ResumeGame ();
		}*/

		if (position.x > -14) {

			position.Set (position.x - (Time.timeScale * speed), position.y);
			rb2d.MovePosition (position);

		} else {

			position.Set (startPos.x, startPos.y);

		}
	}
}
