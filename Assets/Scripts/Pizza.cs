using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    public void Create()
    {
        gameObject.SetActive(true);
    }

    public void Collect()
    {
        gameObject.SetActive(false);
        GameData.pizzasCollected++;
    }
}
