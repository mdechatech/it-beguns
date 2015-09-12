using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {
	CanvasGroup canvas;

	// Use this for initialization
	void Start () {
		canvas = GetComponent<CanvasGroup> ();
		canvas.alpha = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (canvas.alpha > .75f) {
			canvas.alpha -=.002f;
		} 
		
		if (canvas.alpha <= .75f) {
			canvas.alpha -=.02f;
		} 
		if (canvas.alpha == 0f) {
			Application.LoadLevel (1);
		}
	}
}
