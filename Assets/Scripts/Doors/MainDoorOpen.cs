using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class MainDoorOpen : MonoBehaviour
{
    private ParticleSystem DoorBoom;
    public static float time = 0;
    [SerializeField] GameObject quest;
    [SerializeField] GameObject sQuest3;

    [SerializeField] GameObject foxInDoor;
    [SerializeField] GameObject ravenInDoor;

    [SerializeField] GameObject foxInhouse;
    [SerializeField] GameObject ravenHouse;
    [SerializeField] GameObject mainDoor;

    void Start()
    {
        DoorBoom = GameObject.Find("DoorBoom").GetComponent<ParticleSystem>();
    }

    void Update()
    {
        QuestManager();
    }

    private void QuestManager()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else if (time < 0)
        {

            quest.GetComponent<Text>().fontStyle = FontStyle.Italic;
            quest.GetComponent<Text>().color = new Color(0.2f, 0.2f, 0.2f, 0.4f);
            foxInDoor.SetActive(false);
            ravenInDoor.SetActive(false);
            mainDoor.SetActive(false);
            time = 0;
            sQuest3.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision myCollision)
    {
        

        if(myCollision.gameObject.tag == "OpenDoorObject")
        {
            Debug.Log("Hit the floor");
            GameObject.Find("ID2").SetActive(false);
            DoorBoom.Play();
            time = 3.2f;
            ravenHouse.SetActive(true);
            foxInhouse.SetActive(true);
           
        }

    }
}

