using UnityEngine;
using UnityEngine.Tilemaps;
public class Board : MonoBehaviour{
    public Tilemap tilemap { get; private set; }
    public Piece activePiece { get; private set; }
    public TetrominoData[] tetrominoes;
    public Vector2Int boardSize = new Vector2Int(10, 20);
    public Vector3Int spawnPosition = new Vector3Int(-1, 8, 0);
    public GameObject Zero;
    public GameObject One;
    public GameObject Two;
    public GameObject Three;
    public GameObject Four;
    public GameObject Five;
    public GameObject Six;
    public GameObject Seven;
    public GameObject Eight;
    public GameObject Nine;
    private int digitOne = 0;
    public GameObject Zero2;
    public GameObject One2;
    public GameObject Two2;
    public GameObject Three2;
    public GameObject Four2;
    public GameObject Five2;
    public GameObject Six2;
    public GameObject Seven2;
    public GameObject Eight2;
    public GameObject Nine2;
    private int digitTwo = 0; 
    public GameObject Zero3;
    public GameObject One3;
    public GameObject Two3;
    public GameObject Three3;
    public GameObject Four3;
    public GameObject Five3;
    public GameObject Six3;
    public GameObject Seven3;
    public GameObject Eight3;
    public GameObject Nine3;
    private int digitThree = 0;
    public GameObject Zero4;
    public GameObject One4;
    public GameObject Two4;
    public GameObject Three4;
    public GameObject Four4;
    public GameObject Five4;
    public GameObject Six4;
    public GameObject Seven4;
    public GameObject Eight4;
    public GameObject Nine4;
    public GameObject Zero5;
    public GameObject One5;
    public GameObject Two5;
    public GameObject Three5;
    public GameObject Four5;
    public GameObject Five5;
    public GameObject Six5;
    public GameObject Seven5;
    public GameObject Eight5;
    public GameObject Nine5;
    public GameObject Zero6;
    public GameObject One6;
    public GameObject Two6;
    public GameObject Three6;
    public GameObject Four6;
    public GameObject Five6;
    public GameObject Six6;
    public GameObject Seven6;
    public GameObject Eight6;
    public GameObject Nine6;
    private int previousHigh1 = 0;
    private int previousHigh2 = 0;
    private int previousHigh3 = 0;
    private int highdigit1 = 0;
    private int highdigit2 = 0;
    private int highdigit3 = 0;
    private Vector3 tempPosition;
    private float speed = 1.00f;
    private int count = 0;
    private int score = 0;
    private int high = 0;
    public RectInt Bounds{
        get{
            Vector2Int position = new Vector2Int(-boardSize.x / 2, -boardSize.y / 2);
            return new RectInt(position, boardSize);
        }
    }
    private void Awake(){
        tilemap = GetComponentInChildren<Tilemap>();
        activePiece = GetComponentInChildren<Piece>();
        for (int i = 0; i < tetrominoes.Length; i++){
            tetrominoes[i].Initialize();
        }
    }
    private void Start(){
        SpawnPiece();
    }
    public void SpawnPiece(){
        int random = Random.Range(0, tetrominoes.Length);
        TetrominoData data = tetrominoes[random];
        activePiece.Initialize(this, spawnPosition, data);
        if (IsValidPosition(activePiece, spawnPosition)){
            Set(activePiece);
        }else{
            GameOver();
        }
    }
    public void GameOver(){
        tilemap.ClearAllTiles();
        if (score > high){
            if (score < 10){
                highdigit1 = score % 10;
            }
            if (score > 9 && score < 100){
                highdigit1 = score / 10;
                highdigit2 = score % 10;
            }
            if (score > 99){
                highdigit1 = (score % 100)%10;
                highdigit2 = (score % 100)/10;
                highdigit3 = score / 100;
            }
            if (highdigit1 != previousHigh1){
                if (previousHigh1 == 0){
                    tempPosition = Zero4.transform.position;
                    Zero4.transform.position = new Vector3(-35.0f, -18.0f, 0f);
                }else if (previousHigh1 == 1){
                    tempPosition = One4.transform.position;
                    One4.transform.position = new Vector3(-30.0f, -18.0f, 0f);
                }else if (previousHigh1 == 2){
                    tempPosition = Two4.transform.position;
                    Two4.transform.position = new Vector3(-25.0f, -18.0f, 0f);
                }else if (previousHigh1 == 3){
                    tempPosition = Three4.transform.position;
                    Three4.transform.position = new Vector3(-20.0f, -18.0f, 0f);
                }else if (previousHigh1 == 4){
                    tempPosition = Four4.transform.position;
                    Four4.transform.position = new Vector3(-15.0f, -18.0f, 0f);
                }else if (previousHigh1 == 5){
                    tempPosition = Five4.transform.position;
                    Five4.transform.position = new Vector3(-10.0f, -18.0f, 0f);
                }else if (previousHigh1 == 6){
                    tempPosition = Six4.transform.position;
                    Six4.transform.position = new Vector3(-5.0f, -18.0f, 0f);
                }else if (previousHigh1 == 7){
                    tempPosition = Seven4.transform.position;
                    Seven4.transform.position = new Vector3(-0.0f, -18.0f, 0f);
                }else if (previousHigh1 == 8){
                    tempPosition = Eight4.transform.position;
                    Eight4.transform.position = new Vector3(5.0f, -18.0f, 0f);
                }else if (previousHigh1 == 9){
                    tempPosition = Nine4.transform.position;
                    Nine4.transform.position = new Vector3(10.0f, -18.0f, 0f);
                }
                if (highdigit1 == 0){
                    Zero4.transform.position = tempPosition;
                }else if (highdigit1 == 1){
                    One4.transform.position = tempPosition;
                }else if (highdigit1 == 2){
                    Two4.transform.position = tempPosition;
                }else if (highdigit1 == 3){
                    Three4.transform.position = tempPosition;
                }else if (highdigit1 == 4){
                    Four4.transform.position = tempPosition;
                }else if (highdigit1 == 5){
                    Five4.transform.position = tempPosition;
                }else if (highdigit1 == 6){
                    Six4.transform.position = tempPosition;
                }else if (highdigit1 == 7){
                    Seven4.transform.position = tempPosition;
                }else if (highdigit1 == 8){
                    Eight4.transform.position = tempPosition;
                }else if (highdigit1 == 9){
                    Nine4.transform.position = tempPosition;
                }
            }
            if (highdigit2 != previousHigh2){
                if (previousHigh2 == 0){
                    tempPosition = Zero5.transform.position;
                    Zero5.transform.position = new Vector3(-35.0f, -18.0f, 0f);
                }else if (previousHigh2 == 1){
                    tempPosition = One5.transform.position;
                    One5.transform.position = new Vector3(-30.0f, -18.0f, 0f);
                }else if (previousHigh2 == 2){
                    tempPosition = Two5.transform.position;
                    Two5.transform.position = new Vector3(-25.0f, -18.0f, 0f);
                }else if (previousHigh2 == 3){
                    tempPosition = Three5.transform.position;
                    Three5.transform.position = new Vector3(-20.0f, -18.0f, 0f);
                }else if (previousHigh2 == 4){
                    tempPosition = Four5.transform.position;
                    Four5.transform.position = new Vector3(-15.0f, -18.0f, 0f);
                }else if (previousHigh2 == 5){
                    tempPosition = Five5.transform.position;
                    Five5.transform.position = new Vector3(-10.0f, -18.0f, 0f);
                }else if (previousHigh2 == 6){
                    tempPosition = Six5.transform.position;
                    Six5.transform.position = new Vector3(-5.0f, -18.0f, 0f);
                }else if (previousHigh2 == 7){
                    tempPosition = Seven5.transform.position;
                    Seven5.transform.position = new Vector3(-0.0f, -18.0f, 0f);
                }else if (previousHigh2 == 8){
                    tempPosition = Eight5.transform.position;
                    Eight5.transform.position = new Vector3(5.0f, -18.0f, 0f);
                }else if (previousHigh2 == 9){
                    tempPosition = Nine5.transform.position;
                    Nine5.transform.position = new Vector3(10.0f, -18.0f, 0f);
                }
                if (highdigit2 == 0){
                    Zero5.transform.position = tempPosition;
                }else if (highdigit2 == 1){
                    One5.transform.position = tempPosition;
                }else if (highdigit2 == 2){
                    Two5.transform.position = tempPosition;
                }else if (highdigit2 == 3){
                    Three5.transform.position = tempPosition;
                }else if (highdigit2 == 4){
                    Four5.transform.position = tempPosition;
                }else if (highdigit2 == 5){
                    Five5.transform.position = tempPosition;
                }else if (highdigit2 == 6){
                    Six5.transform.position = tempPosition;
                }else if (highdigit2 == 7){
                    Seven5.transform.position = tempPosition;
                }else if (highdigit2 == 8){
                    Eight5.transform.position = tempPosition;
                }else if (highdigit2 == 9){
                    Nine5.transform.position = tempPosition;
                }
            }
            if (highdigit3 != previousHigh3){
                if (previousHigh3 == 0){
                    tempPosition = Zero6.transform.position;
                    Zero6.transform.position = new Vector3(-35.0f, -18.0f, 0f);
                }else if (previousHigh3 == 1){
                    tempPosition = One6.transform.position;
                    One6.transform.position = new Vector3(-30.0f, -18.0f, 0f);
                }else if (previousHigh3 == 2){
                    tempPosition = Two6.transform.position;
                    Two6.transform.position = new Vector3(-25.0f, -18.0f, 0f);
                }else if (previousHigh3 == 3){
                    tempPosition = Three6.transform.position;
                    Three6.transform.position = new Vector3(-20.0f, -18.0f, 0f);
                }else if (previousHigh3 == 4){
                    tempPosition = Four6.transform.position;
                    Four6.transform.position = new Vector3(-15.0f, -18.0f, 0f);
                }else if (previousHigh3 == 5){
                    tempPosition = Five6.transform.position;
                    Five6.transform.position = new Vector3(-10.0f, -18.0f, 0f);
                }else if (previousHigh3 == 6){
                    tempPosition = Six6.transform.position;
                    Six6.transform.position = new Vector3(-5.0f, -18.0f, 0f);
                }else if (previousHigh3 == 7){
                    tempPosition = Seven6.transform.position;
                    Seven6.transform.position = new Vector3(-0.0f, -18.0f, 0f);
                }else if (previousHigh3 == 8){
                    tempPosition = Eight6.transform.position;
                    Eight6.transform.position = new Vector3(5.0f, -18.0f, 0f);
                }else if (previousHigh3 == 9){
                    tempPosition = Nine6.transform.position;
                    Nine6.transform.position = new Vector3(10.0f, -18.0f, 0f);
                }
                if (highdigit3 == 0){
                    Zero6.transform.position = tempPosition;
                }else if (highdigit3 == 1){
                    One6.transform.position = tempPosition;
                }else if (highdigit3 == 2){
                    Two6.transform.position = tempPosition;
                }else if (highdigit3 == 3){
                    Three6.transform.position = tempPosition;
                }else if (highdigit3 == 4){
                    Four6.transform.position = tempPosition;
                }else if (highdigit3 == 5){
                    Five6.transform.position = tempPosition;
                }else if (highdigit3 == 6){
                    Six6.transform.position = tempPosition;
                }else if (highdigit3 == 7){
                    Seven6.transform.position = tempPosition;
                }else if (highdigit3 == 8){
                    Eight6.transform.position = tempPosition;
                }else if (highdigit3 == 9){
                    Nine6.transform.position = tempPosition;
                }
            }
            high = score;
        }
        if (digitOne == 0){
            tempPosition = Zero.transform.position;
            Zero.transform.position = Zero.transform.position;
        }else if (digitOne == 1){
            tempPosition = One.transform.position;
            One.transform.position = Zero.transform.position;
        }else if (digitOne == 2){
            tempPosition = Two.transform.position;
            Two.transform.position = Zero.transform.position;
        }else if (digitOne == 3){
            tempPosition = Three.transform.position;
            Three.transform.position = Zero.transform.position;
        }else if (digitOne == 4){
            tempPosition = Four.transform.position;
            Four.transform.position = Zero.transform.position;
        }else if (digitOne == 5){
            tempPosition = Five.transform.position;
            Five.transform.position = Zero.transform.position;
        }else if (digitOne == 6){
            tempPosition = Six.transform.position;
            Six.transform.position = Zero.transform.position;
        }else if (digitOne == 7){
            tempPosition = Seven.transform.position;
            Seven.transform.position = Zero.transform.position;
        }else if (digitOne == 8){
            tempPosition = Eight.transform.position;
            Eight.transform.position = Zero.transform.position;
        }else if (digitOne == 9){
            tempPosition = Nine.transform.position;
            Nine.transform.position = Zero.transform.position;
        }
        Zero.transform.position = tempPosition;
        if (digitTwo == 0){
            tempPosition = Zero2.transform.position;
            Zero2.transform.position = Zero2.transform.position;
        }else if (digitTwo == 1){
            tempPosition = One2.transform.position;
            One2.transform.position = Zero2.transform.position;
        }else if (digitTwo == 2){
            tempPosition = Two2.transform.position;
            Two2.transform.position = Zero2.transform.position;
        }else if (digitTwo == 3){
            tempPosition = Three2.transform.position;
            Three2.transform.position = Zero2.transform.position;
        }else if (digitTwo == 4){
            tempPosition = Four2.transform.position;
            Four2.transform.position = Zero2.transform.position;
        }else if (digitTwo == 5){
            tempPosition = Five2.transform.position;
            Five2.transform.position = Zero2.transform.position;
        }else if (digitTwo == 6){
            tempPosition = Six2.transform.position;
            Six2.transform.position = Zero2.transform.position;
        }else if (digitTwo == 7){
            tempPosition = Seven2.transform.position;
            Seven2.transform.position = Zero2.transform.position;
        }else if (digitTwo == 8){
            tempPosition = Eight2.transform.position;
            Eight2.transform.position = Zero2.transform.position;
        }else if (digitTwo == 9){
            tempPosition = Nine2.transform.position;
            Nine2.transform.position = Zero2.transform.position;
        }
        Zero2.transform.position = tempPosition;
        if (digitThree == 0){
            tempPosition = Zero3.transform.position;
            Zero3.transform.position = Zero3.transform.position;
        }else if (digitThree == 1){
            tempPosition = One3.transform.position;
            One3.transform.position = Zero3.transform.position;
        }else if (digitThree == 2){
            tempPosition = Two3.transform.position;
            Two3.transform.position = Zero3.transform.position;
        }else if (digitThree == 3){
            tempPosition = Three3.transform.position;
            Three3.transform.position = Zero3.transform.position;
        }else if (digitThree == 4){
            tempPosition = Four3.transform.position;
            Four3.transform.position = Zero3.transform.position;
        }else if (digitThree == 5){
            tempPosition = Five3.transform.position;
            Five3.transform.position = Zero3.transform.position;
        }else if (digitThree == 6){
            tempPosition = Six3.transform.position;
            Six3.transform.position = Zero3.transform.position;
        }else if (digitThree == 7){
            tempPosition = Seven3.transform.position;
            Seven3.transform.position = Zero3.transform.position;
        }else if (digitThree == 8){
            tempPosition = Eight3.transform.position;
            Eight3.transform.position = Zero3.transform.position;
        }else if (digitThree == 9){
            tempPosition = Nine3.transform.position;
            Nine3.transform.position = Zero3.transform.position;
        }
        Zero3.transform.position = tempPosition;
        count = 0;
        digitOne = 0;
        digitTwo = 0;
        digitThree = 0;
        previousHigh1 = highdigit1;
        previousHigh2 = highdigit2;
        previousHigh3 = highdigit3;
        speed = 1.00f;
        score = 0;
    }
    public void Set(Piece piece){
        piece.stepDelay = speed;
        for (int i = 0; i < piece.cells.Length; i++){
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, piece.data.tile);
        }
    }
    public void Clear(Piece piece){
        for (int i = 0; i < piece.cells.Length; i++){
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            tilemap.SetTile(tilePosition, null);
        }
    }
    public bool IsValidPosition(Piece piece, Vector3Int position){
        RectInt bounds = Bounds; // The position is only valid if every cell is valid
        for (int i = 0; i < piece.cells.Length; i++){
            Vector3Int tilePosition = piece.cells[i] + position;
            if (!bounds.Contains((Vector2Int)tilePosition)){// An out of bounds tile is invalid
                return false;
            }
            if (tilemap.HasTile(tilePosition)){// A tile already occupies the position, thus invalid
                return false;
            }
        }
        return true;
    }
    public void ClearLines(){
        RectInt bounds = Bounds;
        int row = bounds.yMin;
        // Clear from bottom to top
        while (row < bounds.yMax){// Only advance to the next row if the current is not cleared
            if (IsLineFull(row)){// because the tiles above will fall down when a row is cleared
                LineClear(row);
            }else{
                row++;
            }
        }
    }
    public bool IsLineFull(int row){
        RectInt bounds = Bounds;
        for (int col = bounds.xMin; col < bounds.xMax; col++){
            Vector3Int position = new Vector3Int(col, row, 0);
            if (!tilemap.HasTile(position)){//Not full line if a tile is missing
                return false;
            }
        }
        return true;
    }
    public void scoring(){
        digitOne++;
        score++;
        if(digitOne == 10){
            digitOne = 0;
            if (count <= 500){
                speed = speed - 0.001f;
            }
            tempPosition = Nine.transform.position;
            Nine.transform.position = Zero.transform.position;
            Zero.transform.position = tempPosition;
            digitTwo++;
            if (digitTwo == 10){
                digitTwo = 0;
                tempPosition = Nine2.transform.position;
                Nine2.transform.position = Zero2.transform.position;
                Zero2.transform.position = tempPosition;
                digitThree++;
                if (digitThree == 10){
                    digitThree = 0;
                    tempPosition = Nine3.transform.position;
                    Nine3.transform.position = Zero3.transform.position;
                    Zero3.transform.position = tempPosition;
                }else if (digitThree == 1){
                    tempPosition = Zero3.transform.position;
                    Zero3.transform.position = One3.transform.position;
                    One3.transform.position = tempPosition;
                }else if (digitThree == 2){
                    tempPosition = One3.transform.position;
                    One3.transform.position = Two3.transform.position;
                    Two3.transform.position = tempPosition;
                }else if (digitThree == 3){
                    tempPosition = Two3.transform.position;
                    Two3.transform.position = Three3.transform.position;
                    Three3.transform.position = tempPosition;
                }else if (digitThree == 4){
                    tempPosition = Three3.transform.position;
                    Three3.transform.position = Four3.transform.position;
                    Four3.transform.position = tempPosition;
                }else if (digitThree == 5){
                    tempPosition = Four3.transform.position;
                    Four3.transform.position = Five3.transform.position;
                    Five3.transform.position = tempPosition;
                }else if (digitThree == 6){
                    tempPosition = Five3.transform.position;
                    Five3.transform.position = Six3.transform.position;
                    Six3.transform.position = tempPosition;
                }else if (digitThree == 7){
                    tempPosition = Six3.transform.position;
                    Six3.transform.position = Seven3.transform.position;
                    Seven3.transform.position = tempPosition;
                }else if (digitThree == 8){
                    tempPosition = Seven3.transform.position;
                    Seven3.transform.position = Eight3.transform.position;
                    Eight3.transform.position = tempPosition;
                }else if (digitThree == 9){
                    tempPosition = Eight3.transform.position;
                    Eight3.transform.position = Nine3.transform.position;
                    Nine3.transform.position = tempPosition;
                }
            }else if (digitTwo == 1){
                tempPosition = Zero2.transform.position;
                Zero2.transform.position = One2.transform.position;
                One2.transform.position = tempPosition;
            }else if (digitTwo == 2){
                tempPosition = One2.transform.position;
                One2.transform.position = Two2.transform.position;
                Two2.transform.position = tempPosition;
            }else if (digitTwo == 3){
                tempPosition = Two2.transform.position;
                Two2.transform.position = Three2.transform.position;
                Three2.transform.position = tempPosition;
            }else if (digitTwo == 4){
                tempPosition = Three2.transform.position;
                Three2.transform.position = Four2.transform.position;
                Four2.transform.position = tempPosition;
            }else if (digitTwo == 5){
                tempPosition = Four2.transform.position;
                Four2.transform.position = Five2.transform.position;
                Five2.transform.position = tempPosition;
            }else if (digitTwo == 6){
                tempPosition = Five2.transform.position;
                Five2.transform.position = Six2.transform.position;
                Six2.transform.position = tempPosition;
            }else if (digitTwo == 7){
                tempPosition = Six2.transform.position;
                Six2.transform.position = Seven2.transform.position;
                Seven2.transform.position = tempPosition;
            }else if (digitTwo == 8){
                tempPosition = Seven2.transform.position;
                Seven2.transform.position = Eight2.transform.position;
                Eight2.transform.position = tempPosition;
            }else if (digitTwo == 9){
                tempPosition = Eight2.transform.position;
                Eight2.transform.position = Nine2.transform.position;
                Nine2.transform.position = tempPosition;
            }
        }else if (digitOne == 1){
            tempPosition = Zero.transform.position;
            Zero.transform.position = One.transform.position;
            One.transform.position = tempPosition;
        }else if (digitOne == 2){
            tempPosition = One.transform.position;
            One.transform.position = Two.transform.position;
            Two.transform.position = tempPosition;
        }else if (digitOne == 3){
            tempPosition = Two.transform.position;
            Two.transform.position = Three.transform.position;
            Three.transform.position = tempPosition;
        }else if (digitOne == 4){
            tempPosition = Three.transform.position;
            Three.transform.position = Four.transform.position;
            Four.transform.position = tempPosition;
        }else if (digitOne == 5){
            tempPosition = Four.transform.position;
            Four.transform.position = Five.transform.position;
            Five.transform.position = tempPosition;
        }else if (digitOne == 6){
            tempPosition = Five.transform.position;
            Five.transform.position = Six.transform.position;
            Six.transform.position = tempPosition;
        }else if (digitOne == 7){
            tempPosition = Six.transform.position;
            Six.transform.position = Seven.transform.position;
            Seven.transform.position = tempPosition;
        }else if (digitOne == 8){
            tempPosition = Seven.transform.position;
            Seven.transform.position = Eight.transform.position;
            Eight.transform.position = tempPosition;
        }else if (digitOne == 9){
            tempPosition = Eight.transform.position;
            Eight.transform.position = Nine.transform.position;
            Nine.transform.position = tempPosition;
        }
    }
    public void LineClear(int row){
        RectInt bounds = Bounds;
        for (int col = bounds.xMin; col < bounds.xMax; col++){// Clear all tiles in the row
            Vector3Int position = new Vector3Int(col, row, 0);
            tilemap.SetTile(position, null);
        }
        while (row < bounds.yMax){// Shift every row above down 1
            for (int col = bounds.xMin; col < bounds.xMax; col++){
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