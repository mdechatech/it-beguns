using UnityEngine;
using System.Collections;

public class BadGuyDestroyBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D Bullet){
		if (Bullet.gameObject.tag == "Bullet") {
			Destroy(Bullet.gameObject);
			Debug.Log("NIce shot dawg");
			
			//Call a method in the object to remove boss health
			//Then do an if statement asking if(blahblahblah.getHealth() <= 0) then Destroy(badGuy.gameObject) I THINK????
			//THen when bad guy is destroyed, set a boolean value for something like bool bossDead, and then check if boss is dead in update method then move to next stage
		}
	}
}
