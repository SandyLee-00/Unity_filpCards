using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void flipCard()
    {
        anim.SetBool("isFilped", true);
        transform.Find("front").gameObject.SetActive(true);
        transform.Find("back").gameObject.SetActive(false);

        if(GameManager.GM.firstCard == null)
        {
            GameManager.GM.firstCard = gameObject;
        }
        else
        {
            GameManager.GM.secondCard = gameObject;
            GameManager.GM.isMatched();
        }
    }

    public void destroyCard()
    {
        Invoke("destroyCardInvoke", 0.5f);
    }
    private void destroyCardInvoke()
    {
        Destroy(gameObject);
    }
    public void closeCard()
    {
        Invoke("closeCardInvoke", 0.5f);
    }
    private void closeCardInvoke()
    {
        anim.SetBool("isFilped", false);
        transform.Find("front").gameObject.SetActive(false);
        transform.Find("back").gameObject.SetActive(true);
    }
}
