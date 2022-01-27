using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelClear : MonoBehaviour
{
    [SerializeField] private GameObject[] emptyStars = null;

    [SerializeField] private GameObject[] fullStars = null;

    [SerializeField] private Button buttonOK = null;

    [SerializeField] private CanvasGroup _canvasGroup = null;

    private int currentFullCount;

    public System.Action<int> _clickOK;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonOK.onClick.AddListener(ClickOk);
        currentFullCount = 0;
    }

    public void EnableLevelClear()
    {
        _canvasGroup.alpha = 1;//lerp
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateStars(1);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateStars(2);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateStars(3);
        }
    }
    
    private void ActivateStars(int count)
    {
        for (int i = 0; i < 3; i++)
        {
            if (i < count)
            {
                fullStars[i].SetActive(true);
                emptyStars[i].SetActive(false);
            }
            else
            {
                fullStars[i].SetActive(false);
                emptyStars[i].SetActive(true);
            }
            
        }

        currentFullCount = count;
    }

    private void ClickOk()
    {
        _clickOK?.Invoke(currentFullCount);
        _canvasGroup.alpha = 0;
    }
}
