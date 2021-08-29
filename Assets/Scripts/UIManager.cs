using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is Null");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    [Header("Game Text")]
    public Text _TotalAmountText;
    public Text _currentWinningsText;
    public Text _currentBetText;

    [Header("Chest Text")]
    public Text _topRightChest;
    public Text _topLeftChest;
    public Text _topMiddleChest;
    public Text _middleRightChest;
    public Text _middleLeftChest;
    public Text _middleMiddleChest;
    public Text _bottomRightChest;
    public Text _bottomLeftChest;
    public Text _bottomeMiddleChest;

    [Header("Play Button")]
    public Button _playButton;

    [Header("Add Bet Buttons")]
    public Button _plus25Button;
    public Button _plus50Button;
    public Button _plus1Button;
    public Button _plus5Button;

    [Header("Subtract Bet Buttons")]
    public Button _minus25Button;
    public Button _minus50Button;
    public Button _minus1Button;
    public Button _minus5Button;
}
