using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookButton : MonoBehaviour
{
    public GameObject book;
    public Transform player;
    float weight = 0.9f;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        transform.position = Vector3.Lerp(book.transform.position, player.position, weight); ;
        transform.LookAt(player.position);
    }
    public void activateBook()
    {
        book.GetComponent<BookBehavior>().shouldMove = true;
        Destroy(gameObject);
    }
}
