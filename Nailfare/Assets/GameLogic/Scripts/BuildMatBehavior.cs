using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMatBehavior : MonoBehaviour
{
    public bool anchored = false;
    public bool inConstrBase = false;
    public ConstructionBase cb;

    public void CheckIfAbleToFix()
    {
        if (!anchored && inConstrBase)
        {
            Fix();
        }
    }

    void Fix()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        anchored = true;
        ConstructionBase cb = FindObjectOfType<ConstructionBase>();
        cb.amountOfBMats++;
        cb.CheckVictory();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ConstructionBase cb = collision.gameObject.GetComponent<ConstructionBase>();

        if (cb != null)
        {
            inConstrBase = true;   
        }

        BuildMatBehavior bmb = collision.gameObject.GetComponent<BuildMatBehavior>();

        if (bmb != null && bmb.anchored)
        {
            inConstrBase = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        ConstructionBase cb = collision.gameObject.GetComponent<ConstructionBase>();

        if (cb != null)
        {
            inConstrBase = false;
        }

        BuildMatBehavior bmb = collision.gameObject.GetComponent<BuildMatBehavior>();

        if (bmb != null && bmb.anchored)
        {
            inConstrBase = false;
        }
    }
}
