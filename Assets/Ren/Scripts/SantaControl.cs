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
    public GameObject target;

    public Transform player;

    [Header("Hat attack stuff (very scuffed)")]
    public GameObject hat;
    private Vector3 localHatPos;
    private Vector3 localHatRot;
    public float hatUpTime = 1;
    public float hatTrackTime = 5;
    public float hatSlamDunkTime = 0.15f;
    public float hatSpeed = 10;


    // Start is called before the first frame update
    void Start()
    {
        localHatPos = hat.transform.localPosition;
        localHatRot = hat.transform.localEulerAngles;
        left = GameObject.Find("EyeL").GetComponent<LineRenderer>();

        right = GameObject.Find("EyeR").GetComponent <LineRenderer>();

        laser = GameObject.Find("Santa").GetComponent<SantaLaser>();

        laser.enabled = false;

        target.SetActive(false);

        StartCoroutine(LaserStyring());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(HatAttack());
        }
    }

    IEnumerator HatAttack()
    {
        Transform hatParent = hat.transform.parent;
        hat.transform.parent = null;
        // Hat up
        {
            float timeElapsed = 0;
            Vector3 origin = hat.transform.position;
            Vector3 target = new Vector3(player.position.x,origin.y + 15, player.position.z);

            while(timeElapsed <= hatUpTime)
            {
                hat.transform.position = Vector3.Lerp(origin, target, timeElapsed/hatUpTime);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            hat.transform.position = target;
        }
        // Hat track
        {
            float timeElapsed = 0;

            while (timeElapsed <= hatTrackTime)
            {
                Vector3 playerTarget = new Vector3(player.position.x, hat.transform.position.y, player.position.z);
                hat.transform.position = Vector3.MoveTowards(hat.transform.position, playerTarget, hatSpeed * Time.deltaTime);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
        // Hat slam dunk
        {
            float timeElapsed = 0;
            Vector3 origin = hat.transform.position;
            Vector3 target = player.position;
            while (timeElapsed <= hatSlamDunkTime)
            {
                hat.transform.position = Vector3.Lerp(origin, target, timeElapsed / hatSlamDunkTime);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            hat.transform.position = target;

            // Here goes attack stuff

        }
        // Hat Go back to head
        {
            hat.transform.parent = hatParent;
            hat.transform.localEulerAngles = localHatRot;
            float timeElapsed = 0;
            Vector3 origin = hat.transform.localPosition;
            while (timeElapsed <= hatUpTime)
            {
                hat.transform.localPosition = Vector3.Lerp(origin, localHatPos, timeElapsed / hatUpTime);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            hat.transform.localPosition = localHatPos;
        }
    }

    IEnumerator LaserStyring()
    {
        yield return new WaitForSeconds(timeInactive);

        laser.enabled = true;

        GetComponent<AudioSource>().PlayOneShot(laserlyd);

        left.enabled = true; right.enabled = true;
        target.SetActive(true);

        yield return new WaitForSeconds(timeActive);

        laser.enabled = false;


        left.enabled = false; right.enabled = false;
        if(FindAnyObjectByType<SantaHealth>().isDead == false)
        {
            target.SetActive(false);
            StartCoroutine(LaserStyring());
        }
    }
}
