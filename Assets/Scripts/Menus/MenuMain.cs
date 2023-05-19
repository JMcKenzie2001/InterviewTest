using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMain : IMenu
{
    [SerializeField] private Button playButton;


    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
    }
    
    private void PlayGame()
    {
        NMenuManager.Manager.StartGame();
    }
}
