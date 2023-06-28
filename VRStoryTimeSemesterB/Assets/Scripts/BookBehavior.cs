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
    private float moveSpeed;
    private float hoverSpeed;
    private float hoverOffset;
    private Vector3 initialPos;
    public bool shouldMove;
    Animator bookAnim;
    private bool doneHovering;
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
        moveSpeed = 0.5f;
        hoverOffset= 0.2f;
        hoverSpeed = 3f;
        initialPos = transform.position;    
        doneHovering= false;
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
            //TODO: this should be called when the player points at the book
            //moveTowardsPlayer();
            bookAnim.SetBool("shouldHover", true);
            //this.GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.OpenMiddle, 3f);

        }
        if (bookAnim.GetBool("DoneHovering") == true)
        {
            //Debug.Log("done hovering");
            this.GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.OpenMiddle, 3f);
            //this.GetComponent<EndlessBook>().SetState(EndlessBook.StateEnum.OpenMiddle,3f);

        }

    }
    //private bool IsInteracting()
    //{
    //    foreach (XRBaseInteractable interactable in handInteractor.interactablesSelected)
    //    {
    //        if (interactable.gameObject == gameObject)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}
    private void moveTowardsPlayer()
    {
        ////hover();
        //float distance = Vector3.Distance(transform.position, Player.position);
        //hover();
        //if (distance > 1.5)
        //{
        //    //transform.LookAt(Player.position);
        //    Vector3 direction = (Player.position - transform.position).normalized;
        //    transform.position += direction * moveSpeed * Time.deltaTime;
        //}
        //else { shouldMove = false; }
        //hoveringAnimation.Play();
        //shouldMove = false;


    }
    //private void hover(/*Transform transform*/)
    //{
    //    //calculate the offset from original height in a periodic time
    //    float yOffset = Mathf.Sin(Time.time * hoverSpeed) * hoverOffset;
    //    //Debug.Log(yOffset);
    //    transform.position =  new Vector3(transform.position.x,initialPos.y + yOffset, transform.position.z);
    //}
    public void OnPointingDetected()
    {
        // Functionality to be executed when pointing is detected
        Debug.Log("Pointing detected!");
        shouldMove= true;
    }
}
