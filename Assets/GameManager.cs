using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text distanceText;

    private float distance = 0;
    private bool isPlaying = true;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateDistance());
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

    void CheckWin()
    {
        if (distance >= 1000)
        {
            SceneManager.LoadScene(2);
        }
    }
}
