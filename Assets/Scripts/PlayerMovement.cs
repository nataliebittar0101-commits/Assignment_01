using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private CoinManager manager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        manager = FindFirstObjectByType<CoinManager>();
    }

    void Update()
    {
        if (manager.GameEnded)
        {
            movement = Vector2.zero;
            return;
        }

        float x = 0f;
        float y = 0f;

        if (Keyboard.current.aKey.isPressed) x = -1f;
        if (Keyboard.current.dKey.isPressed) x = 1f;
        if (Keyboard.current.wKey.isPressed) y = 1f;
        if (Keyboard.current.sKey.isPressed) y = -1f;

        movement = new Vector2(x, y).normalized;
    }

    void FixedUpdate()
    {
        if (manager.GameEnded)
            return;

        rb.MovePosition(
            rb.position + movement * speed * Time.fixedDeltaTime
        );
    }
}