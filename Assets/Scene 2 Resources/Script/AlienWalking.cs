using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienWalking : MonoBehaviour
{

    public float moveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Animator>().GetBool("startWalking") == true)
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
    }
}
