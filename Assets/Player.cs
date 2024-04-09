using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof (PlayerInput))]
[RequireComponent(typeof (ProjectilePooling))]

public class Player : MonoBehaviour
{
    private ProjectilePooling thisProjectilePool;
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
            thisProjectilePool.projectilePool.Get();
        }
    }
}
