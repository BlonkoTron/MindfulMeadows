using System.Collections;
using UnityEngine;

public class Stress : MonoBehaviour
{
    public int MaxStress = 100;
    private int CurrentStress;
    public int StartingStress = 0;
    public int StressIncreaseRate = 1; // Rate at which stress increases per second while in bad area
    public int StressDecreaseRate = 1; // Rate at which stress decreases per second when not in bad area
    private int MinimumUIStress = 7; // Minimum stress required to show the StressBar UI
    
    public float stressChangeThreshold = 5f; // Time threshold for considering stress unchanged (in seconds)
    private float timeSinceLastStressChange = 0f;

    private Coroutine stressIncreaseCoroutine;
    private Coroutine stressDecreaseCoroutine;
    public StressBar stressBar;

    void Start()
    {
        CurrentStress = StartingStress;
        stressBar.SetStress(CurrentStress);
        stressBar.SetMaxStress(MaxStress);

        // Start the coroutine to decrease stress over time
        stressDecreaseCoroutine = StartCoroutine(DecreaseStressOverTime());
    }

    void Update()
    {
        if (Time.time - timeSinceLastStressChange > stressChangeThreshold)
        {
            // Hide the StressBar UI if the stress hasn't changed for a while
            stressBar.gameObject.SetActive(false);
        }
        else
        {
            stressBar.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BadArea"))
        {
            // Start the coroutine to increase stress while in the bad area
            stressIncreaseCoroutine = StartCoroutine(IncreaseStressOverTime());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BadArea"))
        {
            if (stressIncreaseCoroutine != null)
            {
                StopCoroutine(stressIncreaseCoroutine);
            }
        }
    }

    IEnumerator IncreaseStressOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            ReceiveStress(StressIncreaseRate);
        }
    }

    IEnumerator DecreaseStressOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            ReduceStress(StressDecreaseRate);
        }
    }

    void ReceiveStress(int stress)
    {
        CurrentStress += stress;
        if (CurrentStress > MaxStress)
        {
            CurrentStress = MaxStress;
        }
        if (CurrentStress >= MinimumUIStress)
        {
            stressBar.SetStress(CurrentStress);
            timeSinceLastStressChange = Time.time; // Update the time since last stress change
        }
    }

    void ReduceStress(int stress)
    {
        CurrentStress -= stress;
        if (CurrentStress < 0)
        {
            CurrentStress = 0;
        }
        if (CurrentStress >= MinimumUIStress)
        {
            stressBar.SetStress(CurrentStress);
            timeSinceLastStressChange = Time.time; // Update the time since last stress change
        }
    }
}
+