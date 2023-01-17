using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart1 : MonoBehaviour
{
    public static float timePause = 0;
    void Update()
    {
        timePause -= 1f;
        if (timePause == -3)
        {
            Menu.isOpened = true;
        }
    }
}
