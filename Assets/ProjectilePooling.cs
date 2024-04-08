using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ProjectilePooling : MonoBehaviour
{
    GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        ObjectPool<GameObject> projectilePool = new ObjectPool<GameObject>(CreateNewProjectile,OnProjectileRetrieved,OnProjectileReleased);
    }

    private GameObject CreateNewProjectile()
    {
        GameObject newProjectile = GameObject.Instantiate(projectilePrefab);
        newProjectile.SetActive(false);
        return newProjectile;
    }

    void OnProjectileRetrieved(GameObject projectile)
    {
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
