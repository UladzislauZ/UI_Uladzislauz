using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject[] _starsFull = null;
    [SerializeField] private GameObject[] _starsEmpty = null;

    public void SetStars(int countFullStars)
    {
        for (int i = 0; i < countFullStars; i++)
        {
            _starsFull[i].SetActive(true);
            _starsEmpty[i].SetActive(false);
        }
    }
}
