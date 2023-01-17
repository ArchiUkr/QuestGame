using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Text.RegularExpressions;

public class Die : MonoBehaviour
{
    private static float time = -1;
    [SerializeField] Transform player;
    [SerializeField] Transform grave;
    [SerializeField] GameObject playerWitch;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        time -= 1f;
        if (Input.GetKeyUp("4") && time <= -1 && Menu.isOpened == false && BookFQ.isOpened2 == false)
        {
            playerWitch.GetComponent<HS_ArcherInput>().enabled = false;
            time = 20f;
            player.transform.position = grave.position;
            GetComponent<Canvas>().enabled = true;
        }
        else if (time == 0)
        {
            GetComponent<Canvas>().enabled = false;
            playerWitch.GetComponent<HS_ArcherInput>().enabled = true;
        }
    }
}
