using System.Collections;
using UnityEngine;

public class Stress : MonoBehaviour
{
    private readonly int MaxStress = 100;
    private float CurrentStress;
    private readonly int StartingStress = 0;
    private readonly int MinimumUIStress = 7; // Minimum stress required to show the StressBar UI

    [SerializeField] float StressIncreaseRate; // Rate at which stress increases while in bad area
    [SerializeField] float StressDecreaseRate; // Rate at which stress decreases when not in bad area

    private readonly float stressChangeThreshold = 5f; // Time threshold for considering stress unchanged (in seconds)
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
            stressBar.gameObject.SetActive(false);
            return; // Exit the method to avoid setting the UI active below
        }
            stressBar.gameObject.SetActive(true);

        if (Interaction.isInteracting)
        {
            // If interacting, stop the stress decrease coroutine
            if (stressDecreaseCoroutine != null)
            {
                StopCoroutine(stressDecreaseCoroutine);
                stressDecreaseCoroutine = null; // Reset the coroutine reference to null to allow it to be started again later
            }
            // Also stop the stress increase coroutine
            if (stressIncreaseCoroutine != null)
            {
                StopCoroutine(stressIncreaseCoroutine);
                stressIncreaseCoroutine = null;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BadArea"))
        {
            Debug.Log("Entered bad area");

            // Start the coroutine to increase stress while in the bad area
            stressIncreaseCoroutine = StartCoroutine(IncreaseStressOverTime());

            // Stop the coroutine to decrease stress while in the bad area if it's not null
            if (stressDecreaseCoroutine != null)
            {
                StopCoroutine(stressDecreaseCoroutine);
                stressDecreaseCoroutine = null;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("BadArea"))
        {
            if (stressIncreaseCoroutine != null)
            {
                Debug.Log("Exited bad area");

                // Stop the coroutine to increase stress when leaving the bad area
                StopCoroutine(stressIncreaseCoroutine);
                stressIncreaseCoroutine = null;
            }

            // Start the coroutine to decrease stress when leaving the bad area if it's not already running
            if (stressDecreaseCoroutine == null)
            {
                stressDecreaseCoroutine = StartCoroutine(DecreaseStressOverTime());
            }
        }
    }
    public void BadAreaExit()
    {
        if (stressIncreaseCoroutine != null)
        {
            Debug.Log("Exited/Destroyed bad area");

            // Stop the coroutine to increase stress when leaving the bad area
            StopCoroutine(stressIncreaseCoroutine);
            stressIncreaseCoroutine = null;
        }

        // Start the coroutine to decrease stress when leaving the bad area if it's not already running
        if (stressDecreaseCoroutine == null)
        {
            stressDecreaseCoroutine = StartCoroutine(DecreaseStressOverTime());
        }
    }

    IEnumerator IncreaseStressOverTime() // Using IEnumerator in stead of for loop to allow for WaitForSeconds
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            ReceiveStress(StressIncreaseRate);
            Debug.Log("Increasing stress");
        }
    }

    IEnumerator DecreaseStressOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            ReduceStress(StressDecreaseRate);
            Debug.Log("Decreasing stress");
        }
    }

    public void ReceiveStress(float stress)
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

    public void ReduceStress(float stress)
    {
        CurrentStress -= stress;
        if (CurrentStress < StartingStress)
        {
            CurrentStress = StartingStress;
            if (stressDecreaseCoroutine != null)
            {
                StopCoroutine(stressDecreaseCoroutine);
                stressDecreaseCoroutine = null;
            }
        }
        if (CurrentStress >= MinimumUIStress)
        {
            stressBar.SetStress(CurrentStress);
            timeSinceLastStressChange = Time.time; // Update the time since last stress change
        }
    }
}