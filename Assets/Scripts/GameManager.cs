using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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

    public float[] _chestToPick;
    private float _totalAmount = 10.0f;
    private float _possibleWinnings = 0f;
    private float _currentBet = 0.0f;
    private float _amountLeft;
    private int _chestSelected;
    private float _winnings = 0f;
    [SerializeField] private float _minimumIncrement = 0.05f;
    private Chests _chest;

    private void Start()
    {
        _chest = GetComponent<Chests>();

        if (_chest == null)
            Debug.LogError("Chest Script is null");
    }

    private void Update()
    {
        if (_chestToPick.Length > 0)
        {
            UIManager.Instance._plus25Button.interactable = false;
            UIManager.Instance._plus50Button.interactable = false;
            UIManager.Instance._plus1Button.interactable = false;
            UIManager.Instance._plus5Button.interactable = false;
            UIManager.Instance._minus25Button.interactable = false;
            UIManager.Instance._minus50Button.interactable = false;
            UIManager.Instance._minus1Button.interactable = false;
            UIManager.Instance._minus5Button.interactable = false;
            UIManager.Instance._playButton.interactable = false;
        }
        else
        {
            UIManager.Instance._playButton.interactable = true;
            ManageButtons();
        }
    }

    public float Total()
    {
        _totalAmount -= _currentBet;
        return _totalAmount;
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

    public void PossibleWinnings(int multiplier)
    {
        if (multiplier == 0)
        {
            _currentBet = 0f;
            return;
        }

        _possibleWinnings = _currentBet * multiplier;
        _currentBet = 0f;

        int lengthOfChest = Random.Range(1, 9);

        _chestToPick = new float[lengthOfChest];

        for (int i = 0; i < _chestToPick.Length; i++)
        {
            _chestToPick[i] += _minimumIncrement;
        }


        while (_chestToPick.Sum() < _possibleWinnings)
        {
            int randomSpot = Random.Range(0, _chestToPick.Length);
            _chestToPick[randomSpot] += _minimumIncrement;
            _chestToPick[randomSpot] = Mathf.Round(_chestToPick[randomSpot] * 100f) / 100f;
        }
    }

    public void ResetValues()
    {
        _chestSelected = 0;
    }

    public void OpenChest(Text text)
    {
        UIManager.Instance._currentWinningsText.text = ("Current Winnings: $0.00");

        float amountToShow = 0;
        if (_chestSelected <= _chestToPick.Length - 1)
        {
            amountToShow = _chestToPick[_chestSelected];
            text.text = $"${amountToShow.ToString("F2")}";
        }
        else
        {
            text.text = "$0.00";
            _chest.DisableChest();
        }

        _winnings += amountToShow;
        _totalAmount += _winnings;

        UIManager.Instance._currentWinningsText.text = ("Current Winnings: $" + _winnings.ToString("F2"));
        UIManager.Instance._TotalAmountText.text = ("Total Amount: $" + _totalAmount.ToString("F2"));

        StartCoroutine(ShowAmount(text));

        if (_chestSelected == _chestToPick.Length)
        {
            ResetGame();
        }

        _chestSelected++;
    }

    private void ManageButtons()
    {
        _amountLeft = _totalAmount - _currentBet;

        if (_currentBet == 0f)
            UIManager.Instance._playButton.interactable = false;

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

    private void ResetGame()
    {
        _chestSelected = 0;
        _chestToPick = new float[0];
        UIManager.Instance._currentWinningsText.text = "Previous Winnings: $" + _winnings.ToString("F2");
        _winnings = 0f;
    }

    IEnumerator ShowAmount(Text text)
    {
        text.enabled = true;

        yield return new WaitForSeconds(0.5f);

        text.enabled = false;
    }
}
