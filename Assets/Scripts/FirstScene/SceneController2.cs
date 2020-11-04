using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController2 : MonoBehaviour
{

    public GameObject storyUI;
    public GameObject optionUI;
    public Text storyText;
    private int nextLine = 0;
    private int nextLine2 = 0;
    private int nextLine3 = 0;
    private int madeDecision = 0;

    private List<string> story = new List<string>();
    private List<string> story2 = new List<string>();
    private List<string> story3 = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        story.Add("This is a long line...");
        story.Add("This \"Visual Story\" book must be really good.");
        story.Add("I can't afford to wait in this line.");
        story.Add("Hm, I think I can control their minds to make them walk away.");
        story.Add("But that might be a dangerous move.");
        story.Add("What to do...");
        // Debug.Log(story.Count);
        story2.Add("I am so late for work...");
        story2.Add("My boss is gonna be pretty mad.");
        story2.Add("But hey, at least I've got this book to make it up to him.");
        story2.Add("Better head there now.");

        story3.Add("Just as planned.");
        story3.Add("Now, I should be able to get to work on time.");
        story3.Add("Hope no one saw that...");
    }

    // Update is called once per frame
    void Update()
    { 
        madeDecision = StoryBranch2.madeDecision;
        Debug.Log(nextLine);
        
            if (nextLine < story.Count)
            {
                storyText.text = story[nextLine].ToString();
                // Debug.Log(nextLine);
                if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
                {
                    nextLine += 1;
                }
            }
            else
            {
                if (madeDecision == 0)
                {
                    storyUI.SetActive(false);
                    optionUI.SetActive(true);
                }
                else
                {
                    storyUI.SetActive(true);
                    optionUI.SetActive(false);
                    if (madeDecision == 1)
                    {
                    storyText.text = story2[nextLine2].ToString();
                        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
                        {
                            nextLine2 += 1;
                        }
                        if (nextLine2 == story2.Count - 1)
                        {
                        // SceneManager.LoadScene(2);
                        SceneManager.LoadScene("Transition1TO2");
                        }
                }
                    if (madeDecision == 2)
                    {
                    storyText.text = story3[nextLine3].ToString();
                    if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
                    {
                        nextLine3 += 1;
                    }
                    if (nextLine3 == story3.Count - 1)
                    {
                        // SceneManager.LoadScene(2);
                        SceneManager.LoadScene("Transition1TO2");
                    }
                }

                }
                // Debug.Log(nextLine);
            
        }
    }
}
