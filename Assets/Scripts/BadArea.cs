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
    [SerializeField] AnimationCurve lineCurve;



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
        int lineIndex = 0;
        int lineSegments = 20;
        float maxVerticalOffset = 20;
        Vector3 startPos = transform.position;
        Vector3 endPos = unlockableObj.transform.position;
        //Vector3 midPos = Vector3.Lerp(startPos, endPos, 0.5f);
        //Vector3[] linePositions = { startPos, new Vector3(midPos.x,midPos.y+20,midPos.z), endPos };
        //myline.SetPositions(linePositions);
        myline.positionCount=lineSegments;
        myline.SetPosition(lineIndex,startPos);
        for (int i=0; i<lineSegments-1;i++)
        {
            lineIndex++;
            float ratio = (float)lineIndex / (float)lineSegments;
            Vector3 newPos = Vector3.Lerp(startPos, endPos, ratio);
            float verticalOffset = lineCurve.Evaluate(ratio) * maxVerticalOffset;
            myline.SetPosition(lineIndex, new Vector3(newPos.x,newPos.y+verticalOffset,newPos.z));
        }
        myline.SetPosition(lineIndex, endPos);

    }
}
