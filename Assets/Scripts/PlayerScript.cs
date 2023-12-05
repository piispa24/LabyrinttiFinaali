using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.Rendering;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    bool shoot = false; // Variable for shooting action
    public float bulletSpeed; // Speed of the bullet
    public GameObject bullet; // Drag bullet prefab here
    public Transform shootingPlace; // Drag shooting place here
    public GameObject shootingTarget; // Drag zombie here
    public GameObject player;
    public Transform planeTransform; // Drag plane object here
    public float zombieSpawnInterval = 3f; // Spawn interval for zombies
    private float zombieLastSpawnTime; // Last spawn for zombies
    private int zombiesSpawned = 0; // Counter for the number of zombies spawned
    public TMP_Text spawnFasterText; // Reference to the UI Text component
    private Animator textAnimator; // Reference to Animator component
    public float minSpawnDistanceFromPlayer = 10f;
    //private Animator animator; // Reference to Animator component


    //PIISPA
    public AudioClip shootingSound;  // Audio kun ammutaan

    // Method to trigger the animation
    public void TriggerTextAnimation()
    {
        textAnimator.SetTrigger("SlideDown"); // Trigger the animation
    }


    private void Awake() // Called before Start() to initialize variables
    {
        rb = GetComponent<Rigidbody>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
        zombieLastSpawnTime = Time.time; // Returns time in seconds since start of the game
    }

    // Update is called once per frame
    void Update()
    {
 

        if (Input.GetButtonDown("Fire1")) // Checks if fire button (left mouse or ctrl key) has been pressed
        {
            shoot = true; // If so, sets ammunta to true and fires
            ShootingNoise(transform.position);
            //RecylAnimation();
        }

        if (Time.time - zombieLastSpawnTime >= zombieSpawnInterval) // Checks if enough time has passed since the last zombie was spawned, based on the zombieSpawnInterval variable
        {
            
            spawnZombie(); // If enough time has passed, a zombie is spawned using SpawnZombie() method
            zombieLastSpawnTime = Time.time; // Set the zombieLastSpawnTime to the current time
        }
    }

    private void FixedUpdate() // FixedUpdate is a built-in Unity method that runs at consistent intervals (different from Update(), which runs once per frame). This makes it suitable for physics-related code.
    {
        if (shoot) // Checks if shoot variable is set to true
        {
            shootingAction(); // Calls the shootingAction() method is shoot is true. shootingAction() is responsible for spawning a projectile.
            shoot = false; // Sets ammunta to false, which ensures that only one bullet is fired per button press.
        }
    }

    void shootingAction()
    {
        // Instantiate the bullet at the shootingPlace position and align it with the shootingPlace's rotation
        GameObject bulletSpawn = Instantiate(bullet, shootingPlace.position, shootingPlace.rotation);

        // Set the bullet's velocity to be in the forward direction of the shootingPlace
        // This takes into account the up and down rotation from the player's aim.
        Rigidbody bulletRb = bulletSpawn.GetComponent<Rigidbody>();
        bulletRb.velocity = shootingPlace.forward * bulletSpeed;
    }

    // Coroutine to hide the text after a delay
    IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        spawnFasterText.text = ""; // Clear or hide the text
    }

    void spawnZombie()
    {
        Renderer planeRenderer = planeTransform.GetComponent<Renderer>(); // Obtain plane component using Renderer
        Vector3 planeSize = planeRenderer.bounds.size; // Calculate size using bounds.size

        // Calculate the spawn position within the bounds of the plane
        float randomXposition = Random.Range(-planeSize.x / 2, planeSize.x / 2);
        float randomZposition = Random.Range(-planeSize.z / 2, planeSize.z / 2);

        float yPosition = planeTransform.position.y + 0.5f; // Y-position is slightly above the plane to prevent spawning inside it

        Vector3 spawnPosition = new Vector3(randomXposition, yPosition, randomZposition) + planeTransform.position; // Creates a Vector3 for the spawn position using X Y Z values

        if (Vector3.Distance(player.transform.position, spawnPosition) < minSpawnDistanceFromPlayer) // If the spawn position is too close to the player
        {
            return; // Skip spawning the zombie
        }

        Instantiate(shootingTarget, spawnPosition, Quaternion.identity); // Creates an instance of the spawn object

        zombiesSpawned++; // Increment the zombie counter

        if (zombiesSpawned % 10 == 0) // Check if the number of spawned zombies is a multiple of 10. Drop spawn interval for every 10 zombies spawned
        {
            zombieSpawnInterval = Mathf.Max(zombieSpawnInterval - 0.5f, 1f); // Decrease the interval by 0.5 seconds but don't go below 1 second

            // Display the message
            spawnFasterText.text = "Zombies are spawning faster!";
            StartCoroutine(HideTextAfterDelay(2.8f)); // Hide the text after x seconds
        }
    }

    private void ShootingNoise(Vector3 soundPosition) // Method to play a shooting sound effect
    {
        if (shootingSound != null) // Check if the AudioClip is assigned
        {
            AudioSource.PlayClipAtPoint(shootingSound, soundPosition); // Play the shooting sound at the specified position in the game
        }
    }

    private void SpawnPlayer()
    {
        Renderer planeRenderer = planeTransform.GetComponent<Renderer>(); // Obtain plane component using Renderer
        Vector3 planeSize = planeRenderer.bounds.size; // Calculate size using bounds.size

        // Calculate the spawn position within the bounds of the plane
        float randomXposition = Random.Range(-planeSize.x / 2, planeSize.x / 2);
        float randomZposition = Random.Range(-planeSize.z / 2, planeSize.z / 2);
        float yPosition = planeTransform.position.y + 0.5f; // Y-position is slightly above the plane to prevent spawning inside it

        Vector3 spawnPosition = new Vector3(randomXposition, yPosition, randomZposition) + planeTransform.position;

        player.transform.position = spawnPosition; // Move the existing player capsule to the new spawn position
    }

    //public void RecylAnimation()
    //{
    //    animator = GetComponent<Animator>();

    //    if (animator != null)
    //    {
    //        Debug.Log("Playing Recyl animation");
    //        animator.Play("Recyl");
    //    }
    //    else
    //    {
    //        Debug.LogWarning("Animator component not found.");
    //    }
    //}
}
