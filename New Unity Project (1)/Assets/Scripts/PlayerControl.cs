using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;
    public bool hasPowerUP = false;
    public GameObject projectilePrefab;
    public GameObject powerupIndicator;
    int ammoCount = 10;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float fowardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.forward * speed * fowardInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
        powerupIndicator.transform.position = transform.position ;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            ammoCount -= 1;
        }
        if (ammoCount == 0)
        {
            Debug.Log("No ammo");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUP"))
        {
            hasPowerUP = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            ammoCount += 5;

        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerUP = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
