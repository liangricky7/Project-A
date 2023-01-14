using UnityEngine;
using UnityEngine.Tilemaps;
public class PlayerMovement : MonoBehaviour {
    private PlayerControls playerControls;

    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap colliisionTilemap;


    private bool isMoving;
    private Vector2 move;

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
        playerControls.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>()); //every time we do movement keys we tell our move function how we wanna move
    }

    private void Move(Vector2 direction) {
        if (CanMove(direction)) {
            transform.position += (Vector3)direction;
        }
    }

    private bool CanMove(Vector2 direction) { //checks if we can move to a tile
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction); //attemped tile to move to
        if (!groundTilemap.HasTile(gridPosition) || colliisionTilemap.HasTile(gridPosition)) {
            return false;
        }
        return true;

    }

}
