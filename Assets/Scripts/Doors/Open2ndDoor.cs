using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class Open2ndDoor : MonoBehaviour
{
    [SerializeField] GameObject quest;
    [SerializeField] GameObject sQuest6;
   
    void OnCollisionEnter(Collision myCollision)
    {
       
        if (myCollision.gameObject.tag == "Magic")
        {
            GameObject.Find("Door2nd").SetActive(false);
            quest.GetComponent<Text>().fontStyle = FontStyle.Italic;
            quest.GetComponent<Text>().color = new Color(0.2f, 0.2f, 0.2f, 0.4f);
            sQuest6.SetActive(true);
        }
    }
}
