using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private TMPro.TextMeshProUGUI fpsUI;
    private float deltaTime;
    private float nextActionTime = 0.0f;
    private float period = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        fpsUI = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            fpsUI.text = $"FPS {Mathf.Ceil(fps)}";
        }
    }
}
