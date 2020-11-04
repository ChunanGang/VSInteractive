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
        story1.Add("Man, I forgot to set my alarm last night.");
        story1.Add("I'm going to be late for work!");
        story1.Add("My boss is going to kill me...");
        story1.Add("I've really been slacking lately.");
        story1.Add("I need to get there on time to impress him.");
        story1.Add("I wonder if I could use my super speed...");
        story1.Add("--==Instructions==--");
        story1.Add("Look in the top left. That left bar is your productivity.");
        story1.Add("The higher it is, the better a job you're doing. Try to keep it high.");
        story1.Add("The left bar is your suspicion.");
        story1.Add("The higher it is, the more aware people are of your powers. Try to keep it low.");
        story1.Add("");
        story1.Add("");
        story1.Add("");
        story1.Add("You know, I should really stop and buy my boss a gift to make up for slacking off.");
        story1.Add("Gotta be quick...");

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
