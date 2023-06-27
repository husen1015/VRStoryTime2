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
    // Start is called before the first frame update
    void Start()
    {
        shouldMove= false;
        moveSpeed = 1f;
        hoverOffset= 0.2f;
        hoverSpeed = 3f;
        initialPos = transform.position;    
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
            moveTowardsPlayer();
        }
    }
    private bool IsInteracting()
    {
        foreach (XRBaseInteractable interactable in handInteractor.interactablesSelected)
        {
            if (interactable.gameObject == gameObject)
            {
                return true;
            }
        }
        return false;
    }
    private void moveTowardsPlayer()
    {
        //hover();
        float distance = Vector3.Distance(transform.position, Player.position);
        hover();
        if (distance > 1.5)
        {
            //transform.LookAt(Player.position);
            Vector3 direction = (Player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        else { shouldMove= false; }
    }
    private void hover(/*Transform transform*/)
    {
        //calculate the offset from original height in a periodic time
        float yOffset = Mathf.Sin(Time.time * hoverSpeed) * hoverOffset;
        //Debug.Log(yOffset);
        transform.position =  new Vector3(transform.position.x,initialPos.y + yOffset, transform.position.z);
    }
    public void OnPointingDetected()
    {
        // Functionality to be executed when pointing is detected
        Debug.Log("Pointing detected!");
        shouldMove= true;
    }
}
