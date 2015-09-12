using UnityEngine;
using System.Collections;

public class DeleteBullet : MonoBehaviour {
	float lifetime;
	// Use this for initialization
	void Start () {
		lifetime = 1.0f;
		Destroy (this,lifetime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
