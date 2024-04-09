using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof (PlayerInput))]
[RequireComponent(typeof (ProjectilePooling))]
[RequireComponent(typeof(Collision))]

public class Player : MonoBehaviour
{
    private ProjectilePooling thisProjectilePool;

    [SerializeField] private GameManager gameManger;
    // Start is called before the first frame update
    void Start()
    {
        thisProjectilePool = gameObject.GetComponent<ProjectilePooling>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(InputAction.CallbackContext callbackContext)
    {
        gameObject.transform.position += new Vector3(callbackContext.ReadValue<Vector2>().x, callbackContext.ReadValue<Vector2>().y, 0f);
        Debug.Log("Move");
    }

    public void Shoot(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            GameObject shotProjectile = thisProjectilePool.projectilePool.Get();
            StartCoroutine(ProjectileLifetime(shotProjectile));
        }
    }

    private IEnumerator ProjectileLifetime(GameObject projectile)
    {
        float t = 0;
        while (t < 5)
        {
            t += 1f;
            yield return new WaitForSeconds(1.0f);
        }
        thisProjectilePool.projectilePool.Release(projectile);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(typeof(Pickup), out Component component))
        {
            gameManger.AddDistance(20f);
            Debug.Log("Pickup");
        }
    }
}
