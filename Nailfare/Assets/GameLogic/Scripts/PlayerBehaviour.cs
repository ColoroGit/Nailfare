using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] NailgunBehaviour nailgun;

    [SerializeField] float HP;

    public static PlayerBehaviour instance;
    void Start()
    {
        instance = this;

        //StartCoroutine(AutoShoot()); // Delete later
    }

    IEnumerator AutoShoot() // Delete later (just for testing)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.33f);
            nailgun.Shoot();
        }
    }

    private void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }

    private void Update()
    {
        OVRInput.Update();
        Shoot();
    }

    void Shoot()
    {
        bool pressed = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);

        if (pressed)
        {
            Debug.Log("Shoot");
            nailgun.Shoot();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyBehaviour eb = collision.gameObject.GetComponent<EnemyBehaviour>();

        if (eb != null)
        {
            CheckHP(eb);
        }
    }

    void CheckHP(EnemyBehaviour eb)
    {
        HP -= eb.DMG;

        /*Actualize HP display*/

        if (HP <= 0)
        {
            OnDeath();
        }
        else
        {
            
            Vector3 push = eb.gameObject.transform.forward;
            push.y = 1.5f;
            push *= 1000;
            //gameObject.GetComponent<Rigidbody>().velocity = push;
            gameObject.GetComponent<Rigidbody>().AddForce(push);
        }
    }

    void OnDeath()
    {
        /*Show message, stop movement, restart after some time*/
    }
}
