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
			Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y) );
			Vector2 myPos = new Vector2(transform.position.x,transform.position.y + 1);
			Vector2 direction = target - myPos;
			direction.Normalize();

			GameObject bigBoy = (GameObject)Instantiate (bullet, myPos, Quaternion.identity);
			bigBoy.transform.position = transform.position;
			bigBoy.GetComponent<Rigidbody2D>().velocity = direction*projectileSpeed; //Change y later dawg
			
		}

	}
	

}
