using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class DemonRise : MonoBehaviour
{
    //private ParticleSystem demonRise;
    [SerializeField] GameObject quest;
    [SerializeField] GameObject demon;
    [SerializeField] GameObject demonItem1;
    [SerializeField] GameObject demonItem2;
    [SerializeField] GameObject demonItem3;
    [SerializeField] GameObject demonItem4;
    [SerializeField] GameObject demonItem5;
    [SerializeField] GameObject demonItem6;
    [SerializeField] GameObject sQuest9;
    [SerializeField] GameObject sQuest3a;
    [SerializeField] GameObject sQuest4a;

    
    void Update()
    {
        DemonQuest();
    }

    private void DemonQuest()
    {
        if (demonItem1.activeSelf == true && demonItem2.activeSelf == true && demonItem3.activeSelf == true && demonItem4.activeSelf == true && demonItem5.activeSelf == true && demonItem6.activeSelf == true)
        {
            sQuest9.SetActive(true);
            demon.SetActive(true);
            //demonRise.Play();
            quest.GetComponent<Text>().fontStyle = FontStyle.Italic;
            quest.GetComponent<Text>().color = new Color(0.2f, 0.2f, 0.2f, 0.4f);
        }
    }
}
