using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private int _lowOdds;
    [SerializeField] private int _midOdds;
    [SerializeField] private int _highOdds;
    private int multiplier = 0;

    [SerializeField] private int[] _lowWin = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    [SerializeField] private int[] _midWin = new int[6] { 12, 16, 24, 32, 48, 64 };
    [SerializeField] private int[] _highWin = new int[5] { 100, 200, 300, 400, 500 };

    public void GetOdds()
    {
        int OddsRoll = Random.Range(0, 100);

        if (OddsRoll <= _highOdds)
            GetMultiplier(3);
        else if (OddsRoll <= _midOdds + _highOdds)
            GetMultiplier(2);
        else if (OddsRoll <= _lowOdds + _midOdds + _highOdds)
            GetMultiplier(1);
        else
            GetMultiplier(0);
    }

    private void GetMultiplier(int MultiplierSet)
    {
        int multiplierRoll = 0;

        switch (MultiplierSet)
        {
            case 0:
                multiplier = 0;
                GameManager.Instance.PossibleWinnings(multiplier);
                break;
            case 1:
                multiplierRoll = Random.Range(0, _lowWin.Length);
                multiplier = _lowWin[multiplierRoll];
                GameManager.Instance.PossibleWinnings(multiplier);
                break;
            case 2:
                multiplierRoll = Random.Range(0, _midWin.Length);
                multiplier = _midWin[multiplierRoll];
                GameManager.Instance.PossibleWinnings(multiplier);
                break;
            case 3:
                multiplierRoll = Random.Range(0, _highWin.Length);
                multiplier = _highWin[multiplierRoll];
                GameManager.Instance.PossibleWinnings(multiplier);
                break;
            default:
                break;
        }
    }
}
