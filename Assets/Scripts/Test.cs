using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Test : MonoBehaviour
{
    public GameObject[] screenshotPreview;
    public int SC;
    public bool cooldown;

    public string Error;
    public TextMeshProUGUI Testing;

    public void Update()
    {
        if(Input.GetKey(KeyCode.E) && !cooldown)
        {
            StartCoroutine(TakeScreenshot());
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        cooldown = true;
        yield return new WaitForSecondsRealtime(0.2f);
        cooldown = false;

    }

    public IEnumerator TakeScreenshot()
    {

        string imageName = "screenshot.png";

        // Take the screenshot
        ScreenCapture.CaptureScreenshot(Application.dataPath + imageName);

        //Wait for 4 frames
        for (int i = 0; i < 5; i++)
        {
            yield return null;
        }

        Debug.Log(Application.dataPath);
        Error = Application.dataPath;
        Testing.text = Error;

        // Read the data from the file
        byte[] data = File.ReadAllBytes(Application.dataPath + imageName);

        // Create the texture
        Texture2D screenshotTexture = new Texture2D(Screen.width, Screen.height);

        // Load the image
        screenshotTexture.LoadImage(data);

        // Create a sprite
        Sprite screenshotSprite = Sprite.Create(screenshotTexture, new Rect(0, 0, Screen.width, Screen.height), new Vector2(0.5f, 0.5f));

        // Set the sprite to the screenshotPreview
        screenshotPreview[SC].GetComponent<Image>().sprite = screenshotSprite;
        SC++;

    }
}
