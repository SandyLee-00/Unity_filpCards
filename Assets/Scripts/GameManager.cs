using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public Text txtTime;
    public GameObject scoreBoard;
    float time = 0.0f;

    public GameObject cards;
    public GameObject card;

    public GameObject firstCard;
    public GameObject secondCard;

    public AudioSource audioSource;
    public AudioClip matchSound;

    private void Awake()
    {
        GM = this;
        Time.timeScale = 1.0f;
    }

    void Start()
    {
        int[] images = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        // order list randomly
        images = images.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();

        for(int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            newCard.transform.parent = cards.transform;

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
        if(time > 30.0f)
        {
            GameOverTimeOut();
        }
    }

    public void isMatched()
    {
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if(firstCardImage == secondCardImage)
        {
            audioSource.PlayOneShot(matchSound);

            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            int leftCard = cards.transform.childCount;
            if(leftCard == 2)
            {
                GameWin();
            }
        }
        else
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }
        firstCard = null;
        secondCard = null;
    }

    private void GameOverTimeOut()
    {
        foreach (Transform child in cards.transform)
        {
            Destroy(child.gameObject);
        }

        scoreBoard.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void GameWin()
    {
        foreach(Transform child in cards.transform)
        {
            Destroy(child.gameObject);
        }
        scoreBoard.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
