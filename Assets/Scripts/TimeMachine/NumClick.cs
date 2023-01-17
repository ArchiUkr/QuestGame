using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class NumClick : MonoBehaviour
{
    public GameObject num;
    public string codeNum = "";
    public Material activeMaterial;

    void OnMouseDown()
    {
        if (num.GetComponent<Renderer>().material != activeMaterial && OpenTimeMachine.numActive == 1)
        {
            num.GetComponent<MeshRenderer>().material = activeMaterial;
            OpenTimeMachine.code += codeNum;
            OpenTimeMachine.colbTimer = 0f;
        }      
    }
}
