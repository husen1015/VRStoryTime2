using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1Controller : MonoBehaviour
{
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        if(AudioManager.Instance!= null)
            AudioManager.Instance.PlayFirstLevelMusic();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
