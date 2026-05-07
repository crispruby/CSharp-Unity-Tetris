using UnityEngine;
/// <summary>
/// Handles active piece behavior, including movement, rotation, input processing, and locking.
/// </summary>
public class Piece : MonoBehaviour
{
    [Header("Controls")]
    public KeyCode RotateLeftKey = KeyCode.Alpha1;
    public KeyCode RotateRightKey = KeyCode.Alpha3;
    public KeyCode HardDropKey = KeyCode.UpArrow;
    public KeyCode HardDropAltKey = KeyCode.Space;
    public KeyCode SoftDropKey = KeyCode.DownArrow;
    public KeyCode SoftDropAltKey = KeyCode.Alpha2;
    public KeyCode MoveLeftKey = KeyCode.LeftArrow;
    public KeyCode MoveRightKey = KeyCode.RightArrow;
    public Board board;
    public TetrominoData data { get; private set; }
    public Vector3Int[] cells { get; private set; }
    public Vector3Int position { get; private set; }
    public int rotationIndex { get; private set; }
    public float stepDelay = 1.0f;
    public float moveDelay = 0.2f;
    public float lockDelay = 0.5f;
    private float stepTime;
    private float moveTime;
    private float lockTime;
    private bool locked;
    /// <summary>
    /// Initializes the piece with board reference, position, and tetromino data.
    /// </summary>
    public void Initialize(Board board, Vector3Int position, TetrominoData data)
    {
        this.data = data;
        this.board = board;
        this.position = position;
        rotationIndex = 0;
        stepDelay = board.CurrentSpeed;
        stepTime = Time.time + stepDelay;
        moveTime = Time.time + moveDelay;
        lockTime = 0f;
        cells = new Vector3Int[data.cells.Length];
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i] = (Vector3Int)data.cells[i];
        }
    }
    private void Update()
    {
        board.Clear(this);
        locked = false;
        lockTime += Time.deltaTime;
        if (Input.GetKeyUp(RotateLeftKey))
        {
            Rotate(-1);
        }
        else if (Input.GetKeyUp(RotateRightKey))
        {
            Rotate(1);
        }
        if (Input.GetKeyUp(HardDropKey) || Input.GetKeyUp(HardDropAltKey))
        {
            HardDrop();
        }
        if (Time.time > moveTime)
        {
            HandleMoveInputs();
        }
        if (Time.time > stepTime)
        {
            Step();
        }
        if (!locked)
        {
            board.Set(this);
        }
    }
    private void HandleMoveInputs()
    {
        if (Input.GetKeyUp(SoftDropKey) || Input.GetKeyUp(SoftDropAltKey))
        {
            if (Move(Vector2Int.down))
            {
                stepTime = Time.time + stepDelay;
            }
        }
        if (Input.GetKeyDown(MoveLeftKey))
        {
            Move(Vector2Int.left);
        }
        else if (Input.GetKeyDown(MoveRightKey))
        {
            Move(Vector2Int.right);
        }
    }
    private void Step()
    {
        stepTime = Time.time + stepDelay;
        Move(Vector2Int.down);
        if (lockTime >= lockDelay)
        {
            Lock();
        }
    }
    private void HardDrop()
    {
        while (Move(Vector2Int.down))
        {
        }
        Lock();
    }
    private void Lock()
    {
        locked = true;
        board.LockPiece(this);
    }
    private bool Move(Vector2Int translation)
    {
        Vector3Int newPosition = position;
        newPosition.x += translation.x;
        newPosition.y += translation.y;
        bool valid = board.IsValidPosition(this, newPosition);
        if (valid)
        {
            position = newPosition;
            moveTime = Time.time + moveDelay;
            lockTime = 0f;
        }
        return valid;
    }
    private void Rotate(int direction)
    {
        int originalRotation = rotationIndex;
        rotationIndex = Wrap(rotationIndex + direction, 0, 4);
        ApplyRotationMatrix(direction);
        if (!TestWallKicks(rotationIndex, direction))
        {
            rotationIndex = originalRotation;
            ApplyRotationMatrix(-direction);
        }
    }
    private void ApplyRotationMatrix(int direction)
    {
        float[] matrix = Data.RotationMatrix;
        for (int i = 0; i < cells.Length; i++)
        {
            Vector3 cell = cells[i];
            int x, y;
            switch (data.tetromino)
            {
                case Tetromino.I:
                case Tetromino.O:
                    cell.x -= 0.5f;
                    cell.y -= 0.5f;
                    x = Mathf.CeilToInt((cell.x * matrix[0] * direction) + (cell.y * matrix[1] * direction));
                    y = Mathf.CeilToInt((cell.x * matrix[2] * direction) + (cell.y * matrix[3] * direction));
                    break;
                default:
                    x = Mathf.RoundToInt((cell.x * matrix[0] * direction) + (cell.y * matrix[1] * direction));
                    y = Mathf.RoundToInt((cell.x * matrix[2] * direction) + (cell.y * matrix[3] * direction));
                    break;
            }
            cells[i] = new Vector3Int(x, y, 0);
        }
    }
    private bool TestWallKicks(int rotationIndex, int rotationDirection)
    {
        int wallKickIndex = GetWallKickIndex(rotationIndex, rotationDirection);
        for (int i = 0; i < data.wallKicks.GetLength(1); i++)
        {
            Vector2Int translation = data.wallKicks[wallKickIndex, i];
            if (Move(translation))
            {
                return true;
            }
        }
        return false;
    }
    private int GetWallKickIndex(int rotationIndex, int rotationDirection)
    {
        int wallKickIndex = rotationIndex * 2;
        if (rotationDirection < 0)
        {
            wallKickIndex--;
        }
        return Wrap(wallKickIndex, 0, data.wallKicks.GetLength(0));
    }
    private int Wrap(int input, int min, int max)
    {
        if (input < min)
        {
            return max - (min - input) % (max - min);
        }
        return min + (input - min) % (max - min);
    }
}
