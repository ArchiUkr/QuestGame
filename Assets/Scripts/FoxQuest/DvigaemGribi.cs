using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;


public class DvigaemGribi : MonoBehaviour
{
    public int ID;
    public int layerObj;
    public bool memoryLayer;
    public float yObj;
    public string nameIgnore;
    public float hitPoint;
    public static float time = 0;
    public static int a = 0;

    RaycastHit hit;
    Ray ray;

    public GameObject obj;

    void Start()
    {
        memoryLayer = true;
    }

    [Obsolete]
    void Update()
    {
        if (time > 0) { time -= Time.deltaTime; }
        else if (time <= 0) { a = 0; }
        Motionobject();
    }

    [Obsolete]
    void Motionobject()
    {
        
        if (Input.GetMouseButtonDown(0) && obj == null)
        {
            
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            
            if (Physics.Raycast(ray, out hit, 4))
            {
                
              
                
                nameIgnore = hit.collider.gameObject.name.Replace("ID", "");

               

                if (int.TryParse(nameIgnore, out int num))
               
                {
                   

                    
                    ID = Convert.ToInt32(nameIgnore);

                    if (ID != 1)
                    {
                        
                        obj = hit.collider.gameObject;
                       
                        a = 1;
                        time = 0.2f;
                    }
                }
            }
        }
       
        if (obj != null)
        {
            Ray();

           
            if (memoryLayer)
            {
              
                layerObj = obj.layer;
                memoryLayer = false;
            }

           
            obj.layer = 2;
           
            obj.transform.position = ray.GetPoint(2) + new Vector3(0, 0.1f, 0);
            if(obj.GetComponent<Rigidbody>().useGravity == false) 
            {
                obj.GetComponent<Rigidbody>().useGravity = true;
            }

        }

       
        if ((Input.GetMouseButtonDown(0) && obj != null && a != 1) || (obj != null && obj.active == false))
        {
            if (obj != null)
            {
                time = 1;
                obj.layer = layerObj;
                memoryLayer = true;
                obj = null;
            }
        }
    }

    void Ray()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
    }
}