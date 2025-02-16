using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
