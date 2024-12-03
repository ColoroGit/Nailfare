using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailBehaviour : MonoBehaviour
{
    public float DMG = 1.0f;
    public GameObject gun;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (gun == other.gameObject || player == other.gameObject)
        {
            return;
        }

        BuildMatBehavior bmb = other.gameObject.GetComponentInParent<BuildMatBehavior>();

        if (bmb != null)
        {
            Debug.Log("Build mat hit");
            bmb.CheckIfAbleToFix();
        }

        // Detect Enemy and kill
        EnemyBehaviour eb = other.gameObject.GetComponent<EnemyBehaviour>();
        if (eb != null)
        {
            eb.CheckHP(DMG);
        }

        Destroy(gameObject);
    }
}
