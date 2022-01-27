using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject[] _levelsButton = null;

    [SerializeField] private LevelClear _levelClear = null;

    [SerializeField] private CanvasGroup _stage = null;
    
    [SerializeField] private RectTransform screen = null;

    private int _currentLevel;
    private Vector2 stepPositionLevelClear = new Vector2(500,0);
    void Start()
    {
        _currentLevel = 0;//1 уровень
        
        _levelsButton[0].GetComponent<Button>().onClick.AddListener(ClickLevel);
        for (int i = 1; i < _levelsButton.Length; i++)
        {
                _levelsButton[i].GetComponent<Button>().interactable = false;
        }

        _levelClear._clickOK += ComplitLevel;
        screen.Translate(0,1000,0);
        //screen.anchoredPosition += stepPositionLevelClear;
    }

    private void ComplitLevel(int countStars)
    {
        _stage.alpha = 1;
        _levelsButton[_currentLevel].GetComponent<Level>().SetStars(countStars);
        _currentLevel++;
        _levelsButton[_currentLevel].GetComponent<Button>().interactable = true;
        _levelsButton[_currentLevel].GetComponent<Button>().onClick.AddListener(ClickLevel);
        //screen.anchoredPosition -= stepPositionLevelClear;
        screen.Translate(0,1000,0);
    }

    void Update()
    {
        
    }

    public void ClickLevel()
    {
        //screen.anchoredPosition -= stepPositionLevelClear;
        screen.Translate(0,-1000,0);
        _stage.alpha = 0;//lerp
        _levelClear.EnableLevelClear();
    }
}
