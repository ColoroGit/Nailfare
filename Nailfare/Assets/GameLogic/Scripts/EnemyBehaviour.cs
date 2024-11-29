using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] public float DMG = 1;
    [SerializeField] public float HP = 100;

    // Update is called once per frame
    void Update()
    {
        /*Follow Player*/
    }

    public void CheckHP(float dmg)
    {
        HP -= dmg;

        /*Actualize HP display*/

        if (HP <= 0)
        {
            OnDeath();
        }
    }

    void OnDeath()
    {
        Destroy(gameObject);
    }
}
