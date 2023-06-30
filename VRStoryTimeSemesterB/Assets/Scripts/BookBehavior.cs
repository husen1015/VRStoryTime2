using echo17.EndlessBook;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookBehavior : MonoBehaviour
{
    public XRBaseInteractor handInteractor;
    public Transform Player;
    public bool shouldMove;
    Animator bookAnim;
    // Start is called before the first frame update
    private void Awake()
    {
        //make sure the book is closed at the start
        this.GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.ClosedFront, 0f);

    }
    void Start()
    {
        bookAnim = GetComponent<Animator>();
        shouldMove= false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsInteracting())
        //{
        //    // Call the pointing detection method
        //    OnPointingDetected();
        //}
        if (shouldMove)
        {
            bookAnim.SetBool("shouldHover", true);

        }
        if (bookAnim.GetBool("DoneHovering") == true)
        {
            //Debug.Log("done hovering");
            this.GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.OpenMiddle, 3f);

        }

    }

    public void OnPointingDetected()
    {
        // Functionality to be executed when pointing is detected
        Debug.Log("Pointing detected!");
        shouldMove= true;
    }
}
