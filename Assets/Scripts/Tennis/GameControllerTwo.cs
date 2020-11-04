using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class GameControllerTwo : MonoBehaviour
{
    public GameObject storyUI;
    public GameObject optionUI;

    public Text storyText;
    public Slider suspicionSlider;
    public Slider productionSlider;
    private ChangeBar _changeBar;
    private int state = 0;
    private int nextLine = 0;
    private List<string> startConversation = new List<string>();
    private List<string> decision2_1Conversation = new List<string>();
    private List<string> decision2_2Conversation = new List<string>();

    public PlayableDirector startingTimeline;
    public PlayableDirector decision2_2;
    public PlayableDirector ending;

    // Start is called before the first frame update
    void Start()
    {
        _changeBar = FindObjectOfType<ChangeBar>();
        productionSlider.value = _changeBar.productionVal / 100;
        suspicionSlider.value = _changeBar.suspicionVal / 100;
        storyUI.SetActive(false);
        //optionUI.SetActive(false);
        startConversation.Add("\"Oh no!\"");
        startConversation.Add("\"That's my bottle on the floor.\"");
        startConversation.Add("\"Boss is gonna trip and get mad.\"");
        startConversation.Add("\"Should I use my super speed?\"");
        startConversation.Add("\"So that I can go catch him.\"");

        decision2_1Conversation.Add("BOSS: \"!!!\"");
        decision2_1Conversation.Add("BOSS: \"Who left his damn bottle ?!\"");
        decision2_1Conversation.Add("\"...\"");
        decision2_1Conversation.Add("\"Sorry Boss that's mine.\"");
        decision2_1Conversation.Add("BOSS: \"OMG\"");
        decision2_1Conversation.Add("BOSS: \"What is wrong with you!\"");

        decision2_2Conversation.Add("\"Careful!\"");
        decision2_2Conversation.Add("\"Sorry I left my bottle on the floor.\"");
        decision2_2Conversation.Add("BOSS: \"Oh.\"");
        decision2_2Conversation.Add("BOSS: \"Thank you!\"");
        decision2_2Conversation.Add("BOSS: \"You saved me haha.\"");
        decision2_2Conversation.Add("BOSS: \"But how did you come so fast?\"");
        decision2_2Conversation.Add("\"um...\"");
        decision2_2Conversation.Add("\"It must be you illusion..\"");
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            // starting conversation 
            case 1:
                storyText.text = startConversation[nextLine].ToString();
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                    nextLine += 1;
                if (nextLine > startConversation.Count - 1)
                {
                    nextLine = 0;
                    storyUI.SetActive(false);
                    optionUI.SetActive(true);
                }
                break;
            // playing timeline
            case 2:
                break;
            // decision one
            case 3:
                storyText.text = decision2_1Conversation[nextLine].ToString();
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                    nextLine += 1;
                if (nextLine > decision2_1Conversation.Count - 1)
                {
                    nextLine = 0;
                    storyUI.SetActive(false);
                    ending.Play();
                }
                break;
            // decision two
            case 4:
                storyText.text = decision2_2Conversation[nextLine].ToString();
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                    nextLine += 1;
                if (nextLine > decision2_2Conversation.Count - 1)
                {
                    nextLine = 0;
                    storyUI.SetActive(false);
                    ending.Play();
                }
                break;
        }
    }

    public void chooseOptionOne()
    {
        print("1111");
        // first choice
        if (state == 1)
        {
            state += 1;
            optionUI.SetActive(false);
            startingTimeline.Play();
            _changeBar.productionVal += 10;
            productionSlider.value = _changeBar.productionVal / 100;
        }
    }
    public void chooseOptionTwo()
    {
        print("2222");
        // first choice
        if (state == 1)
        {
            state += 1;
            startingTimeline.Stop();
            decision2_2.Play();
            optionUI.SetActive(false);
            _changeBar.productionVal += 20;
            _changeBar.suspicionVal += 20;
            productionSlider.value = _changeBar.productionVal / 100;
            suspicionSlider.value = _changeBar.suspicionVal / 100;
        }
    }

    public void pauseAndIncrState()
    {
        startingTimeline.Pause();
        storyUI.SetActive(true);
        state += 1;
    }

    public void triggerDecision2_2()
    {
        state += 2;
        decision2_2.Pause();
        storyUI.SetActive(true);
    }

    public void end()
    {
        print("end---");
    }
}
