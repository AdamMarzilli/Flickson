using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flick : MonoBehaviour
{
    Vector2 beginSwipePos;
    Vector2 endSwipePos;
    Vector2 swipeDir;
    Transform player;
    private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();

        player.Translate(swipeDir * Time.deltaTime * speed);
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

            swipeDir = new Vector3(endSwipePos.x - beginSwipePos.x, endSwipePos.y - beginSwipePos.y);
            swipeDir.Normalize();
        }

    }
    
}
