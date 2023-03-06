using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs;
    public int rows = 5;

    public int cols = 11;
    public float spacing = 0.5f;
    public int enemiesKilled { get; private set; }
    public int totalEnemies => rows * cols;
    public int enemiesAlive => totalEnemies - enemiesKilled;
    public float percentKilled => (float)enemiesKilled/(float)totalEnemies;
    public AnimationCurve speed;
    public float enemyAttackRate = 1.5f;
    public Bullet missilePrefab;

    private Vector3 direction = Vector2.right;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int row = 0; row < this.rows; row++)
        {
            float w = spacing * (cols - 1);
            float h = spacing * (rows - 1);
            Vector2 center = new Vector2(-w/2, -h/2);
            Vector3 rowPos = new Vector3(center.x, center.y + (row * spacing), 0f);
            for (int col = 0; col < cols; col++)
            {
                Invader invader = Instantiate(prefabs[row], transform);
                invader.killed += enemyKilled;
                Vector3 pos = rowPos;
                pos.x += col * spacing;
                invader.transform.localPosition = pos;
            }
        }
        InvokeRepeating(nameof(enemyAttack), enemyAttackRate,enemyAttackRate);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed.Evaluate(percentKilled) * Time.deltaTime;
        Vector3 leftWall = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightWall = Camera.main.ViewportToWorldPoint(Vector3.right);
        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (direction == Vector3.right && invader.position.x >= rightWall.x - .3f)
            {
                NextRow();
            }
            else if (direction == Vector3.left && invader.position.x <= leftWall.x + .3f)
            {
                NextRow();
            }
        }
    }

    private void enemyAttack()
    {
        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (Random.value < (1f/(float)enemiesAlive))
            {
                Instantiate(missilePrefab, invader.position, Quaternion.identity);
                break;
            }
        }
    }

    private void NextRow()
    {
        direction.x *= -1f;
        Vector3 pos = transform.position;
        pos.y -= .2f;
        transform.position = pos;
    }

    private void enemyKilled()
    {
        enemiesKilled++;
    }
}
