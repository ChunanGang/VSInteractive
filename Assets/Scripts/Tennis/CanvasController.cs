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
    private List<string> firstDecision = new List<string>();
    private List<string> decision1_1Conversation = new List<string>();
    private List<string> decision1_2Conversation = new List<string>();
    // timeline
    public PlayableDirector startingTimeline;
    public PlayableDirector decision1_2;

    private void Start()
    {
        storyUI.SetActive(false);
        //optionUI.SetActive(false);
        startConversation.Add("BOSS: \"Man let's beat them!\"");
        startConversation.Add("\"...\"" );
        startConversation.Add("\"OK I will try my best!\"");
        startConversation.Add("BOSS: \"You better don't disappoint me.\"");

        gamePointConversation.Add("BOSS: \"Ok it's game point now!\"");
        gamePointConversation.Add("BOSS: \"One more to go.\"");
        gamePointConversation.Add("BOSS: \"We can win this !\"");
        gamePointConversation.Add("\"Umm.. Should I use my power to win this?\"");
        gamePointConversation.Add("BOSS: \"What were you mumbling ?\"");
        gamePointConversation.Add("\"Nothing. Let's get it.\"");

        firstDecision.Add("\"If I use my power here,\"");
        firstDecision.Add("\"I can change the ball's direction\"");
        firstDecision.Add("\"and win this game.\"");
        firstDecision.Add("\"Boss will like me,\"");
        firstDecision.Add("\"even give me promotion!\"");
        firstDecision.Add("\"But someone may notice I did something.\"");
        firstDecision.Add("\"Should I use my power?\"");

        decision1_1Conversation.Add("BOSS: \"OMG!\"");
        decision1_1Conversation.Add("BOSS: \"Can't believe we lost this.\"");
        decision1_1Conversation.Add("BOSS: \"You really disappoint me.\"");
        decision1_1Conversation.Add("\"...\"");
        decision1_1Conversation.Add("\"Sorry Boss\"");

        decision1_2Conversation.Add("BOSS: \"OMG!\"");
        decision1_2Conversation.Add("BOSS: \"That was a unbelievable serve.\"");
        decision1_2Conversation.Add("BOSS: \"You won us the game.\"");
        decision1_2Conversation.Add("\"Thanks.\"");
        decision1_2Conversation.Add("\"May just be luck\"");
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
            // first decision
            case 5:
                storyText.text = firstDecision[nextLine].ToString();
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                    nextLine += 1;
                if (nextLine > firstDecision.Count - 1)
                {
                    nextLine = 0;
                    storyUI.SetActive(false);
                    optionUI.SetActive(true);
                }
                break;
            // decision timeline
            case 6:
                break;
            // decision one
            case 7:
                storyText.text = decision1_1Conversation[nextLine].ToString();
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                    nextLine += 1;
                if (nextLine > decision1_1Conversation.Count - 1)
                {
                    nextLine = 0;
                    storyUI.SetActive(false);

                }
                break;
            // decision two
            case 8:
                storyText.text = decision1_2Conversation[nextLine].ToString();
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                    nextLine += 1;
                if (nextLine > decision1_2Conversation.Count - 1)
                {
                    nextLine = 0;
                    storyUI.SetActive(false);

                }
                break;
        }

    }

    public void chooseOptionOne()
    {
        print("1111");
        // first choice
        if(state == 5) {
            state += 1;
            optionUI.SetActive(false);
            startingTimeline.Play();
        }
    }
    public void chooseOptionTwo()
    {
        print("2222");
        // first choice
        if (state == 5)
        {
            decision1_2.Play();
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

    public void triggerFirstDecision()
    {
        startingTimeline.Pause();
        storyUI.SetActive(true);
        state = 5;
    }

    public void pauseAndIncrState()
    {
        startingTimeline.Pause();
        storyUI.SetActive(true);
        state +=1;
    }
}
