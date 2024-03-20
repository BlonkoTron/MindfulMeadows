using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField] Sprite sprGood, sprBad;
    private SpriteRenderer sprRender;

    private void Start()
    {
        sprRender = GetComponent<SpriteRenderer>();
    }
}
