using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game Manger is Null");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private Multiplier _multiplier;
    private float _totalAmount = 10.0f;
    private float _currentWinnings = 0f;
    private float _currentBet = 0.0f;
    private float _amountLeft;

    private void Start()
    {
        _multiplier = GetComponent<Multiplier>();

        if (_multiplier == null)
            Debug.LogError("Multiplier Script is Null");
    }

    private void Update()
    {
        ManageButtons();
    }

    public void Play ()
    {
        _multiplier.GetOdds();
    }

    public float Total()
    {
        _totalAmount -= _currentBet;
        return _totalAmount;
    }

    public float CurrentWinnings()
    {
        _currentBet = 0f;

        UIManager.Instance._currentBetText.text = ("Current Bet: $" + _currentBet);

        return _currentWinnings;
    }

    public float ResetBet()
    {
        _currentBet = 0f;
        return _currentBet;
    }

    public float AddBet(float amount)
    {
        _currentBet += amount;

        return _currentBet;
    }

    public float SubtractBet(float amount)
    {
        _currentBet -= amount;

        return _currentBet;
    }

    public void SplitWinnings(int multiplier)
    {
        _currentWinnings = _currentBet * multiplier;
    }

    private void ManageButtons()
    {
        _amountLeft = _totalAmount - _currentBet;

        //Disable Buttons that will bet more than player has

        if (_amountLeft < 0.25f)
            UIManager.Instance._plus25Button.interactable = false;

        if (_amountLeft < 0.5f)
            UIManager.Instance._plus50Button.interactable = false;

        if (_amountLeft < 1.0f)
            UIManager.Instance._plus1Button.interactable = false;

        if (_amountLeft < 5.0f)
            UIManager.Instance._plus5Button.interactable = false;

        //Enables Buttons that player can bet
        
        if (_amountLeft >= 0.25f)
            UIManager.Instance._plus25Button.interactable = true;

        if (_amountLeft >= 0.5f)
            UIManager.Instance._plus50Button.interactable = true;

        if (_amountLeft >= 1.0f)
            UIManager.Instance._plus1Button.interactable = true;

        if (_amountLeft >= 5.0f)
            UIManager.Instance._plus5Button.interactable = true;

        //Disable Buttons that will subtract more than player has

        if (_currentBet < 0.25f)
            UIManager.Instance._minus25Button.interactable = false;

        if (_currentBet < 0.5f)
            UIManager.Instance._minus50Button.interactable = false;

        if (_currentBet < 1.0f)
            UIManager.Instance._minus1Button.interactable = false;

        if (_currentBet < 5.0f)
            UIManager.Instance._minus5Button.interactable = false;

        //Enables Buttons that player can subtract

        if (_currentBet >= 0.25f)
            UIManager.Instance._minus25Button.interactable = true;

        if (_currentBet >= 0.5f)
            UIManager.Instance._minus50Button.interactable = true;

        if (_currentBet >= 1.0f)
            UIManager.Instance._minus1Button.interactable = true;

        if (_currentBet >= 5.0f)
            UIManager.Instance._minus5Button.interactable = true;
    }
}
