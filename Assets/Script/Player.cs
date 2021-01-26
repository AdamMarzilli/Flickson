﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 dir = new Vector3();
    public string shape = "Circle";
    public bool inMotion = false;
    public SpawnManager spawnManager;

    private float speed = 10f;
    private Vector3 normal;

    public Player(){}

    public Player(string shape, SpawnManager spawnManager)
    {
        this.shape = shape;
        this.spawnManager = spawnManager;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(dir * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            normal = collision.contacts[0].normal;
            Vector3 newDir = dir - 2f * (Vector3.Dot(dir, normal) * normal);
            dir = newDir;
        }

        if (collision.gameObject.tag == "Shape")
        {
            if (collision.gameObject.GetComponent<Shape>().shape == this.shape)
            {
                // TODO: Get points or something
                Debug.Log("Points or something");
            }
            else
            {
                // TODO: Game over
                Debug.Log("Game over");
            }

            spawnManager.SpawnNewPlayer();
            Destroy(this.gameObject);
        }
    }
    
}