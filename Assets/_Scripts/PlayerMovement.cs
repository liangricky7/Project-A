using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
        
    private PlayerControls playerControls;
    private Vector2 move;
    private float speed = 1f;

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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = playerControls.Player.Move.ReadValue<Vector2>().normalized; //gets the input from WASD and puts them into a vector
        Debug.Log(move);
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + move * speed); //moves the player
    }
}
