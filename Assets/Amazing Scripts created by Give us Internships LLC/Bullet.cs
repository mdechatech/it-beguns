using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject bullet;
	public float projectileSpeed;

	// Use this for initialization
	void Start () {
		projectileSpeed = 20f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GameObject bigBoy = Instantiate (bullet);
			bigBoy.transform.position = transform.position;
			bigBoy.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed,0); //Change y later dawg
		}
	}
}
