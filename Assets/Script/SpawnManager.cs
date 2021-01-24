using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject shapePrefab;

    private Flick flick;
    private Vector3 playerSpawn = new Vector3(0.072f, -2.895f, 0f);
    private Vector3 shapeSpawn = new Vector3(- 1.47f, 2.86f, 0f);
    private string[] shapeTypes = { "Circle" };

    private void Start()
    {
        flick = GameObject.FindWithTag("GameController").GetComponent<Flick>();
        SpawnNewPlayer();
    }

    public void SpawnNewShape()
    {

    }

    public void SpawnNewPlayer()
    {
        GameObject player = Instantiate(playerPrefab, playerSpawn, Quaternion.identity);
        Player playerScript = player.GetComponent<Player>();
        playerScript.spawnManager = this;
        playerScript.shape = RandomizeShape();
        flick.SetPlayer(player);
    }

    private string RandomizeShape()
    {
        return shapeTypes[Random.Range(0, shapeTypes.Length)];
    }
}
