using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadArea : MonoBehaviour
{
    [HideInInspector] public int treesPlantedHere = 0;
    public int treesToClear;
    [SerializeField] private GameObject unlockableObj;
    [SerializeField] private GameObject deathParticle;
    private Unlockable myUnlockableScript;
    private ParticleSystem myParticle;
    private LineRenderer myline;

    private void Start()
    {
        myParticle = GetComponentInChildren<ParticleSystem>();
        myline = GetComponent<LineRenderer>();
        float scale = GetComponent<Transform>().localScale.x;
        var shape = myParticle.shape;
        shape.radius = scale/2;
        if (unlockableObj != null)
        {
            myUnlockableScript = unlockableObj.GetComponent<Unlockable>();
            myUnlockableScript.connectedObjects++;
            SetLineRenderer();
        }
    }

    private void Update()
    {
        if(treesPlantedHere==treesToClear)
        {
            ClearArea();
        }
    }

    public void ClearArea()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (myUnlockableScript!=null)
        {
            myUnlockableScript.ChangeState();
        }
    }
    public void SetLineRenderer()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = unlockableObj.transform.position;
        Vector3[] linePositions = { startPos, endPos };
        myline.SetPositions(linePositions);
    }
}
