using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int health = 3;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveX * speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void TakeDamage()
    {
        health--;

        // Aktualizujemy UI zdrowia
        FindObjectOfType<HealthUI>().UpdateHearts();

        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }
}
