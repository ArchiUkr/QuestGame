using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class OpenTimeMachine : MonoBehaviour
{
    public static string code = "";
    public static float colbTimer = 0f;
    public static int numActive = 1;
    [SerializeField] GameObject colb;
    [SerializeField] GameObject quest;
    [SerializeField] Material normalMaterial;
    [SerializeField] Material greenMaterial;
    private ParticleSystem ColbBoom;
    private float timeColbBoom = 0;

    void Start()
    {
        ColbBoom = GameObject.Find("ColbBoom").GetComponent<ParticleSystem>();
    }


    void Update()
    {
        TimeMachine();

        OpenMachine();
    }

    private void OpenMachine()
    {
        if (timeColbBoom >= 0)
        {
            timeColbBoom -= Time.deltaTime;
        }
        if (timeColbBoom <= 3.2f && timeColbBoom >= 3f)
        {
            ColbBoom.Play();
        }
        if (timeColbBoom <= 3f && timeColbBoom >= 2.8f)
        {
            colb.SetActive(false);
            quest.GetComponent<Text>().text = "- Ввести верный код и разблокировать машину времени";
            quest.GetComponent<Text>().fontSize = 35;
            quest.GetComponent<Text>().fontStyle = FontStyle.Italic;
            quest.GetComponent<Text>().color = new Color(0.2f, 0.2f, 0.2f, 0.4f);
            code = "";
            numActive = 1;
            timeColbBoom = -2;
        }
    }

    private void TimeMachine()
    {
        colbTimer -= 1f;
        if (code == "5819" && colbTimer % 10 == 0 && numActive == 1)
        {
            numActive = 0;
            GameObject.Find("CubeOne").GetComponent<MeshRenderer>().material = greenMaterial;
            GameObject.Find("CubeFive").GetComponent<MeshRenderer>().material = greenMaterial;
            GameObject.Find("CubeEight").GetComponent<MeshRenderer>().material = greenMaterial;
            GameObject.Find("CubeNine").GetComponent<MeshRenderer>().material = greenMaterial;
            timeColbBoom = 4f;
            code = "";

        }
        else if (code != "5819" && code.Length >= 4 && colbTimer % 20 == 0)
        {
            GameObject.Find("CubeZero").GetComponent<MeshRenderer>().material = normalMaterial;
            GameObject.Find("CubeOne").GetComponent<MeshRenderer>().material = normalMaterial;
            GameObject.Find("CubeTwo").GetComponent<MeshRenderer>().material = normalMaterial;
            GameObject.Find("CubeThree").GetComponent<MeshRenderer>().material = normalMaterial;
            GameObject.Find("CubeFour").GetComponent<MeshRenderer>().material = normalMaterial;
            GameObject.Find("CubeFive").GetComponent<MeshRenderer>().material = normalMaterial;
            GameObject.Find("CubeSix").GetComponent<MeshRenderer>().material = normalMaterial;
            GameObject.Find("CubeSeven").GetComponent<MeshRenderer>().material = normalMaterial;
            GameObject.Find("CubeEight").GetComponent<MeshRenderer>().material = normalMaterial;
            GameObject.Find("CubeNine").GetComponent<MeshRenderer>().material = normalMaterial;
            code = "";
        }
    }
}
