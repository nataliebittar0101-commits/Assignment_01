using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    private Rigidbody2D rb;
    private CoinManager manager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        manager = FindFirstObjectByType<CoinManager>();
    }

    void FixedUpdate()
    {
        if (manager.GameEnded)
            return;

        Vector2 direction =
            ((Vector2)player.position - rb.position).normalized;

        rb.MovePosition(
            rb.position + direction * speed * Time.fixedDeltaTime
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            manager.LoseGame();
        }
    }
}