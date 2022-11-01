using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public Text txtTime;
    float time = 0.0f;

    public GameObject card;

    public GameObject firstCard;
    public GameObject secondCard;

    private void Awake()
    {
        GM = this;
    }

    void Start()
    {
        int[] images = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        // search about it later
        images = images.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for(int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = GameObject.Find("cards").transform;

            float posX = (i / 4) * 1.4f - 2.1f;
            float posY = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(posX, posY, 0);

            string rtanName = "rtan" + images[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        txtTime.text = time.ToString("N1");
    }

    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if(firstCardImage == secondCardImage)
        {
            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();
        }
        else
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }
        firstCard = null;
        secondCard = null;
    }
}
