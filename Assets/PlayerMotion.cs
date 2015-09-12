﻿using UnityEngine;
using System.Collections;

public class PlayerMotion : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;
    public float glideSpeed;

    public int maxJumps;
    public int jumpCount;
    public bool gliding;

    public bool dead;

    public Rigidbody2D rb;
    public GameObject spawn;

    public int temp = 0;
    public bool canGlide;

    public Manager m;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ModifyAbilities();


        float horzMove = Input.GetAxis("Horizontal") * moveSpeed;
        transform.Translate(horzMove, 0, 0);


        if (jumpCount < maxJumps && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpSpeed);
            jumpCount++;
        }
        else if (jumpCount == maxJumps && Input.GetKeyDown(KeyCode.W))
            gliding = true;

        if (canGlide && gliding && Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0, glideSpeed);
        }
        else if (gliding && Input.GetKeyUp(KeyCode.W))
            gliding = false;


        if (dead)
        {
            transform.position = spawn.transform.position;
            dead = false;
            gliding = false;
            jumpCount = 0;
        }
	}

    void OnCollisionEnter2D (Collision2D c)
    {
        if (c.gameObject.tag == "Floor" && c.contacts[0].normal.x == 0)
            jumpCount = 0;
    }

    void ModifyAbilities()
    {
        switch (temp)
        {
            case 1:
                moveSpeed = .1F;
                break;
            case 2:
                maxJumps = 1;
                break;
            case 6:
                maxJumps = 2;
                break;
        }
        switch (m.Wins)
        {
            case 1: moveSpeed = .1F;
                break;
            case 2: maxJumps = 1;
                break;
            case 6: maxJumps = 2;
                break;
        }
    }
}
