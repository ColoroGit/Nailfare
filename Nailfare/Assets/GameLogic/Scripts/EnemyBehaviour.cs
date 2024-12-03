using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] public float DMG = 1;
    [SerializeField] public float HP = 100;
    [SerializeField] public float speed = 1;

    [SerializeField] private Canvas canva;
    [SerializeField] private RectTransform healthBar;

    private void Start()
    {
        canva.worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = PlayerBehaviour.instance.transform.position + new Vector3(0, 1f, 0);
        Vector3 direction = targetPosition - transform.position;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public void CheckHP(float dmg)
    {
        HP -= dmg;

                            //El 4 es por dimensiones del display//
        healthBar.sizeDelta = new Vector2(HP * 4, healthBar.sizeDelta.y);

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
