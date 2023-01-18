using UnityEngine;
using UnityEngine.Tilemaps;
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap colliisionTilemap;
    [SerializeField]
    private Transform parentTransform;

    private PlayerControls playerControls;

    private void Awake() {
        playerControls = new PlayerControls();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start() {
        playerControls.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>()); //every time we press the movement keys we tell our move function how we wanna move
    }

    private void Move(Vector2 direction) {
        if (CanMove(direction)) {
            parentTransform.position += (Vector3)direction; //note that this works due to the grid understanding each cell is 1x1
        }
    }

    private bool CanMove(Vector2 direction) { //checks if we can move to a tile
        Vector3Int gridPosition = groundTilemap.WorldToCell(parentTransform.position + (Vector3)direction); //attemped tile to move to
        if (!groundTilemap.HasTile(gridPosition) || colliisionTilemap.HasTile(gridPosition)) { 
            return false;
        }
        return true;

    }

}
