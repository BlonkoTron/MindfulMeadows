using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // ref video: https://www.youtube.com/watch?v=_LRZcmX_xw0 

    private Camera cam;

    public bool useStaticBillboard;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!useStaticBillboard)
        {
            transform.LookAt(cam.transform);
        } else
        {
            transform.rotation = cam.transform.rotation;
        }
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
