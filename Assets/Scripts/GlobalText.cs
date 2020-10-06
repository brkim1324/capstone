using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalText : MonoBehaviour
{
    public Text text;
    public Text text2;
    public float countTime;
    public float delay;
    
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Hey Child!";
    }

    // Update is called once per frame
    void Update()
    {
        Level_1();
    }

    void Level_1()
    {
        if (Time.time > countTime)
        {
            countTime = Time.time + delay;
        }
        text.text = "It's already time for you to go to your very first school!";
        text.text = "Before we let you go, we want to teach you things!";
        text.text = "Left-Click to Move!";
        text.text = "Right-Click to interact with others!";
        text.text = "Try it now with other NPC now!";
    }
}
