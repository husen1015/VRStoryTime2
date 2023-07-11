using FMODUnity;
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
    public GameObject runes;
    private ParticleSystem runesParticleSystem;
    private AzureTimeController timeController;
    private bool speedUpTime;
    private bool runesStartedPlaying;
    FMOD.Studio.EventInstance music;

    private void Start()
    {
        runesParticleSystem = runes.GetComponent<ParticleSystem>();
        runesParticleSystem.Stop();
        runesStartedPlaying = false;

        music = RuntimeManager.CreateInstance("event:/roomMusic");
        music.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(this.transform));
        RuntimeManager.AttachInstanceToGameObject(music, transform);

        speedUpTime = false;
        bookBehavior = book.GetComponent<BookBehavior>();
        cameraBehavior = cameraObj.GetComponent<BloomEffect>();
        timeController= skybox.GetComponent<AzureTimeController>();
        //cameraObj.GetComponent<BloomEffect>().activateBloomGlow();
        music.start();
    }
    void Update()
    {   
        Vector2 currTime = timeController.GetTimeOfDay();

        if (bookBehavior.shouldMove)
        {
            //cameraObj.GetComponent<BloomEffect>().deactivateBloomEffect();
            //cameraBehavior.deactivateBloomEffect();
            music.setParameterByName("Parameter 3", 1);
            runesParticleSystem.Stop();
        }

        //activate it after 8 pm if player hadnt called for book
        else if(currTime.x >= 18f || currTime.x < 4f)
        {
            //Debug.Log("activating bloom");
            //cameraBehavior.activateBloomGlow();
            if (!runesStartedPlaying)
            {
                runesParticleSystem.Play();
                runesStartedPlaying = true;
            }
        }
        //transition time to 19:00 to set up the scene
        else if(currTime.x < 18 || (currTime.x > 18 && currTime.y < 36)) { 
            Debug.Log("time speeding");
            timeController.StartTimelineTransition(18, 30, 2, AzureTimeDirection.Forward);

        }

    }
}
