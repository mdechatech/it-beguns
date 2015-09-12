using UnityEngine;
using System.Collections;

public class NewSceneText : MonoBehaviour {
	CanvasGroup canvas;
	bool fadeIn = false;
	// Use this for initialization
	void Start () {
		canvas = GetComponent<CanvasGroup> ();
		canvas.alpha = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(fadeIn == false)
		{
			canvas.alpha += .01f;
		}
		if(canvas.alpha == 1f)
		{
			fadeIn = true;
		}

		if (fadeIn == true && canvas.alpha > .75f) {
			canvas.alpha -=.002f;
		} 

		if (fadeIn == true && canvas.alpha <= .75f) {
			canvas.alpha -=.02f;
		} 
	}
}
