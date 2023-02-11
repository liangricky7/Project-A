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
    [SerializeField]
    private Rigidbody2D rb;

    private PlayerControls playerControls;

    private Vector2 direction;
    [SerializeField]
    private float speed;
    //private bool isMoveHeld;
    //private float delay = .1f; //delay for coroutine to run
    //private InputControl previousInput;

    private void Awake() {
        playerControls = new PlayerControls();
    }

    private void OnEnable() {
        //playerControls.Player.Move.started += ctx => StartMovement(ctx);
        //playerControls.Player.Move.canceled += ctx => EndMovement();
        playerControls.Enable();
    }

    private void OnDisable() {
        //playerControls.Player.Move.started -= ctx => StartMovement(ctx);
        //playerControls.Player.Move.canceled -= ctx => EndMovement();
        playerControls.Disable();
    }

    private void Update() {
        direction = playerControls.Player.Move.ReadValue<Vector2>();
        Debug.Log(parentTransform.position);
    }

    private void FixedUpdate() {
       rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }


    //private void StartMovement(InputAction.CallbackContext ctx) {
    //    isMoveHeld = true;
    //    StartCoroutine(Move(ctx));
    //}

    //IEnumerator Move(InputAction.CallbackContext ctx) {
    //    direction = ctx.ReadValue<Vector2>();
    //    if (isMoveHeld) { //check for directional changes
    //        if (previousInput != null) {
    //            if (previousInput != ctx.control) {
    //                previousInput = ctx.control;
    //            }
    //        } else {
    //            previousInput = ctx.control;
    //        }
    //    }
    //    while (isMoveHeld) {
    //        if (CanMove(direction)) parentTransform.position += (Vector3) direction;
    //        yield return new WaitForSeconds(delay);
    //    }
    //}

    //private void EndMovement() {
    //    Debug.Log("called");
    //    if (isMoveHeld) {
    //        isMoveHeld = false;
    //    }
    //}

    //private bool CanMove(Vector2 direction) { //checks if we can move to a tile
    //    Vector3Int gridPosition = groundTilemap.WorldToCell(parentTransform.position + (Vector3)direction); //attemped tile to move to
    //    if (!groundTilemap.HasTile(gridPosition) || colliisionTilemap.HasTile(gridPosition)) { 
    //        return false;
    //    }
    //    return true;

    //}

}
