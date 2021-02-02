using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject shapePrefab;
    public GameObject playerSpawn;
    public GameObject shapeLeftSpawn;
    public GameObject shapeCenterSpawn;
    public GameObject shapeRightSpawn;
    public GameManager gameManager;

    private Flick flick;
    private string[] shapeTypes = { "Circle" };

    private void Start()
    {
        flick = GameObject.FindWithTag("GameController").GetComponent<Flick>();
    }

    public List<GameObject> SpawnNewShape(string location, List<GameObject> spawnedShapes)
    {
        GameObject goalShape;
        Shape goalScript;
        switch (location) {
            case "Right":
                goalShape = Instantiate(shapePrefab, shapeRightSpawn.transform.position, Quaternion.identity);
                goalScript = goalShape.GetComponent<Shape>();
                goalScript.location = "Right";
                break;
            case "Left":
                goalShape = Instantiate(shapePrefab, shapeLeftSpawn.transform.position, Quaternion.identity);
                goalScript = goalShape.GetComponent<Shape>();
                goalScript.location = "Left";
                break;
            default:
                goalShape = Instantiate(shapePrefab, shapeCenterSpawn.transform.position, Quaternion.identity);
                goalScript = goalShape.GetComponent<Shape>();
                goalScript.location = "Center";
                break;
        }
        spawnedShapes.Add(goalShape);
        return spawnedShapes;
    }

    public GameObject SpawnNewPlayer()
    {
        GameObject player = Instantiate(playerPrefab, playerSpawn.transform.position, Quaternion.identity);
        Player playerScript = player.GetComponent<Player>();
        playerScript.spawnManager = this;
        playerScript.shape = RandomizeShape();
        playerScript.gameManager = gameManager;
        flick.SetPlayer(player);
        return player;
    }

    private string RandomizeShape()
    {
        return shapeTypes[Random.Range(0, shapeTypes.Length)];
    }
}
