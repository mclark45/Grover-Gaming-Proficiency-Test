using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void Play()
    {
        GameManager.Instance.Play();
        UIManager.Instance._TotalAmountText.text = ("Total Amount: $" + GameManager.Instance.Total().ToString("F2"));
        UIManager.Instance._currentWinningsText.text = ("Current Winnings: $" + GameManager.Instance.CurrentWinnings().ToString("F2"));
    }

    //Add amount to current bet

    public void Bet25Cents()
    {
        UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.AddBet(0.25f).ToString("F2"));
    }

    public void Bet50Cents()
    {
        UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.AddBet(0.5f).ToString("F2"));
    }

    public void Bet1Dollar()
    {
        UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.AddBet(1.0f).ToString("F2"));
    }

    public void Bet5Dollars()
    {
        UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.AddBet(5.0f).ToString("F2"));
    }

    //Subtract amount from current bet

    public void Subtract25Cents()
    {
        UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.SubtractBet(0.25f).ToString("F2"));
    }

    public void Subtract50Cents()
    {
        UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.SubtractBet(0.5f).ToString("F2"));
    }

    public void Subtract1Dollar()
    {
        UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.SubtractBet(1.0f).ToString("F2"));
    }

    public void Subtract5Dollars()
    {
        UIManager.Instance._currentBetText.text = ("Current Bet: $" + GameManager.Instance.SubtractBet(5.0f).ToString("F2"));
    }
}
