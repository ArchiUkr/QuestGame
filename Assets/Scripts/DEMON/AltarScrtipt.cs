using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class AltarScrtipt : MonoBehaviour
{
    [SerializeField] GameObject quest;
    [SerializeField] GameObject sQuest7;
   
    void OnTriggerEnter(Collider other)
    {
        sQuest7.SetActive(true);
        quest.GetComponent<Text>().fontStyle = FontStyle.Italic;
        quest.GetComponent<Text>().color = new Color(0.2f, 0.2f, 0.2f, 0.4f);
    }
}
