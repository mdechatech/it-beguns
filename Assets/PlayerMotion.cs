using UnityEngine;
using System.Collections;

public class PlayerMotion : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;
    public bool onFloor;
    public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float horzMove = Input.GetAxis("Horizontal") * moveSpeed;
        transform.Translate(horzMove, 0, 0);


        if(onFloor && Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpSpeed);
            onFloor = false;
        }
            
        
	}

    void OnCollisionEnter2D (Collision2D c)
    {
        if (c.gameObject.tag == "Floor" && c.contacts[0].normal.x == 0)
            onFloor = true;
    }
}
