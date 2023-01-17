using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class BookFQ : MonoBehaviour
{
    public static bool isOpened2 = false;
    private static float time = 0;
    [SerializeField] GameObject cameraHolder;
    [SerializeField] GameObject canvasHolder;

    void Update()
    {
        OpenBook();
    }

    private void OpenBook()
    {
        if (Input.GetKey(KeyCode.Q) && time <= 0 && Menu.isOpened == false)
        {
            isOpened2 = !isOpened2;
            time = 20f;
        }
        else if (Input.GetKey(KeyCode.Escape) && isOpened2 == true && time <= 0)
        {
            isOpened2 = false;
            Menu.isOpened = false;
        }

        if (isOpened2 == true && Menu.isOpened == false)
        {
            canvasHolder.SetActive(false);
            GetComponent<Canvas>().enabled = isOpened2;
            time -= 1f;
        }
        else if (isOpened2 == false && Menu.isOpened == false)
        {
            GetComponent<Canvas>().enabled = isOpened2;
            canvasHolder.SetActive(true);
            time -= 1f;
        }
    }

     void ShowHideMenu()
    {
        isOpened2 = !isOpened2;
        GetComponent<Canvas>().enabled = !isOpened2;
    }
}
