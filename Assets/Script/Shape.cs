using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{

    public string shape = "Circle";
    private SpawnManager spawnManager;

    public Shape()
    {
        shape = "Circle";
    }

    public Shape(string shape, SpawnManager spawnManager)
    {
        this.shape = shape;
        this.spawnManager = spawnManager;
    }
}
