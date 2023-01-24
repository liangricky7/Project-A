using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap colliisionTilemap;
    [SerializeField]
    private Transform parentTransform;

    private PlayerControls playerControls;

    private bool isMoveHeld;
    private float delay = .1f; //delay for coroutine to run
    private InputControl previousInput;

    private void Awake() {
        playerControls = new PlayerControls();
    }

    private void OnEnable() {
        playerControls.Player.Move.started += ctx => StartMovement(ctx.ReadValue<Vector2>());
        playerControls.Player.Move.canceled += ctx => EndMovement();

        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Player.Move.started -= ctx => StartMovement(ctx.ReadValue<Vector2>());
        playerControls.Player.Move.canceled -= ctx => EndMovement();
        playerControls.Disable();
    }


    private void StartMovement(Vector2 direction) {
        isMoveHeld = true;
        StartCoroutine(Move(direction));
    }

    IEnumerator Move(Vector2 direction) {
        if (isMoveHeld) {

        }
        while (isMoveHeld) {
            if (CanMove(direction)) parentTransform.position += (Vector3) direction;
            yield return new WaitForSeconds(delay);
        }
    }

    private void EndMovement() {
        Debug.Log("called");
        if (isMoveHeld) {
            isMoveHeld = false;
        }
    }


    //private void Move(Vector2 direction) {
    //    if (CanMove(direction)) {
    //        parentTransform.position += (Vector3)direction; //note that this works due to the grid understanding each cell is 1x1
    //    }
    //    Debug.Log("moved");
    //}

    private bool CanMove(Vector2 direction) { //checks if we can move to a tile
        Vector3Int gridPosition = groundTilemap.WorldToCell(parentTransform.position + (Vector3)direction); //attemped tile to move to
        if (!groundTilemap.HasTile(gridPosition) || colliisionTilemap.HasTile(gridPosition)) { 
            return false;
        }
        return true;

    }

}
