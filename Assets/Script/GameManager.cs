using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpawnManager spawnManager;

    private List<GameObject> spawnedShapes = new List<GameObject>();
    private bool[] locationSpawned = { false, false, false };
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager.SpawnNewPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGoalShapes();
    }

    void CheckGoalShapes()
    {
        for (int i = 0; i < 3; i++)
        {
            if (!locationSpawned[i])
            {
                string location;
                switch (i)
                {
                    case 0:
                        location = "Left";
                        locationSpawned[0] = true;
                        break;
                    case 1:
                        location = "Right";
                        locationSpawned[1] = true;
                        break;
                    default:
                        location = "Center";
                        locationSpawned[2] = true;
                        break;

                }
                spawnedShapes = spawnManager.SpawnNewShape(location, spawnedShapes);
            }
        }
    }

    int FindGoalShape(string location)
    {
        for (int i = 0; i < spawnedShapes.Count; i++)
        {
            if (spawnedShapes[i].GetComponent<Shape>().location == location)
            {
                return i;
            }
        }
        return -1;
    }

    public void HitGoalShape(GameObject goalShape, GameObject player)
    {
        Shape hitShape = goalShape.gameObject.GetComponent<Shape>();
        if (hitShape.shape == player.GetComponent<Player>().shape)
        {
            spawnedShapes.RemoveAt(FindGoalShape(goalShape.GetComponent<Shape>().location));
            Destroy(goalShape.gameObject);
            Debug.Log("Points or something");
        }
        else
        {
            // TODO: Game over
            Debug.Log("Game over");
        }

        Destroy(player.gameObject);
        player = spawnManager.SpawnNewPlayer();
    }

    public void test ()
    {

    }
}
