using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuHUD : IMenu
{
    [SerializeField] private Button pauseButton;

    [SerializeField] private TextMeshProUGUI pizzasCollectedText;
    [SerializeField] private TextMeshProUGUI starsCollectedText;


    private void Start()
    {
        pauseButton.onClick.AddListener(PauseOnClick);
    }

    public override void Show()
    {
        base.Show();
        GameData.isPaused = false;
    }

    private void PauseOnClick()
    {
        GameData.isPaused = true;
        NMenuManager.Manager.ShowPauseMenu();
    }
}
