using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class AK : MonoBehaviour
{
    // Start is called before the first frame update
    Transform camTransform;

    public float fireRate = 0.1f;
    public int damage = 20;

    public float currentMag =30;
    public float maxMag = 30;
    public bool doReload = false;
    public float reloadTime = 1;
    public TextMeshProUGUI magText;

    float lastTimefired = 0;

    public AudioClip shootSound;
    public GameObject muzzleFlash;
    public Transform muzzlePos;

    public PlayerAnimator pa;

    public GameObject bulletHole;
    void Start()
    {
        camTransform = Camera.main.transform;
        currentMag = maxMag;
    }

    // Update is called once per frame
    void Update()
    {
        magText.text = doReload == false ? $"{currentMag} | {maxMag}" : "Reloading...";
        if (Input.GetKey(KeyCode.Mouse0) && lastTimefired >= fireRate && currentMag > 0 && !doReload)
        {
            GetComponent<AudioSource>().PlayOneShot(shootSound);
            lastTimefired = 0;
            currentMag--;
            pa.DoShootAnim();
            GameObject par = Instantiate(muzzleFlash, muzzlePos);
            par.transform.localEulerAngles = new Vector3 (0f, 180, 0f);
            muzzleFlash.GetComponent<ParticleSystem>().Play();
            Destroy(par, 0.1f);
            RaycastHit hit;
            if (Physics.Raycast(camTransform.position,camTransform.forward,out hit, Mathf.Infinity))
            {
                if(hit.collider.GetComponent<Enemy>())
                {
                    hit.collider.GetComponent<Enemy>().TakeDamage(damage);
                }
                else if (hit.collider.GetComponent<SantaHealth>()) {
                    hit.collider.GetComponent<SantaHealth>().TakeDamage(damage);
                }
                else
                {
                    GameObject hole = Instantiate(bulletHole, hit.point, Quaternion.identity);
                    hole.transform.forward = hit.normal;
                    Vector3 offset = hit.normal * 0.01f;
                    hole.transform.position += offset;
                    Destroy(hole, 5);
                }
            }
        }
        if(!Input.GetKey(KeyCode.Mouse0) && currentMag <= 0)
        {
            doReload = true;
            StartCoroutine(DoReload());
        }
        else if(!Input.GetKey(KeyCode.Mouse0) && currentMag < maxMag && Input.GetKeyDown(KeyCode.R)){
            doReload = true;
            StartCoroutine(DoReload());
        }
        lastTimefired += Time.deltaTime;
    }

    IEnumerator DoReload()
    {
        yield return new WaitForSeconds(reloadTime);
        currentMag = maxMag;
        doReload = false;
    }
}
