using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class ChikShine : MonoBehaviour
{
    public GameObject shine;
    
    void OnMouseDown()
    {
        shine.SetActive(false);
    }
}
