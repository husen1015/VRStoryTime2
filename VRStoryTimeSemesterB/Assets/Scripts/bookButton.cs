using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookButton : MonoBehaviour
{
    public GameObject book;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void activateBook()
    {
        book.GetComponent<BookBehavior>().shouldMove= true;
    }
}
