using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAnimator : MonoBehaviour
{
    private Material mat;
    private Vector2 offsetValue;
    [SerializeField] Vector2 offsetMovement;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offsetValue += offsetMovement;
        mat.mainTextureOffset = offsetValue;
    }
}
