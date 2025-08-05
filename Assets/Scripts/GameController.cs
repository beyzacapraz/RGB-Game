using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    FreeRoam, Dialog, Battle
}

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    GameState gameState;

    private void Start()
    {
        DialogManager.Instance.onShowDialog += () =>
        {
            gameState = GameState.Dialog;
        };
        DialogManager.Instance.onHideDialog += () =>
        {
            if(gameState == GameState.Dialog)
            gameState = GameState.FreeRoam;
        };
    }
    private void Update()
    {
        if(gameState == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if(gameState == GameState.Dialog)
        {
            DialogManager.Instance.HandleUpdate();
        }
        else if (gameState == GameState.Battle)
        {

        }
    }
}
