using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class DemonItemAdd : MonoBehaviour
{
    [SerializeField] GameObject demon;
    [SerializeField] GameObject demonItemReal;
    [SerializeField] GameObject demonItemActivator;
    [SerializeField] GameObject demonItemGhost;

    void OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject == demonItemActivator)
        {
            demonItemGhost.SetActive(false);
            demonItemReal.SetActive(true);
            demonItemActivator.SetActive(false);
        }
    }
}
