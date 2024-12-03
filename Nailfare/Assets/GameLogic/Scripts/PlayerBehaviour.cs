using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour instance;

    [SerializeField] float HP;

    [SerializeField] GameObject locomotionSystem;

    private bool dead = false;

    void Start()
    {
        instance = this;

        HUDManager.instance.SetText("Sobrevive a la horda de demonios rojos y completa tu construcción");
        HUDManager.instance.UpdateHealthBar(HP);
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

        HUDManager.instance.UpdateHealthBar(HP);

        if (HP <= 0 && !dead)
        {
            dead = true;
            OnDeath();
        }
    }

    void OnDeath()
    {
        HUDManager.instance.SetText("Has muerto");
        locomotionSystem.SetActive(false);
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
