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

            float posX = (i / 4) * 1.4f - 2.1f;
            float posY = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(posX, posY, 0);
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        txtTime.text = time.ToString("N1");
    }
}
