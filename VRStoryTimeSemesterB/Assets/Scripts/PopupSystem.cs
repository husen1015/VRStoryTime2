using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

public class PopupSystem : MonoBehaviour
{
    //public static PopupSystem Instance { get; private set; }
    //public GameObject PopupCanvas;

    private TMP_Text PopupText;
    private Animator animator;
    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    private void Start()
    {
        animator = gameObject.GetNamedChild("Popup").GetComponent<Animator>();
        PopupText = gameObject.GetNamedChild("Popup").GetNamedChild("Text").GetComponent<TextMeshProUGUI>();
    }
    public void ShowPopUp(string text)
    {
        //PopupCanvas.SetActive(true);
        //animator.SetTrigger("Pop");
        //PopupText.text = text;

        gameObject.SetActive(true);
        animator.SetTrigger("Pop");
        PopupText.text = text;
        //optional audio can be added here
    }

}
