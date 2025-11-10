using UnityEngine;

public class GameArenaHandler : MonoBehaviour
{
    [SerializeField]
    private Enemy enemyPrefab;
    [SerializeField]
    private Player playerInstance;
    [SerializeField]
    private int enemiesToSpawn = 1000;

    void Awake()
    {
        Vector2 arenaSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        SpawnEnemies(arenaSize);
        SpawnArenaBoundariesColliders(arenaSize);
    }

    private void SpawnEnemies(Vector2 arenaSize)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Vector2 spawnPosition = new Vector2(
                Random.Range(-arenaSize.x, arenaSize.x),
                Random.Range(-arenaSize.y, arenaSize.y)
            );
            Enemy enemySpawned = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemySpawned.Player = playerInstance;
        }
    }

    private void SpawnArenaBoundariesColliders(Vector2 arenaSize)
    {
        int boxThickness = 1;
        GameObject boundaries = new GameObject("Arena Boundaries");
        BoxCollider2D topBoundary = boundaries.AddComponent<BoxCollider2D>();
        topBoundary.size = new Vector2(arenaSize.x * 2, boxThickness);
        topBoundary.offset = new Vector2(0, arenaSize.y + boxThickness / 2f);

        BoxCollider2D bottomBoundary = boundaries.AddComponent<BoxCollider2D>();
        bottomBoundary.size = new Vector2(arenaSize.x * 2, boxThickness);
        bottomBoundary.offset = new Vector2(0, -arenaSize.y - boxThickness / 2f);

        BoxCollider2D leftBoundary = boundaries.AddComponent<BoxCollider2D>();
        leftBoundary.size = new Vector2(boxThickness, arenaSize.y * 2);
        leftBoundary.offset = new Vector2(-arenaSize.x - boxThickness / 2f, 0);

        BoxCollider2D rightBoundary = boundaries.AddComponent<BoxCollider2D>();
        rightBoundary.size = new Vector2(boxThickness, arenaSize.y * 2);
        rightBoundary.offset = new Vector2(arenaSize.x + boxThickness / 2f, 0);
    }
}
