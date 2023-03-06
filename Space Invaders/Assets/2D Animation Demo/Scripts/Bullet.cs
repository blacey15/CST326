using System;
using UnityEngine;

// Technique for making sure there isn't a null reference during runtime if you are going to use get component
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public Vector3 dir;
    public float speed;
    public System.Action destroyed;
    private PointManager pointManager;

   void Start()
   {
       pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
   }

    //-----------------------------------------------------------------------------
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    //-----------------------------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (destroyed != null)
        {
            destroyed.Invoke();
        }
        if (col.gameObject.CompareTag("Invader"))
        {
            pointManager.updateScore(10);
        }
        if (col.gameObject.CompareTag("Invader2"))
        {
            pointManager.updateScore(20);
        }
        if (col.gameObject.CompareTag("Invader3"))
        {
            pointManager.updateScore(30);
        }
        Destroy(gameObject);
    }
}
