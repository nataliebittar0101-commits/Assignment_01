using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 50;

    public void SetCoin(int newValue, Color newColor)
    {
        value = newValue;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = newColor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager manager =
                FindFirstObjectByType<CoinManager>();

            manager.CollectCoin(value);

            Destroy(gameObject);
        }
    }
}