using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSnow : MonoBehaviour
{
    private bool walking;
    private bool playing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal")!=0 || (Input.GetAxis("Vertical") != 0))
        {
            walking = true;
        }
        else 
        { 
            walking = false;
            GetComponent<AudioSource>().Stop(); 
            playing = false;
        }

        if (walking)
        {
            if (!playing)
            {
                playing = true;
                GetComponent<AudioSource>().Play();
            }
        }



    }
}
