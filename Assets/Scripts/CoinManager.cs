
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public int coinsPerBatch = 5;

    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -4f;
    public float maxY = 4f;

    public Color orangeColor = new Color(1f, 0.5f, 0f);
    public Color greenColor = Color.green;
    public Color blueColor = Color.blue;

    public int orangeValue = 50;
    public int greenValue = 20;
    public int blueValue = 10;

    public int targetScore = 1000;

    private int totalScore = 0;
    private int coinsCollected = 0;
    private bool gameEnded = false;

    public bool GameEnded
    {
        get { return gameEnded; }
    }

    void Start()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        for (int i = 0; i < coinsPerBatch; i++)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);

            Vector3 position = new Vector3(x, y, 0f);

            GameObject newCoin = Instantiate(
                coinPrefab, position, Quaternion.identity
            );

            int type = Random.Range(0, 3);
            Coin coin = newCoin.GetComponent<Coin>();

            if (type == 0)
                coin.SetCoin(orangeValue, orangeColor);
            else if (type == 1)
                coin.SetCoin(greenValue, greenColor);
            else
                coin.SetCoin(blueValue, blueColor);
        }
    }

    public void CollectCoin(int points)
    {
        if (gameEnded)
            return;

        totalScore += points;
        coinsCollected++;

        Debug.Log("Score: " + totalScore);

        if (totalScore >= targetScore)
        {
            gameEnded = true;
            Debug.Log("you won");
        }
        else if (coinsCollected == coinsPerBatch)
        {
            coinsCollected = 0;
            SpawnCoins();
        }
    }

    public void LoseGame()
    {
        if (gameEnded)
            return;

        gameEnded = true;
        Debug.Log("you lose");
    }
}
