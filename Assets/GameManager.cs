using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text distanceText;
    [SerializeField] private GameObject pickupPrefab;

    private float distance = 0;
    private bool isPlaying = true;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateDistance());
        StartCoroutine(GeneratePickup());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator UpdateDistance()
    {
        while (isPlaying)
        {
            distance += 1f;
            distanceText.text = distance.ToString("F0");
            CheckWin();
            yield return new WaitForSeconds(0.2f);
        }    
    }

    IEnumerator GeneratePickup()
    {
        while (isPlaying)
        {
            Instantiate(pickupPrefab, new Vector3(9, Random.Range(-4f, 5f), 0.0f), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }

    void CheckWin()
    {
        if (distance >= 200)
        {
            isPlaying = false;
            SceneManager.LoadScene(2);
        }
    }

    public void AddDistance(float amount)
    {
        distance += amount;
    }
}
