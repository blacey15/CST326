using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public Bullet laserPrefab;
    private bool bulletActive;
    void Start()
    {
      
    }
    
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (!bulletActive)
        {
            Bullet bullet = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            bullet.destroyed += bulletDestroyed;
            bulletActive = true;
        }
    }

    private void bulletDestroyed()
    {
        bulletActive = false;
    }
}
