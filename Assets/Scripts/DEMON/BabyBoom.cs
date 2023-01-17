using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBoom : MonoBehaviour
{
    private ParticleSystem babyBoom;

    [SerializeField] GameObject demon;
    [SerializeField] GameObject demonSit;
    void Start()
    {
        babyBoom = GameObject.Find("DoorBoom").GetComponent<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            babyBoom.Play();
            GameObject.Find("ID66666").SetActive(false);
            demon.SetActive(false);
            demonSit.SetActive(true);
        }
    }
}
