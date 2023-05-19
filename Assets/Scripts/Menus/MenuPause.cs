using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPause : IMenu
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button homeButton;

    
    private void Start()
    {
        resumeButton.onClick.AddListener(ResumeOnClick);
        homeButton.onClick.AddListener(HomeOnClick);
    }

    private void ResumeOnClick()
    {
        NMenuManager.Manager.PopMenu();
    }

    private void HomeOnClick()
    {
        NMenuManager.Manager.ClearToMainMenu();
    }
}
