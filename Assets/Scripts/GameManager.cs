using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text txtTime;
    float time = 0.0f;

    public GameObject card;

    void Start()
    {
        for(int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        txtTime.text = time.ToString("N1");
    }
}
