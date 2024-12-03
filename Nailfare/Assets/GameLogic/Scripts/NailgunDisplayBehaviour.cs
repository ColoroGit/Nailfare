using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailgunDisplayBehaviour : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;

    public void Deactivate()
    {
        canvas.gameObject.SetActive(false);
    }

    public void Activate()
    {
        canvas.gameObject.SetActive(true);
    }
}
