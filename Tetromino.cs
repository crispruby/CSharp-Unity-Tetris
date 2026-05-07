using UnityEngine;
using UnityEngine.Tilemaps;
/// <summary>
/// Enumeration of tetromino types.
/// </summary>
public enum Tetromino
{
    I, J, L, O, S, T, Z
}
/// <summary>
/// Serializable data structure for tetromino definitions, including tile, type, cells, and wall-kicks.
/// </summary>
[System.Serializable]
public struct TetrominoData
{
    public TileBase tile;
    public Tetromino tetromino;
    public Vector2Int[] cells { get; private set; }
    public Vector2Int[,] wallKicks { get; private set; }
    /// <summary>
    /// Copies the shared tetromino cell and wall-kick templates for this tetromino type.
    /// </summary>
    public void Initialize()
    {
        int index = (int)tetromino;
        if (index < 0 || index >= Data.Cells.Length)
        {
            Debug.LogError($"Invalid tetromino type: {tetromino}");
            return;
        }
        cells = Data.Cells[index];
        wallKicks = Data.WallKicks[index];
    }
}
