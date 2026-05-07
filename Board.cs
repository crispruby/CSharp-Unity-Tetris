using UnityEngine;
using UnityEngine.Tilemaps;
/// <summary>
/// Manages the Tetris game board, including tile placement, line clearing, scoring, and game state.
/// </summary>
public class Board : MonoBehaviour
{
    private const int DIGIT_PLACES = 3;
    private const float SPEED_DECREASE_RATE = 0.001f;
    private const int MAX_SCORE_FOR_SPEED_INCREASE = 500;
    public Tilemap tilemap { get; private set; }
    public Piece activePiece { get; private set; }
    public TetrominoData[] tetrominoes;
    public Vector2Int boardSize = new Vector2Int(10, 20);
    public Vector3Int spawnPosition = new Vector3Int(-1, 8, 0);
    public float CurrentSpeed => speed;
    public GameObject[] scoreDigits0 = new GameObject[10];
    public GameObject[] scoreDigits1 = new GameObject[10];
    public GameObject[] scoreDigits2 = new GameObject[10];
    public GameObject[] highScoreDigits0 = new GameObject[10];
    public GameObject[] highScoreDigits1 = new GameObject[10];
    public GameObject[] highScoreDigits2 = new GameObject[10];
    private GameObject[][] scoreDigits;
    private GameObject[][] highScoreDigits;
    private float speed = 1.00f;
    private const float MinSpeed = 0.10f;
    private int score;
    private int high;
    public RectInt Bounds
    {
        get
        {
            Vector2Int position = new Vector2Int(-boardSize.x / 2, -boardSize.y / 2);
            return new RectInt(position, boardSize);
        }
    }
    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        activePiece = GetComponentInChildren<Piece>();
        InitializeTetrominoes();
        InitializeScoreArrays();
    }
    private void Start()
    {
        SpawnPiece();
    }
    private void InitializeTetrominoes()
    {
        for (int i = 0; i < tetrominoes.Length; i++)
        {
            tetrominoes[i].Initialize();
        }
    }
    private void InitializeScoreArrays()
    {
        scoreDigits = new GameObject[][]
        {
            scoreDigits0,
            scoreDigits1,
            scoreDigits2
        };
        highScoreDigits = new GameObject[][]
        {
            highScoreDigits0,
            highScoreDigits1,
            highScoreDigits2
        };
    }
    private int[] ExtractDigits(int value, int places)
    {
        int[] digits = new int[places];
        for (int i = places - 1; i >= 0; i--)
        {
            digits[i] = value % 10;
            value /= 10;
        }
        return digits;
    }
    private void SetDigit(GameObject[] digitSet, int digit)
    {
        if (digit < 0 || digit >= digitSet.Length)
        {
            return;
        }

        for (int i = 0; i < digitSet.Length; i++)
        {
            if (digitSet[i] == null)
            {
                continue;
            }
            digitSet[i].SetActive(i == digit);
        }
    }
    private void UpdateScoreDisplay()
    {
        int[] digits = ExtractDigits(score, DIGIT_PLACES);
        for (int i = 0; i < DIGIT_PLACES; i++)
        {
            SetDigit(scoreDigits[i], digits[i]);
        }
    }
    private void UpdateHighScoreDisplay()
    {
        int[] digits = ExtractDigits(high, DIGIT_PLACES);
        for (int i = 0; i < DIGIT_PLACES; i++)
        {
            SetDigit(highScoreDigits[i], digits[i]);
        }
    }
    private void ResetScoreDisplay()
    {
        for (int i = 0; i < DIGIT_PLACES; i++)
        {
            SetDigit(scoreDigits[i], 0);
        }
    }
    /// <summary>
    /// Spawns a random tetromino piece at the spawn position.
    /// </summary>
    public void SpawnPiece()
    {
        int random = Random.Range(0, tetrominoes.Length);
        TetrominoData data = tetrominoes[random];
        activePiece.Initialize(this, spawnPosition, data);
        activePiece.stepDelay = speed;

        if (IsValidPosition(activePiece, spawnPosition))
        {
            Set(activePiece);
        }
        else
        {
            GameOver();
        }
    }
    /// <summary>
    /// Handles game over state, updating high score and resetting the board.
    /// </summary>
    public void GameOver()
    {
        tilemap.ClearAllTiles();
        if (score > high)
        {
            high = score;
            UpdateHighScoreDisplay();
        }

        score = 0;
        speed = 1.00f;
        ResetScoreDisplay();
    }
    /// <summary>
    /// Places a piece on the board tilemap.
    /// </summary>
    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, piece.data.tile);
        }
    }
    /// <summary>
    /// Clears a piece from the board tilemap.
    /// </summary>
    public void Clear(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, null);
        }
    }
    /// <summary>
    /// Checks if a piece at the given position is valid (in bounds and no collisions).
    /// </summary>
    public bool IsValidPosition(Piece piece, Vector3Int position)
    {
        RectInt bounds = Bounds;
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + position;
            if (!bounds.Contains((Vector2Int)tilePosition))
            {
                return false;
            }

            if (tilemap.HasTile(tilePosition))
            {
                return false;
            }
        }
        return true;
    }
    /// <summary>
    /// Clears complete lines and shifts remaining tiles down.
    /// </summary>
    public void ClearLines()
    {
        RectInt bounds = Bounds;
        int row = bounds.yMin;

        while (row < bounds.yMax)
        {
            if (IsLineFull(row))
            {
                LineClear(row);
            }
            else
            {
                row++;
            }
        }
    }
    /// <summary>
    /// Checks if a row is completely filled with tiles.
    /// </summary>
    public bool IsLineFull(int row)
    {
        RectInt bounds = Bounds;
        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);
            if (!tilemap.HasTile(position))
            {
                return false;
            }
        }
        return true;
    }
    /// <summary>
    /// Increments score and increases speed up to a limit.
    /// </summary>
    public void scoring()
    {
        score++;
        if (score <= MAX_SCORE_FOR_SPEED_INCREASE)
        {
            speed = Mathf.Max(MinSpeed, speed - SPEED_DECREASE_RATE);
        }
        UpdateScoreDisplay();
    }
    /// <summary>
    /// Locks the piece, clears the line, and spawns a new piece.
    /// </summary>
    public void LockPiece(Piece piece)
    {
        Set(piece);
        ClearLines();
        SpawnPiece();
    }
    public void LineClear(int row)
    {
        RectInt bounds = Bounds;
        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);
            tilemap.SetTile(position, null);
        }
        while (row < bounds.yMax)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col, row + 1, 0);
                TileBase above = tilemap.GetTile(position);
                position = new Vector3Int(col, row, 0);
                tilemap.SetTile(position, above);
            }
            row++;
        }
        scoring();
    }
}
