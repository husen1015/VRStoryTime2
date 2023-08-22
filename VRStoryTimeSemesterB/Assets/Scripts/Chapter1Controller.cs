using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1Controller : MonoBehaviour
{
    public GameObject Parrot;
    public GameObject Melody;
    public GameObject Player;
    enum GameState
    {
        melodyWaiting,
        melodyParrotConvo,
        convoEnd
    }
    GameState currState= GameState.melodyWaiting;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        //if(AudioManager.Instance!= null)
        //    AudioManager.Instance.PlayFirstLevelMusic();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(currState== GameState.melodyWaiting && Vector3.Distance(Parrot.transform.position, Player.transform.position) < 5f)
        {
            MelodyCh1.Instance.shouldWait= false;
        }
    }


}
