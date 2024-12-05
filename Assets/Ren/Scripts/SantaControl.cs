using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SantaControl : MonoBehaviour
{
    public float timeInactive = 4;
    public float timeActive = 4;
    private SantaLaser laser;
    private LineRenderer left;
    private LineRenderer right;
    public AudioClip laserlyd;

    // Start is called before the first frame update
    void Start()
    {
        left = GameObject.Find("EyeL").GetComponent<LineRenderer>();

        right = GameObject.Find("EyeR").GetComponent <LineRenderer>();

        laser = GameObject.Find("Santa").GetComponent<SantaLaser>();

        laser.enabled = false;

        StartCoroutine(LaserStyring());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LaserStyring()
    {
        yield return new WaitForSeconds(timeInactive);

        laser.enabled = true;

        GetComponent<AudioSource>().PlayOneShot(laserlyd);


        left.enabled = true; right.enabled = true; 
       

        yield return new WaitForSeconds(timeActive);

        laser.enabled = false;

        left.enabled = false; right.enabled = false;

        StartCoroutine(LaserStyring());
    }
}
