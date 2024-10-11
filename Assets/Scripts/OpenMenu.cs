using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenMenu : MonoBehaviour
{
    public GameObject Menu;
    public bool MenuOpen;

    public AudioSource Select;
    public AudioSource[] Bubbles;

    public void Start()
    {
        StartCoroutine(BubbleNoise());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            Open();
        }
    }


    public void Open()
    {
        if(!MenuOpen)
        {
            Menu.SetActive(true);
            MenuOpen = true;
            Select.Play();
        }
        else
        {
            Menu.SetActive(false);
            MenuOpen = false;
            Select.Play();
        }
    }

    IEnumerator BubbleNoise()
    {
        int random = Random.Range(0, 4);
        Bubbles[random].Play();
        int random2 = Random.Range(10, 25);
        yield return new WaitForSecondsRealtime(random2);
        StartCoroutine(BubbleNoise());
    }
}
