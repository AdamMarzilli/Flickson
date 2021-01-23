using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 dir = new Vector3();
    private float speed = 10f;
    private Vector3 normal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(dir * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            normal = collision.contacts[0].normal;
            Vector3 newDir = dir - 2f * (Vector3.Dot(dir, normal) * normal);
            dir = newDir;
        }
    }
}