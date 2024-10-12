using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject Menu;
    public bool MenuOpen;

    public AudioSource Select;

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
}
