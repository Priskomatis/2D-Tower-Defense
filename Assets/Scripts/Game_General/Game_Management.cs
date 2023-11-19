using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Game_Management : MonoBehaviour
{
    public static event Action<GameState> OnGameStateChanged;

    private Lives_Manager lives_manager;
    private Currency_Manager currency_manager;
    public int health;
    public int money;

    public GameState currentState;
    
    public enum GameState {  Play, Paused, GameOver }
    

    private void Start()
    {

        SetGameState(GameState.Play);

        lives_manager = FindObjectOfType<Lives_Manager>();
        currency_manager = FindObjectOfType<Currency_Manager>();

        InvokeRepeating("IncreaseMoney", 0, 1f);

        Debug.Log("Health: "+ health);
    }
    private void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            TogglePause();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleRestart();
        }
    }

    void TogglePause()
    {
        if (currentState == GameState.Play)
            SetGameState(GameState.Paused);
        else if (currentState == GameState.Paused)
            SetGameState(GameState.Play);
    }
    void ToggleRestart()
    {
        SetGameState(GameState.Play);
    }

    void RestartGame()
    {
        SetGameState(GameState.Play);
    }
    void SetGameState(GameState newState)
    {
        currentState = newState;

        OnGameStateChanged?.Invoke(currentState);
        switch(currentState)
        {
            case GameState.Play:
                //logic for when entering the playing state
                Debug.Log("Playing");
                Time.timeScale = 1f;
                break;
            case GameState.Paused:
                //logic for when entering the pause state
                Debug.Log("Paused");
                Time.timeScale = 0f;
                break;
            case GameState.GameOver:
                Debug.Log("GameOver");
                break;

        }
    }

    public void DecreaseHealth(int life)
    {
        health -= life;
        lives_manager.ChangeLivesTxt(health);
        Debug.Log("Health: "+ health);
        if (health <= 0)
            SetGameState(GameState.GameOver);
    }

    public void IncreaseMoney()
    {
        money += 1;
        currency_manager.ChangeCurrencyUI(money);
    }
}
