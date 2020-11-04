using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAndFly : MonoBehaviour
{

    public GameObject teleportEffect;
    public GameObject alienObject;
    public GameObject flyingShip;

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
        //teleportEffect.SetActive(true);
        StartCoroutine(DisappearAndFly());

    }


    IEnumerator DisappearAndFly()
    {
        alienObject.GetComponent<Animator>().SetBool("startWalking", false);
        yield return new WaitForSeconds(1.0f);
        teleportEffect.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        alienObject.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        teleportEffect.SetActive(false);
        yield return new WaitForSeconds(1.0f);

        for(int i=0; i<5; i++)
        {
            flyingShip.transform.localScale -= new Vector3(0,0,0.1f);
            yield return new WaitForSeconds(0.05f);
        }

        for (int i = 0; i < 5; i++)
        {
            flyingShip.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
            yield return new WaitForSeconds(0.05f);
        }

        flyingShip.SetActive(false);

    }
}
