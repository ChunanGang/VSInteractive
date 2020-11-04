using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public Text text1;
    public Text text2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunIntro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RunIntro() 
    {
        yield return new WaitForSeconds(3);

        for (float i = 0.02f; i <= 1.0f; i += 0.02f) 
        {
            text1.color = new Color(text1.color.r, text1.color.g, text1.color.b, i);
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(3);

        for (float i = 0.02f; i <= 1.0f; i += 0.02f)
        {
            text2.color = new Color(text2.color.r, text2.color.g, text2.color.b, i);
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("CityStreet");

    }
}
