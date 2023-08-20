using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrot : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        causeCommotion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void causeCommotion()
    {
        //make noise - add proper audio here 
    }
}
