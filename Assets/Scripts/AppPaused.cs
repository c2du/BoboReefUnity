using UnityEngine;

public class AppPaused : MonoBehaviour {

	bool isPaused = false;


	void OnGUI( )
	{
		if( isPaused )
			GUI.Label( new Rect( 100, 100, 50, 30 ), "Game paused" );
	}

	void OnApplicationFocus( bool focusStatus )
	{
		isPaused = focusStatus;
	}

	void OnApplicationPause( bool pauseStatus )
	{
		isPaused = pauseStatus;
	}
}
