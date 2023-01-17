using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class SkelotonSay : MonoBehaviour
{
    public  float time = 400f;
    private static float time2 = 0;
    [SerializeField] GameObject skeletonText;

    void Update()
    {
        time2 -= Time.deltaTime;
        if (time2 <= 0)
        {
            skeletonText.SetActive(false);
        }
    }
    void OnMouseDown()
    {
            skeletonText.SetActive(true);
            time2 = time;
    }
}
