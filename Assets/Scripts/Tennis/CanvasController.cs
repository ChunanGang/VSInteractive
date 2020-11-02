using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CanvasController : MonoBehaviour
{
    public GameObject storyUI;
    public GameObject optionUI;
    public Text storyText;
    private int state = 0;

    private int nextLine = 0;
    private List<string> startConversation = new List<string>();
    private List<string> gamePointConversation = new List<string>();

    // timeline
    public PlayableDirector startingTimeline;

    private void Start()
    {
        storyUI.SetActive(false);
        optionUI.SetActive(false);
        startConversation.Add("BOSS: \"Man let's beat them!\"");
        startConversation.Add("\"...\"" );
        startConversation.Add("\"OK I will try my best!\"");
        startConversation.Add("BOSS: \"You better don't disappoint me.\"");

        gamePointConversation.Add("BOSS: \"Ok it's game point now!\"");
        gamePointConversation.Add("BOSS: \"One more to go.\"");
        gamePointConversation.Add("BOSS: \"We can win this !\"");
        gamePointConversation.Add("\"Umm.. Should I use my super power to win this?\"");
        gamePointConversation.Add("BOSS: \"What were you mumbling ?\"");
        gamePointConversation.Add("\"Nothing. Let's get it.\"");
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            // starting conversation with boss
            case 1:
                storyText.text = startConversation[nextLine].ToString();
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                    nextLine += 1;
                if (nextLine > startConversation.Count - 1)
                {
                    nextLine = 0;
                    storyUI.SetActive(false);
                    startingTimeline.Play();
                    state += 1;
                }
                break;
            // playing tennis game 1
            case 2:
                break;
            // game point conversation
            case 3:
                storyText.text = gamePointConversation[nextLine].ToString();
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                    nextLine += 1;
                if (nextLine > gamePointConversation.Count - 1)
                {
                    nextLine = 0;
                    storyUI.SetActive(false);
                    startingTimeline.Play();
                    state += 1;
                }
                break;
            // playing tennis game 2
            case 4:
                break;
        }

    }

    public void triggerStartConversation()
    {
        startingTimeline.Pause();
        storyUI.SetActive(true);
        state = 1;
    }

    public void triggerGamePointConversation()
    {
        //print("--");
        startingTimeline.Pause();
        storyUI.SetActive(true);
        state = 3;
    }
}
