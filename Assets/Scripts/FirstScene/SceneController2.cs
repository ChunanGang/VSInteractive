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
        story.Add("This is a long line");
        story.Add("I cannot imagine this 'Visual Story' book is so popular");
        story.Add("I am 100% late for work if I wait in line");
        story.Add("I can certainly mind control these folks to walk away");
        story.Add("But that's a dangerous move");
        story.Add("what should I do?");
        // Debug.Log(story.Count);
        story2.Add("I am so late for work");
        story2.Add("Boss would be so mad");
        story2.Add("But hey at least I kept my bottom line");
        story2.Add("better go back now");

        story3.Add("Oh this is convenient");
        story3.Add("This way I should be able to make to work on time");
        story3.Add("Hope nobody saw me do this to them");
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
                    }
                }

                }
                // Debug.Log(nextLine);
            
        }
    }
}
