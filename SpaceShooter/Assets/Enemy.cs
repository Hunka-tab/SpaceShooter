using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public int health = 10;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 1.5f;
    private float nextFireTime;
    private float direction = 1; // Kierunek poruszania

    void Update()
    {
        Move();
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Move()
    {
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);

        if (transform.position.x > 3f) direction = -1; // Odbicie od prawej krawêdzi
        if (transform.position.x < -3f) direction = 1; // Odbicie od lewej krawêdzi
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
