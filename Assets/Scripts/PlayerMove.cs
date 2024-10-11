using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float scalesize = 0.3f;

    public float moveSpeed;

    public bool flip;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position += transform.right * -moveSpeed * Time.deltaTime;
            if (flip)
            {
                transform.localScale = new Vector3(-scalesize, scalesize, scalesize);
            }

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position += transform.right * moveSpeed * Time.deltaTime;
            if (flip)
            {
                transform.localScale = new Vector3(scalesize, scalesize, scalesize);
            }

        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position += transform.up * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position += transform.up * -moveSpeed * Time.deltaTime;
        }
    }
}
