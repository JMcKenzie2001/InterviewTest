using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMenuManager : MonoBehaviour
{
    public static NMenuManager Manager { get; private set; }

    public Stack<IMenu> MenuStack { get; private set; } = new Stack<IMenu>();

    public GameController gameController;

    public MenuMain menuMain;

    public MenuPause menuPause;

    public MenuHUD menuHUD;

    public MenuLevelComplete menuLevelComplete;


    private void Awake()
    {
        Manager = this;
    }
    
    private void Start()
    {
        ClearToMainMenu();
    }
    
    public void StartGame()
    {
        gameController.RestartGame();
        ShowHUD();
    }

    public void ClearToMainMenu()
    {
        if (MenuStack.Count > 0)
        {
            MenuStack.Peek().Hide();
        }

        MenuStack.Clear();
        PushMenu(menuMain);
        gameController.RestartGame();
    }

    public void ShowHUD()
    {
        PushMenu(menuHUD);
    }

    public void ShowPauseMenu()
    {
        PushMenu(menuPause);
    }

    public void ShowLevelCompleteMenu()
    {
        PushMenu(menuLevelComplete);
    }

    #region MENU_FUNCTIONALITY
    private void PushMenu(IMenu _menuToPush)
    {
        if (MenuStack.Count > 0)
        {
            MenuStack.Peek().Hide();
        }

        MenuStack.Push(_menuToPush);
        _menuToPush.Show();
    }

    public void PopMenu()
    {
        if (MenuStack.Count > 0)
        {
            MenuStack.Pop().Hide();
        }

        if (MenuStack.Count > 0)
        {
            MenuStack.Peek().Show();
        }
        else
        {
            PushMenu(menuMain);
        }
    }
    #endregion
}
