using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailgunBehaviour : MonoBehaviour
{
    [SerializeField] GameObject nailPrefab /*= prefab nail*/;
    [SerializeField] float recoil = 1f;
    [SerializeField] float DMG = 1f;

    bool canShoot = true;

    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            StartCoroutine(Cooldown());

            if (nailPrefab != null)
            {
                GameObject nail = Instantiate(nailPrefab, gameObject.transform);
                nail.GetComponent<NailBehaviour>().DMG = DMG;
                nail.GetComponent<NailBehaviour>().gun = gameObject;
                nail.GetComponent<NailBehaviour>().player = PlayerBehaviour.instance.gameObject;
                nail.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 1000);
            }
            else
            {
                Debug.Log("Reference to nail prefab missing");
            }
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(recoil);
        canShoot = true;
    }
}
