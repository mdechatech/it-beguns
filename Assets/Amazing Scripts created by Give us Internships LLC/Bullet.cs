using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject bullet;
	public float projectileSpeed;
	public Transform bigBoyTarget;

	// Use this for initialization
	void Start () {
		projectileSpeed = 2000f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GameObject bigBoy = Instantiate (bullet);
			bigBoy.transform.position = transform.position;
			bigBoy.GetComponent<Rigidbody2D>().velocity = (bigBoyTarget.position - transform.position).normalized*projectileSpeed; //Change y later dawg

		}
	}
}
