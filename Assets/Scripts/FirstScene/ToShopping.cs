using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToShopping : MonoBehaviour
{

    public static bool secondScene = false;
    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            secondScene = true;
            StartCoroutine(LoadNextScene());
            
        }
    }

    public IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(3f);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("ShoppingScene");
    }
}
