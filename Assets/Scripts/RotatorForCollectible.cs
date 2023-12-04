using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class RotatorForCollectible : MonoBehaviour
{
    public GameObject Collectible;
    public NavMeshSurface navMeshSurface;
    

    private void Start()
    {
        navMeshSurface = FindObjectOfType<NavMeshSurface>();

        if (navMeshSurface == null)
        {
            Debug.LogError("NavMeshSurface not found in the scene. Make sure you have a NavMeshSurface component in your scene.");
        }

        StartCoroutine(CloneCollectibleRoutine());
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);

    }

    private IEnumerator CloneCollectibleRoutine()
    {
        while (true)
        {
            Kloonaus();
            yield return new WaitForSeconds(2f);
        }
    }

    private void Kloonaus()
    {
        if (navMeshSurface == null)
        {
            Debug.LogError("NavMeshSurface not set. Make sure to assign the NavMeshSurface component in the Inspector.");
            return;
        }

        Vector3 randomNavMeshPosition = RandomNavMeshPosition(20f);

        // Tarkistaa ett‰ on sallittu sijainti
        if (!float.IsInfinity(randomNavMeshPosition.x) &&
            !float.IsInfinity(randomNavMeshPosition.y) &&
            !float.IsInfinity(randomNavMeshPosition.z))
        {
            Instantiate(Collectible, randomNavMeshPosition, Quaternion.identity);
        }

        else
        {
            Debug.LogWarning("V‰‰r‰ paikka");
        }
    }

    //Random spawn sakille navmesh alueelle
    private Vector3 RandomNavMeshPosition(float range)
    {
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, range, NavMesh.AllAreas))
        {
            return hit.position;
        }

        // Return a default position if a valid position is not found
        return Vector3.zero;
    }

}




