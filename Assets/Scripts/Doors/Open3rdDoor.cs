using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open3rdDoor : MonoBehaviour
{
    [SerializeField] GameObject quest;
    [SerializeField] GameObject Door;
    [SerializeField] GameObject Witch;

    void OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.tag == "Ice Magic")
        {
            Witch.SetActive(true);
            Door.SetActive(false);
            quest.GetComponent<Text>().fontStyle = FontStyle.Italic;
            quest.GetComponent<Text>().color = new Color(0.2f, 0.2f, 0.2f, 0.4f);
        }
    }
}
