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
    [SerializeField] public Text _TotalAmountText;
    [SerializeField] public Text _currentWinningsText;
    [SerializeField] public Text _currentBetText;

    [Header("Chest Text")]
    [SerializeField] public Text _topRightChest;
    [SerializeField] public Text _topLeftChest;
    [SerializeField] public Text _topMiddleChest;
    [SerializeField] public Text _middleRightChest;
    [SerializeField] public Text _middleLeftChest;
    [SerializeField] public Text _middleMiddleChest;
    [SerializeField] public Text _bottomRightChest;
    [SerializeField] public Text _bottomLeftChest;
    [SerializeField] public Text _bottomeMiddleChest;

    [Header("Play Button")]
    [SerializeField] public Button _playButton;

    [Header("Add Bet Buttons")]
    [SerializeField] public Button _plus25Button;
    [SerializeField] public Button _plus50Button;
    [SerializeField] public Button _plus1Button;
    [SerializeField] public Button _plus5Button;

    [Header("Subtract Bet Buttons")]
    [SerializeField] public Button _minus25Button;
    [SerializeField] public Button _minus50Button;
    [SerializeField] public Button _minus1Button;
    [SerializeField] public Button _minus5Button;
}
