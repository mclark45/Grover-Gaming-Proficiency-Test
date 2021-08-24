using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private Multiplier _multiplier;
    private Chests _chests;

    private void Start()
    {
        _multiplier = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Multiplier>();
        _chests = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Chests>();

        if (_multiplier == null)
            Debug.LogError("Multiplier Script is Null");

        if (_chests == null)
            Debug.LogError("Chests is Null");
    }

    public void Play()
    {
        foreach (var chest in _chests._chests)
        {
            chest.interactable = true;
        }

        UIManager.Instance._TotalAmountText.text = ("Total Amount: $" + GameManager.Instance.Total().ToString("F2"));
        UIManager.Instance._currentWinningsText.text = ("Current Winnings: $0.00" );
        UIManager.Instance._currentBetText.text = ("Current Bet: $0.00");
        _multiplier.GetOdds();
    }


    public void AddingABid(int amount)
    {
        switch (amount)
        {
            case 25:
                UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.AddBet(0.25f).ToString("F2"));
                break;
            case 50:
                UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.AddBet(0.5f).ToString("F2"));
                break;
            case 1:
                UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.AddBet(1.0f).ToString("F2"));
                break;
            case 5:
                UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.AddBet(5.0f).ToString("F2"));
                break;
            default:
                break;
        }
    }

    public void SubtractingABid(int amount)
    {
        switch (amount)
        {
            case -25:
                UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.SubtractBet(0.25f).ToString("F2"));
                break;
            case -50:
                UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.SubtractBet(0.5f).ToString("F2"));
                break;
            case -1:
                UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.SubtractBet(1.0f).ToString("F2"));
                break;
            case -5:
                UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.SubtractBet(5.0f).ToString("F2"));
                break;
            default:
                break;
        }
    }
}
