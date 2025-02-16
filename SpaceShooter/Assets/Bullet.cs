using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
