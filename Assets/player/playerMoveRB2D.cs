﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveRB2D : MonoBehaviour
{
	const string up = "North";
	const string right = "East";
	const string down = "South";
	const string left = "West";
	const string walk = "Player";
	const string idle = "Idle";
	const string attack = "Attack";
    Vector3 movement;                                // For movement
    int speed = 1;                         // Speed of movement
    Rigidbody2D rb2d;
	Animator animator;
	playerStatus status;
	string lastMove = down;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator> ();
        speed = GetComponent<playerStatus>().speed;
		status = GetComponent<playerStatus> ();
    }

    void FixedUpdate()
    {
		string animation = idle + lastMove;
		movement = new Vector3 ();
        if (Input.GetKey(KeyCode.A))
        {        // Left
			movement += Vector3.left;
			animation = walk + left;
			lastMove = left;
			status.face_direction = playerStatus.directions.left;
        }
        if (Input.GetKey(KeyCode.D))
        {        // Right
			movement += Vector3.right;
			animation = walk + right;
			lastMove = right;
			status.face_direction = playerStatus.directions.right;
        }
        if (Input.GetKey(KeyCode.W))
        {        // Up
			movement += Vector3.up;
			animation = walk + up;
			lastMove = up;
			status.face_direction = playerStatus.directions.up;
        }
        if (Input.GetKey(KeyCode.S))
        {        // Down
			movement += Vector3.down;
			animation = walk + down;
			lastMove = down;
			status.face_direction = playerStatus.directions.down;
        }
		animator.Play (animation);
		rb2d.velocity = movement * speed;
		//rb2d.MovePosition(Vector3.MoveTowards(rb2d.position, pos * speed, Time.deltaTime));    // Move there
    }
}
