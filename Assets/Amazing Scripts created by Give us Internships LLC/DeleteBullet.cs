using UnityEngine;
using System.Collections;

public class DeleteBullet : MonoBehaviour {
	float lifetime;
	// Use this for initialization
	void Start () {
		lifetime = 10.0f;
		Destroy (gameObject,lifetime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Floor") Destroy(gameObject);
    }
}
