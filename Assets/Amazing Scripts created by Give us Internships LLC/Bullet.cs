using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject bullet;
	public float projectileSpeed;
	public float fireRate = -.35f;
	// Use this for initialization
	void Start () {
		projectileSpeed = 30f;
		fireRate = Time.time;
	}
	// Update is called once per frame
	void Update () {

		if(Time.time>=fireRate){
			if (Input.GetButton("Fire1")) {
				fireRate = Time.time + .35f;
				Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x, Input.mousePosition.y) );
				Vector2 myPos = new Vector2(transform.position.x,transform.position.y + 1);
				Vector2 direction = target - myPos;
				direction.Normalize();
				Debug.Log (target);
				GameObject bigBoy = (GameObject)Instantiate (bullet);
				bigBoy.transform.position = transform.position;
				bigBoy.GetComponent<Rigidbody2D>().velocity = direction*projectileSpeed; 
			}	
		}

	}
	

}
