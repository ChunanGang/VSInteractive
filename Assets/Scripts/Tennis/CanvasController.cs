using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public GameObject storyUI;
    public GameObject optionUI;
    public Text storyText;
    public Slider suspicionSlider;
    public Slider productionSlider;
    private int state = 0;
    private ChangeBar _changeBar;
    private int nextLine = 0;
    private List<string> startConversation = new List<string>();
    private List<string> gamePointConversation = new List<string>();
    private List<string> firstDecision = new List<string>();
    private List<string> decision1_1Conversation = new List<string>();
    private List<string> decision1_2Conversation = new List<string>();
    // timeline
    public PlayableDirector startingTimeline;
    public PlayableDirector decision1_2;
    public PlayableDirector endingTimeline;

    private void Start()
    {
        _changeBar = FindObjectOfType<ChangeBar>();
        productionSlider.value = _changeBar.productionVal / 100;
        suspicionSlider.value = _changeBar.suspicionVal / 100;
        storyUI.SetActive(false);
        //optionUI.SetActive(false);
        startConversation.Add("BOSS: Let's do this!");
        startConversation.Add("Alright!" );
        startConversation.Add("I'll try my best!");
        startConversation.Add("BOSS: Don't disappoint me!");

        gamePointConversation.Add("BOSS: Alright, match point!");
        gamePointConversation.Add("BOSS: Just one more to go.");
        gamePointConversation.Add("BOSS: We can win this!");
        gamePointConversation.Add("Should I use my powers to win this?");
        gamePointConversation.Add("BOSS: What are you mumbling?");
        gamePointConversation.Add("Oh, nothing. Let's get it.");

        firstDecision.Add("If I use my telekinesis here,");
        firstDecision.Add("I can change the ball's direction");
        firstDecision.Add("and win this game.");
        firstDecision.Add("My Boss will be so impressed,");
        firstDecision.Add("maybe he'll even give me a promotion!");
        firstDecision.Add("But the other team might notice something's wrong...");
        firstDecision.Add("Should I use my power?");

        decision1_1Conversation.Add("BOSS: Ugh!!");
        decision1_1Conversation.Add("BOSS: I can't believe we lost this.");
        decision1_1Conversation.Add("BOSS: You really blew it.");
        decision1_1Conversation.Add("...");
        decision1_1Conversation.Add("Sorry, Boss");

        decision1_2Conversation.Add("BOSS: Wow!");
        decision1_2Conversation.Add("BOSS: That was an unbelievable serve.");
        decision1_2Conversation.Add("BOSS: You won us the game!");
        decision1_2Conversation.Add("Thanks!");
        decision1_2Conversation.Add("Maybe I just got lucky?");
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

                    endingTimeline.Play();
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
                    endingTimeline.Play();
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
            _changeBar.productionVal += 15;
            productionSlider.value = _changeBar.productionVal / 100;
        }
    }
    public void chooseOptionTwo()
    {
        print("2222");
        // first choice
        if (state == 5)
        {
            state += 1;
            startingTimeline.Stop();
            decision1_2.Play();
            optionUI.SetActive(false);
            _changeBar.productionVal += 25;
            _changeBar.suspicionVal += 30;
            productionSlider.value = _changeBar.productionVal / 100;
            suspicionSlider.value = _changeBar.suspicionVal / 100;

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

    public void triggerDecision1_2Ending()
    {
        decision1_2.Pause();
        storyUI.SetActive(true);
        state = 8;
    }

    public void moveToNextScene()
    {
        SceneManager.LoadScene("TennisCourt2");
    }
}
