using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMenu : MonoBehaviour
{
    public GameObject panel;


    public virtual void Show()
    {
        panel.SetActive(true);
    }

    public virtual void Hide()
    {
        panel.SetActive(false);
    }
}
