using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailBehaviour : MonoBehaviour
{
    public float DMG = 1.0f;
    public GameObject gun;
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if (gun == collision.gameObject || player == collision.gameObject)
        {
            return;
        }

        BuildMatBehavior bmb = collision.gameObject.GetComponent<BuildMatBehavior>();

        if (bmb != null)
        {
            bmb.CheckIfAbleToFix();
        }

        // Detect Enemy and kill

        Destroy(gameObject);
    }
}
