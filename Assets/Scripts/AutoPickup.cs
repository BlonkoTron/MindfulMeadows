using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPickup : MonoBehaviour
{
    [Range(0.1f, 5)]
    [SerializeField] private float pickupRange;
    [Range(1, 10)]
    [SerializeField] private float pickupSpeed;
    private float pickupCollisionRange = 0.1f;
    private Transform player;
    private SeedCounter seedCounter;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        seedCounter = GameObject.FindGameObjectWithTag("seedCounter").GetComponent<SeedCounter>();
    }
    private void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);

        if (dist<=pickupRange)
        {
            var step = pickupSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
            if (dist<pickupCollisionRange)
            {
                Inventory.seeds++;
                seedCounter.UpdateText();
                Destroy(this.gameObject);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        // Draw a sphere at the transform's position
        Gizmos.color = new Color32(0,255,0,100);
        Gizmos.DrawSphere(transform.position, pickupRange);
    }
}
