using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (gameObject.activeSelf)
        {
            Vector3 currentposition = gameObject.transform.position;
            Vector3 newPosition = currentposition + new Vector3(-3f, 0f, 0f);
            gameObject.transform.position = Vector3.Lerp(currentposition, newPosition, Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }

    }
}
