using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Tilemaps;
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap colliisionTilemap;
    [SerializeField]
    private Transform parentTransform;

    private PlayerControls playerControls;
    private ButtonControl buttonControl0,buttonControl1,buttonControl2,buttonControl3;
    

    private void Awake() {
        playerControls = new PlayerControls();

        buttonControl0 = (ButtonControl)playerControls.Player.Move.controls[0];
        buttonControl1 = (ButtonControl)playerControls.Player.Move.controls[1];
        buttonControl2 = (ButtonControl)playerControls.Player.Move.controls[2];
        buttonControl3 = (ButtonControl)playerControls.Player.Move.controls[3];
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Update() {
        //playerControls.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>()); //every time we press the movement keys we tell our move function how we wanna move
        
        if (isMoving()){
            Debug.Log("moving");
            Move(playerControls.Player.Move.ReadValue<Vector2>());
        }

 
    }

    private bool isMoving(){
        if (buttonControl0.isPressed | buttonControl1.isPressed |buttonControl2.isPressed| buttonControl3.isPressed){
            return true;
        }
        return false;
    }

    private void Move(Vector2 direction) {
        if (CanMove(direction)) {
            parentTransform.position += (Vector3)direction; //note that this works due to the grid understanding each cell is 1x1
        }
        Debug.Log("moved");
    }

    private bool CanMove(Vector2 direction) { //checks if we can move to a tile
        Vector3Int gridPosition = groundTilemap.WorldToCell(parentTransform.position + (Vector3)direction); //attemped tile to move to
        if (!groundTilemap.HasTile(gridPosition) || colliisionTilemap.HasTile(gridPosition)) { 
            return false;
        }
        return true;

    }

}
