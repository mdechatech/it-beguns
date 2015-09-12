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
		canvas.alpha -= .05f;
		if (canvas.alpha == 0f) {
			Application.LoadLevel (1);
		}
	}
}
