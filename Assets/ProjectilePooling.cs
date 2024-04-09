using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ProjectilePooling : MonoBehaviour
{
    public GameObject projectilePrefab;

    public ObjectPool<GameObject> projectilePool;
    // Start is called before the first frame update
    void Start()
    {
        projectilePool = new ObjectPool<GameObject>(CreateNewProjectile,OnProjectileRetrieved,OnProjectileReleased);
    }

    private GameObject CreateNewProjectile()
    {
        GameObject newProjectile = GameObject.Instantiate(projectilePrefab);
        newProjectile.SetActive(false);
        return newProjectile;
    }

    void OnProjectileRetrieved(GameObject projectile)
    {
        projectile.gameObject.transform.position = gameObject.transform.position;
        projectile.SetActive(true);
        
        
    }

    void OnProjectileReleased(GameObject projectile)
    {
        projectile.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
