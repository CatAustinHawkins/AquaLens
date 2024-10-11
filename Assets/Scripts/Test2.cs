using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SavedGamesSlots : MonoBehaviour
{
    public float moveSpeed;

    public GameObject Bar;

    public CameraCheck CameraCheckScript;

    public GameObject Player;

    public GameObject GreenBar;

    public Vector2 Position1 = new Vector2(-2.5f,-3.22f);
    public Vector2 Position2 = new Vector2(-1.5f, -3.22f);
    public Vector2 Position3 = new Vector2(-0.5f, -3.22f);
    public Vector2 Position4 = new Vector2(0.5f, -3.22f);
    public Vector2 Position5 = new Vector2(1.5f, -3.22f);
    public Vector2 Position6 = new Vector2(2.5f, -3.22f);

    public int random;

    public void OnEnable()
    {
        
        StartCoroutine(Cooldown());
        Player.transform.position = new Vector2(0, -3.215f);
        random = Random.Range(1, 7);
        switch(random)
        {
            case 1:
                GreenBar.transform.position = Position1;
                break;
            case 2:
                GreenBar.transform.position = Position2;
                break;
            case 3:
                GreenBar.transform.position = Position3;
                break;
            case 4:
                GreenBar.transform.position = Position4;
                break;
            case 5:
                GreenBar.transform.position = Position5;
                break;
            case 6:
                GreenBar.transform.position = Position6;
                break;
        }
    }

    public void RandomPosition()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position += transform.right * -moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position += transform.right * moveSpeed * Time.deltaTime;
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "GreenBar")
        {
            Debug.Log("Green Bar Hit");
            Bar.SetActive(false);
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSecondsRealtime(3f);
        Bar.SetActive(false);
    }
}