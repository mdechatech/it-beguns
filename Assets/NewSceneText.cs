using UnityEngine;
using System.Collections;

public class NewSceneText : MonoBehaviour {
	CanvasGroup canvas;
    private Manager _manager;
	bool fadeIn = false;
	// Use this for initialization
	void Start ()
	{
	    _manager = GameObject.FindGameObjectWithTag("Manager")
	        .GetComponent<Manager>();
	    if (_manager != null && _manager.Boss != null)
	    {
	        _manager.Boss.gameObject.SetActive(false);
	    }
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

	    if (canvas.alpha <= 0.0f)
	    {
            if (_manager != null && _manager.Boss != null)
            {
                _manager.Boss.gameObject.SetActive(true);
            }

            Destroy(gameObject);
	    }
	}
}
