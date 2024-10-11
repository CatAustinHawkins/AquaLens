using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIshMenuChange : MonoBehaviour
{
    public GameObject[] Pages; //an array of all the page headings 
    public int CurrentPage; //the current page open

    public AudioSource Select;

    public void FishPageAdd()
    {

            Pages[CurrentPage].SetActive(false);
            CurrentPage++;
            Pages[CurrentPage].SetActive(true);

        Select.Play();

    }

    public void FishPageDecrease()
    {
        Pages[CurrentPage].SetActive(false);
        CurrentPage--;
        Pages[CurrentPage].SetActive(true);
        Select.Play();
    }
}
