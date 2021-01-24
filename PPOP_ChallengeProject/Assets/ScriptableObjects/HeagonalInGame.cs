using PathFinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InGame", menuName = "InGameScripts/HexaObject")]
public class HeagonalInGame : ScriptableObject
{
    [SerializeField]
    private int RowIndex; 
    [SerializeField]
    private int ColumnIndex;

    [SerializeField]
    private GameObject refHegagonalInGame;

    [SerializeField]
    private IAStarNode node;

    public HeagonalInGame(int rowIndex, int columnIndex, GameObject refHegagonalInGame)
    {
        RowIndex = rowIndex;
        ColumnIndex = columnIndex;
        this.refHegagonalInGame = refHegagonalInGame;
    }
}
