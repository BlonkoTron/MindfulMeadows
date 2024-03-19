using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedCounter : MonoBehaviour
{
    private TMP_Text myCounter;
    // Start is called before the first frame update
    void Start()
    {
        myCounter = GetComponentInChildren<TMP_Text>();
        UpdateText();
    }
    public void UpdateText()
    {
        myCounter.text = Inventory.seeds.ToString();
    }
}
