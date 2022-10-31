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
    }
}
