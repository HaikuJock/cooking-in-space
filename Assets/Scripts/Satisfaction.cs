using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Satisfaction : MonoBehaviour
{
    public static int Score;
    [SerializeField] private Slider satisfactionDisplay;
    [SerializeField] private int maxSatisfaction = 1000;
    [SerializeField] private float timeBetweenSatisfactionLoss = 1f;
    private bool _canReduce;

    private void Start()
    {
        Score = Mathf.RoundToInt(maxSatisfaction / 2);
        satisfactionDisplay.maxValue = maxSatisfaction;
        _canReduce = true;
    }
    
    private void Update()
    {
        satisfactionDisplay.value = Score;
        if (_canReduce)
            StartCoroutine(ReduceSatisfaction());
        if (Score >= maxSatisfaction)
        {
            SceneManager.LoadScene("GameClear");
        }

        if (Score <= 0)
        {
            SceneManager.LoadScene("GameFail");
        }
    }

    private IEnumerator ReduceSatisfaction()
    {
        _canReduce = false;
        Score--;
        yield return new WaitForSeconds(timeBetweenSatisfactionLoss);
        _canReduce = true;

    }
}
