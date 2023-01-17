using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class Menu : MonoBehaviour
{

	public static bool isOpened = false;
	public float timer;
	private static float time = 0;
	[SerializeField] GameObject cameraHolder;
	[SerializeField] GameObject canvasHolder;


	void Update()
    {
        StopGame();
    }

    private void StopGame()
    {
        Time.timeScale = timer;

        if (Input.GetKeyDown(KeyCode.Escape) && time <= 0 && BookFQ.isOpened2 == false)
        {
            isOpened = !isOpened;
            time = 20f;
        }

        if (isOpened == true && BookFQ.isOpened2 == false)
        {
            cameraHolder.GetComponent<HS_CameraController>().enabled = false;
            canvasHolder.SetActive(false);
            GetComponent<Canvas>().enabled = isOpened;
            Cursor.lockState = CursorLockMode.None;
            timer = 0;
            time -= 1f;
            Cursor.visible = true;
        }
        else if (isOpened == false && BookFQ.isOpened2 == false)
        {
            GetComponent<Canvas>().enabled = isOpened;
            cameraHolder.GetComponent<HS_CameraController>().enabled = true;
            canvasHolder.SetActive(true);
            time -= 1f;
            timer = 1f;
            Cursor.visible = false;
        }
    }

    void ShowHideMenu()
	{
		isOpened = !isOpened;
		GetComponent<Canvas>().enabled = !isOpened;
	}


	public void QuitGame()
	{
		Application.Quit();
	}

    [System.Obsolete]
    void NewGame()
	{
		isOpened = false;
        Application.LoadLevel(Application.loadedLevel);
        BookFQ.isOpened2 = false;

	}

}
