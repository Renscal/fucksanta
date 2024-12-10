using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Transform HeadTF;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yRotation = HeadTF.localEulerAngles.y;

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, yRotation, transform.localEulerAngles.z);

        

        if (Input.GetKeyDown(KeyCode.P))
        {
            print(HeadTF.rotation.y);

            

        }
    }
}
