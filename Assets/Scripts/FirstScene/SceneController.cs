﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    public GameObject storyUI;
    public GameObject optionUI;
    public Text storyText;

    private int nextLine = 0;
    private List<string> story = new List<string>();


    private void Start()
    {
        story.Add("Man I forgot to set up an alarm last night");
        story.Add("Now I am going to be late for work");
        story.Add("Boss gonna be mad");
        story.Add("plus boss is not happy with my work long time ago");
        story.Add("I really need to get to work on time");
        story.Add("which road should I pick");
        story.Add("Instructions:");
        story.Add("'Left bar is your production bar'");
        story.Add("'You want it to be higher so boss wont fire you'");
        story.Add("'Right bar is your suspicion bar'");
        story.Add("'You want to keep it low so others wont find your super power'");

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (nextLine == 11)
            {
                storyUI.SetActive(false);
                optionUI.SetActive(true);
            }
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                storyText.text = story[nextLine].ToString();
                nextLine += 1;
            }
        }
        catch 
        {
        }

    }
}
