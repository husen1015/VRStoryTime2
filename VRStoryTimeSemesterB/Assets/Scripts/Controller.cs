using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AzureSky;

public class Controller : MonoBehaviour
{
    public GameObject book;
    public GameObject cameraObj;
    public GameObject skybox;

    private BookBehavior bookBehavior;
    private BloomEffect cameraBehavior;
    private AzureTimeController timeController;
    private bool speedUpTime;

    private void Start()
    {
        speedUpTime= false;
        bookBehavior = book.GetComponent<BookBehavior>();
        cameraBehavior = cameraObj.GetComponent<BloomEffect>();
        timeController= skybox.GetComponent<AzureTimeController>();
        cameraObj.GetComponent<BloomEffect>().activateBloomGlow();
    }
    void Update()
    {   
        Vector2 currTime = timeController.GetTimeOfDay();

        if (bookBehavior.shouldMove)
        {
            //cameraObj.GetComponent<BloomEffect>().deactivateBloomEffect();
            cameraBehavior.deactivateBloomEffect();
        }

        //activate it after 8 pm if player hadnt called for book
        else if(currTime.x >= 20f || currTime.x < 4f)
        {
            //Debug.Log("activating bloom");
            cameraBehavior.activateBloomGlow();
        }
        //transition time to 19:00 to set up the scene
        else if(currTime.x < 18 || (currTime.x > 18 && currTime.y < 35)) { 
            Debug.Log("time speeding");
            timeController.StartTimelineTransition(19, 0, 5, AzureTimeDirection.Forward);

        }

    }
}
