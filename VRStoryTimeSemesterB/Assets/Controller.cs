using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject book;
    public GameObject cameraObj;

    private BookBehavior bookBehavior;
    private BloomEffect cameraBehavior;

    private void Start()
    {
        bookBehavior = book.GetComponent<BookBehavior>();
        cameraBehavior = cameraObj.GetComponent<BloomEffect>();
        cameraObj.GetComponent<BloomEffect>().activateBloomGlow();
    }
    void Update()
    {
        if (bookBehavior.shouldMove)
        {
            //cameraObj.GetComponent<BloomEffect>().deactivateBloomEffect();
            cameraBehavior.deactivateBloomEffect();
        }
        else
        {
            //cameraObj.GetComponent<BloomEffect>().activateBloomGlow();
            cameraBehavior.activateBloomGlow();
        }

    }
}
