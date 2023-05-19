using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

    }
    
    private void Update()
    {
        
    }
}
