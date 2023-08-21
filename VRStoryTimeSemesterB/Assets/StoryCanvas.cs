using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryCanvas : MonoBehaviour
{
    public static StoryCanvas Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }
    public TMP_Text StoryText;
    List<string> lines= new List<string>();
    private string ch1_1 = "In Harmonyville, music filled the air and brought joy to everyone's hearts. Melody, with her gift for playing the flute, embarked on a musical journey to inspire others";
    private string ch1_2 = "Suddenly, she stumbled upon a lost parrot named Echo, whose mimicry caused quite a commotion.";

    // Start is called before the first frame update
    void Start()
    {
        lines.Add(ch1_1);
        lines.Add(ch1_2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeText(int textId)
    {
        StoryText.text = lines[textId];
    }
}
