using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CameraCheck : MonoBehaviour
{
    public GameObject PJ; //Pink Jellyfish
    public GameObject WB; //White Bunny
    public GameObject BRF; //Blue Red Fish
    public GameObject PS; //Purple Seahorse
    public GameObject AT; //Sea Angel - Trans Colours
    public GameObject SR; //Red Seahorse
    public GameObject ABR; //Sea Angel - Blue and Red
    public GameObject POF; // Purple Orange Fish
    public GameObject PB; //Purple Seabunny
    public GameObject BS; //Blue Seahorse
    public GameObject C; //Normal Crab
    public GameObject PF; //Purple Jellyfish
    public GameObject YC; //Yellow Crab
    public GameObject SAB; //Sea Angel - Blue and Yellow

    public GameObject[] screenshotPreview;
    public int SC;
    public bool cooldown;

    public int ScreenShotCount;

    public AudioSource CameraSound;

    public Camera MainCamera;

    public GameObject CameraUIOverlay;
    public GameObject CameraButton;

    public bool picturetaken;

    //Checking if they are in range
    public bool PJinRange;
    public bool WBinRange;
    public bool BRFinRange;
    public bool PSinRange;
    public bool ATinRange;
    public bool SRinRange;
    public bool ABRinRange;
    public bool POFinRange;
    public bool PBinRange;
    public bool BSinRange;
    public bool CinRange;
    public bool PFinRange;
    public bool YCinRange;
    public bool SABinRange;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "pj")
        {
            PJinRange = true;
        }

        if (other.tag == "wb")
        {
            WBinRange = true;
        }

        if (other.tag == "brf")
        {
            BRFinRange = true;
        }

        if (other.tag == "ps")
        {
            PSinRange = true;
        }

        if (other.tag == "at")
        {
            ATinRange = true;
        }

        if (other.tag == "sr")
        {
            SRinRange = true;
        }

        if (other.tag == "abr")
        {
            ABRinRange = true;
        }

        if (other.tag == "pof")
        {
            POFinRange = true;
        }

        if (other.tag == "pb")
        {
            PBinRange = true;
        }

        if (other.tag == "bs")
        {
            BSinRange = true;
        }

        if (other.tag == "c")
        {
            CinRange = true;
        }

        if (other.tag == "pf")
        {
            PFinRange = true;
        }

        if (other.tag == "yc")
        {
            YCinRange = true;
        }

        if (other.tag == "sab")
        {
            SABinRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "pj")
        {
            PJinRange = false;
        }

        if (other.tag == "wb")
        {
            WBinRange = false;
        }

        if (other.tag == "brf")
        {
            BRFinRange = false;
        }

        if (other.tag == "ps")
        {
            PSinRange = false;
        }

        if (other.tag == "at")
        {
            ATinRange = false;
        }

        if (other.tag == "sr")
        {
            SRinRange = false;
        }

        if (other.tag == "abr")
        {
            ABRinRange = false;
        }

        if (other.tag == "pof")
        {
            POFinRange = false;
        }

        if (other.tag == "pb")
        {
            PBinRange = false;
        }

        if (other.tag == "bs")
        {
            BSinRange = false;
        }

        if (other.tag == "c")
        {
            CinRange = false;
        }

        if (other.tag == "pf")
        {
            PFinRange = false;
        }

        if (other.tag == "yc")
        {
            YCinRange = false;
        }

        if (other.tag == "sab")
        {
            SABinRange = false;
        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.C) && !cooldown)
        {
            StartCoroutine(TakeScreenshot());
            StartCoroutine(Cooldown());
            CameraSound.Play();
        }

        if (Input.GetKey(KeyCode.Q) && !cooldown && MainCamera.orthographicSize > 1)
        {
            MainCamera.orthographicSize--;
            StartCoroutine(Cooldown());
        }

        if (Input.GetKey(KeyCode.E) && !cooldown && MainCamera.orthographicSize < 10)
        {
            MainCamera.orthographicSize++;
            StartCoroutine(Cooldown());
        }

        if(picturetaken)
        {
            CameraUIOverlay.SetActive(true);
            CameraButton.SetActive(true);
            picturetaken = false;
        }
    }

    IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSecondsRealtime(0.35f);
        cooldown = false;

    }

    public IEnumerator TakeScreenshot()
    {
        CameraUIOverlay.SetActive(false);
        CameraButton.SetActive(false);

        string imageName = "screenshot_" + ScreenShotCount + ".png";
        ScreenShotCount++;


        // Take the screenshot
        ScreenCapture.CaptureScreenshot(Application.persistentDataPath + imageName);

        //Wait for 4 frames
        for (int i = 0; i < 5; i++)
        {

            yield return null;
        }
        CameraUIOverlay.SetActive(true);
        CameraButton.SetActive(true);

        // Read the data from the file
        byte[] data = File.ReadAllBytes(Application.persistentDataPath + imageName);

        // Create the texture
        Texture2D screenshotTexture = new Texture2D(Screen.width, Screen.height);

        // Load the image
        screenshotTexture.LoadImage(data);

        // Create a sprite
        Sprite screenshotSprite = Sprite.Create(screenshotTexture, new Rect(0, 0, Screen.width, Screen.height), new Vector2(0.5f, 0.5f));


        if(SC == 27) //if player goes over 27 images, start rewriting old ones
        {
            SC = 0;
        }

        picturetaken = true;
        CameraUIOverlay.SetActive(true);
        CameraButton.SetActive(true);

        // Set the sprite to the screenshotPreview
        screenshotPreview[SC].GetComponent<Image>().sprite = screenshotSprite;
        SC++;

        CameraUIOverlay.SetActive(true);
        CameraButton.SetActive(true);


        //If the camera lense is in range when a photo is taken, mark the fish as collected
        if (PJinRange)
        {
            PJ.SetActive(false);
        }

        if (WBinRange)
        {
            WB.SetActive(false);
        }

        if (BRFinRange)
        {
            BRF.SetActive(false);
        }

        if (PSinRange)
        {
            PS.SetActive(false);
        }

        if (ATinRange)
        {
            AT.SetActive(false);
        }

        if (SRinRange)
        {
            SR.SetActive(false);
        }

        if (ABRinRange)
        {
            ABR.SetActive(false);
        }

        if (POFinRange)
        {
            POF.SetActive(false);
        }

        if (PBinRange)
        {
            PB.SetActive(false);
        }

        if (BSinRange)
        {
            BS.SetActive(false);
        }

        if (CinRange)
        {
            C.SetActive(false);
        }

        if (PFinRange)
        {
            PF.SetActive(false);
        }

        if (YCinRange)
        {
            YC.SetActive(false);
        }

        if (SABinRange)
        {
            SAB.SetActive(false);
        }
    }

}
