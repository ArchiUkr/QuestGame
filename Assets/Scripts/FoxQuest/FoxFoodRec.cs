using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class FoxFoodRec : MonoBehaviour
{
    [SerializeField] GameObject food;
    int a = 0;
    int b = 0;
    int c = 0;
    string bee = "";
    string grib = "";
    void Start()
    {
    }

    void Update()
    {
        if (a == 1 && b == 1 && c == 1)
        {
            food.SetActive(true);
            GameObject.Find("ID5051").transform.position = new Vector3(0, -500, 0);
            GameObject.Find(bee).transform.position = new Vector3(0, -500, 0);
            GameObject.Find(grib).transform.position = new Vector3(0, -500, 0);
        }
    }

    void OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.name == "ID5051") { a = 1; }
        if (myCollision.gameObject.name == "ID813") { b = 1; bee = "ID813"; }
        else if (myCollision.gameObject.name == "ID812") { b = 1; bee = "ID812"; }
        else if (myCollision.gameObject.name == "ID811") { b = 1; bee = "ID811"; }
        if (myCollision.gameObject.name == "ID9654") { c = 1; grib = "ID9654"; }
        else if (myCollision.gameObject.name == "ID9651") { c = 1; grib = "ID9651"; }
        else if (myCollision.gameObject.name == "ID9643") { c = 1; grib = "ID9643"; }
        else if (myCollision.gameObject.name == "ID9644") { c = 1; grib = "ID9644"; }

    }
    void OnCollisionExit(Collision myCollision)
    {
        if (myCollision.gameObject.name == "ID5051") { a = 0; }
        if (myCollision.gameObject.name == "ID813") { b = 0; bee = ""; }
        else if (myCollision.gameObject.name == "ID812") { b = 0; bee = ""; }
        else if (myCollision.gameObject.name == "ID811") { b = 0; bee = ""; }
        if (myCollision.gameObject.name == "ID9654") { c = 0; grib = ""; }
        else if (myCollision.gameObject.name == "ID9651") { c= 0; grib = ""; }
        else if (myCollision.gameObject.name == "ID9643") { c= 0; grib = ""; }
        else if (myCollision.gameObject.name == "ID9644") { c = 0; grib = ""; }

    }
}
