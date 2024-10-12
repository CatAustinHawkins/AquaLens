using System.Collections;
using UnityEngine;

public class CameraButton : MonoBehaviour
{
    public GameObject CameraUIOverlay;
    public GameObject Player;
    public GameObject PlayerCamera;
    public GameObject FishMenu;

    public bool CameraOpen;

    public bool Cooldown;
    public Camera MainCamera;

    public bool InUse;

    public AudioSource Select;

    public void Open()
    {
        if (!CameraOpen && !Cooldown)
        {
            CameraUIOverlay.SetActive(true);
            PlayerCamera.SetActive(true);
            Player.SetActive(false);
            FishMenu.SetActive(false);
            CameraOpen = true;
            StartCoroutine(Delay());
            InUse = true;
            Select.Play();
        }

        if (CameraOpen && !Cooldown)
        {
            CameraUIOverlay.SetActive(false);
            PlayerCamera.SetActive(false);
            Player.SetActive(true);
            FishMenu.SetActive(true);

            CameraOpen = false;
            StartCoroutine(Delay());
            MainCamera.orthographicSize = 5;
            InUse = false;
            Select.Play();

        }
    }

    IEnumerator Delay()
    {
        Cooldown = true;
        yield return new WaitForSecondsRealtime(0.25f);
        Cooldown = false;
    }

}
