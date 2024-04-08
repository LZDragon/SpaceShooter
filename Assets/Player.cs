using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof (PlayerInput))]

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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

    public void Shoot()
    {
        
    }
}
