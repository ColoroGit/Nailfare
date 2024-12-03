using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    [SerializeField]
    public TextMeshProUGUI messages;
    
    [SerializeField]
    public TextMeshProUGUI objectives;

    [SerializeField]
    private GameObject shadow;

    [SerializeField]
    private RectTransform healthBar;

    private void Start()
    {
        instance = this;
    }

    public void SetText(string text)
    {
        messages.text = text;
        shadow.SetActive(true);
        StartCoroutine(Timer(4));
    }

    public void UpdateHealthBar(float health)
    {                             //El 4 es por dimensiones del display//
        healthBar.sizeDelta = new Vector2(health * 4, healthBar.sizeDelta.y);
    }

    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        messages.text = "";
        shadow.SetActive(false);
    }
    public void UpdateRemainingPieces(int remainingPieces)
    {
        objectives.text = "Piezas Restantes: " + remainingPieces.ToString();
    }
}
