using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flick : MonoBehaviour
{
    Vector2 beginSwipePos;
    Vector2 endSwipePos;
    Vector3 swipeDir;
    Vector3 tempDir;
    GameObject player;
    private float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        Swipe();
    }

    void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            beginSwipePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endSwipePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            tempDir = new Vector3(endSwipePos.x - beginSwipePos.x, endSwipePos.y - beginSwipePos.y);
            tempDir.Normalize();
            Player playerScript = player.gameObject.GetComponent<Player>();

            if (tempDir.y > 0 && !playerScript.inMotion)
            {
                swipeDir = tempDir;
                playerScript.dir = swipeDir;
                playerScript.inMotion = true;
                
            }
        }
    }

    public void SetPlayer(GameObject newPlayer)
    {
        player = newPlayer;
    }
}
