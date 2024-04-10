using System.Collections;
using UnityEngine;

public class Stress : MonoBehaviour
{
    private int MaxStress = 100;
    private float CurrentStress;
    private int StartingStress = 0;
    public float StressIncreaseRate = 1; // Rate at which stress increases per second while in bad area
    public float StressDecreaseRate = 0.1f; // Rate at which stress decreases per second when not in bad area
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
        // Check if the time since last stress change exceeds the threshold
        if (Time.time - timeSinceLastStressChange > stressChangeThreshold)
        {
            // Check if the stress value hasn't changed
            if (Mathf.Abs(CurrentStress - stressBar.GetStress()) < StressDecreaseRate)
            {
                // Hide the StressBar UI if the stress hasn't changed for a while
                stressBar.gameObject.SetActive(false);
                return; // Exit the method to avoid setting the UI active below
            }
        }
        stressBar.gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BadArea"))
        {
            // Start the coroutine to increase stress while in the bad area
            stressIncreaseCoroutine = StartCoroutine(IncreaseStressOverTime());
            // Stop the coroutine to decrease stress while in the bad area
            StopCoroutine(stressDecreaseCoroutine);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BadArea"))
        {
            if (stressIncreaseCoroutine != null)
            {
                // Stop the coroutine to increase stress when leaving the bad area
                StopCoroutine(stressIncreaseCoroutine);
                // Start the coroutine to decrease stress when leaving the bad area
                StartCoroutine(DecreaseStressOverTime());
            }
        }
    }

    IEnumerator IncreaseStressOverTime()
    {
        while (true)
        {
            // Check if isInteracting bool is true
            if (Interaction.isInteracting)
                yield break;

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

    void ReceiveStress(float stress)
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

    void ReduceStress(float stress)
    {
        CurrentStress -= stress;
        if (CurrentStress < StartingStress)
        {
            CurrentStress = StartingStress;
        }
        if (CurrentStress >= MinimumUIStress)
        {
            stressBar.SetStress(CurrentStress);
            timeSinceLastStressChange = Time.time; // Update the time since last stress change
        }
    }
}