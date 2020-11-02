using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    public Animator anim;
    public GameObject storyUI;
    public GameObject optionUI;
    public Text storyText;
    private bool secondScene;

    private int nextLine = 0;
    private bool hasPlayed;
    private List<string> story1 = new List<string>();
    private List<string> story2 = new List<string>();



    private void Start()
    {
        story1.Add("Man I forgot to set up an alarm last night");
        story1.Add("Now I am going to be late for work");
        story1.Add("Boss gonna be mad");
        story1.Add("plus boss is not happy with my work long time ago");
        story1.Add("I really need to get to work on time");
        story1.Add("which road should I pick");
        story1.Add("Instructions:");
        story1.Add("'Left bar is your production bar'");
        story1.Add("'You want it to be higher so boss wont fire you'");
        story1.Add("'Right bar is your suspicion bar'");
        story1.Add("'You want to keep it low so others wont find your super power'");
        story1.Add("");
        story1.Add("");
        story1.Add("");
        story1.Add("Oh shoot nearly forget to buy the gift boss asked yesterday. Need to buy it now.");
        story1.Add("I am running out of time... ");

    }

    // Update is called once per frame
    void Update()
    {
        secondScene = ToShopping.secondScene;
        try
        {
            if (secondScene && !hasPlayed)
            {                
                storyUI.SetActive(true);
                optionUI.SetActive(false);
                //storyText.text = "Oh shoot nearly forget to buy the gift boss asked yesterday";
                nextLine = 14;
                Debug.Log("Play");
                // PlayAnimation();
                // anim.enabled = false;
                hasPlayed = true;
            }
            if (nextLine == 12)
            {
                storyUI.SetActive(false);
                optionUI.SetActive(true);
                // nextLine = 0;
            }
            if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
            {
                Debug.Log(nextLine);
                nextLine += 1;
            }
            storyText.text = story1[nextLine].ToString();
        }
        catch 
        {
        }
    }

    void PlayAnimation()
    {
        anim.enabled = true;
        anim.Play("WalkToShop");
    }
}
