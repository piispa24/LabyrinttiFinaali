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
        navMeshSurface = FindObjectOfType<NavMeshSurface>(); //etsii navmeshin

        if (navMeshSurface == null) //tarkastaa että navmesh löytyy
        {
            Debug.LogError("NavMeshSurface not found in the scene.");
        }

        StartCoroutine(CloneCollectibleRoutine()); //aloittaa säkkien kloonauksen navmesh alueelle
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);  //säkkien liike koodi

    }

    private IEnumerator CloneCollectibleRoutine()
    {
        while (true)
        {
            Kloonaus();
            yield return new WaitForSeconds(2f); //kloona 2 sekunnin välein
        }
    }

    private void Kloonaus() //Kloonaus koodi
    {
        if (navMeshSurface == null)
        {
            Debug.LogError("NavMeshSurface not set.");
            return;
        }

        Vector3 randomNavMeshPosition = RandomNavMeshPosition(20f);

        // Tarkistaa että on sallittu sijainti
        if (!float.IsInfinity(randomNavMeshPosition.x) &&
            !float.IsInfinity(randomNavMeshPosition.y) &&
            !float.IsInfinity(randomNavMeshPosition.z))
        {
            Instantiate(Collectible, randomNavMeshPosition, Quaternion.identity);
        }

        else
        {
            Debug.LogWarning("Väärä paikka");  //debuggausta
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

        // palaa peruspaikkaan jos ei löydy
        return Vector3.zero;
    }

}




