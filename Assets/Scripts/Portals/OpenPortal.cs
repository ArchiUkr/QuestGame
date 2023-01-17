using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class OpenPortal : MonoBehaviour
{
    public static float time2 = 0;
    [SerializeField] GameObject portalDungeon;
    [SerializeField] GameObject redScull;
    [SerializeField] GameObject scullPortal;
    [SerializeField] GameObject quest;
    [SerializeField] GameObject objDel;


    [SerializeField] GameObject startQuest4;
    
    void Update()
    {
        PortalDungeon();
    }

    private void PortalDungeon()
    {
        if (time2 > 0)
        {
            objDel.transform.position = new Vector3(0, -500, 0);
            portalDungeon.SetActive(true);
            quest.GetComponent<Text>().fontStyle = FontStyle.Italic;
            quest.GetComponent<Text>().color = new Color(0.2f, 0.2f, 0.2f, 0.4f);
            time2 = 0;
            startQuest4.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision myCollision)
    {
        
        if (myCollision.gameObject.name == "ID6")
        {
           
            time2 = 2f;
            portalDungeon.SetActive(false);
            redScull.SetActive(false);
            scullPortal.SetActive(false);
        }

    }
}
