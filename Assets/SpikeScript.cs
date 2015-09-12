using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Player")
        {
            PlayerMotion pm = c.gameObject.GetComponent<PlayerMotion>();
            pm.dead = true;
        }
    }
}
