using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    // public int hitCounter = 3;
    private AudioSource playerAudio;
    public AudioClip projectileSound; 
    public GameObject projectilePrefab;
    public GameObject powerupIndicator;
    public bool hasPowerup = false;
    //damage value is set to 1 in gui
    public int dmgValue;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(gameManager.isGameActive){
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
            //top down movement on x - z plane
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
            //ensure consistency in all dir
            movement.Normalize();
            transform.Translate(movement * speed * Time.deltaTime, Space.World);

            //rotate toward the mouse pointer
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));
            Vector3 direction = mousePosition - transform.position;

            direction.y = 0; // Ensure no rotation happens in the y-axis

            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            //adjust slerp speed; speed of rotation toward mouse
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 10.0f);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && gameManager.isGameActive) {
            // Launch a projectile from player on press of left mouse button
            // Initially the projectile was destroying the player so i offset its start location not to be within player collider
            Vector3 projectileOffset = new Vector3(0.0f, 0.0f, 1.0f);
            Vector3 spawnPosition = transform.position + transform.forward * projectileOffset.z;
            Instantiate(projectilePrefab, spawnPosition, transform.rotation);
            playerAudio.PlayOneShot(projectileSound, 1.0f);
        }
    }

    //OnCollisionEnter if a non-trigger collider is involved in the collision
    private void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.CompareTag("Enemy")) {
            gameManager.UpdateHealth(dmgValue);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Powerup")){
            hasPowerup = true;
            //** play power up sound
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            //starts PowerupCoundown
            StartCoroutine(PowerupCoundown());
        }
    }

    IEnumerator PowerupCoundown() {
        yield return new WaitForSeconds(8);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}



