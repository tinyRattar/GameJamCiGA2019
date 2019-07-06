using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PortalMissionManager : MonoBehaviour
{
    public static PortalMissionManager Instance;
    [SerializeField] int numRemain = 11;
    [SerializeField] Text text;
    [SerializeField] Text text2;
    bool finished = false;

    public void NumChange(int value)
    {
        numRemain += value;
        text.text = numRemain.ToString();
        text2.text = numRemain.ToString();
        if (numRemain <= 0 && !finished)
        {
            Debug.Log("Level Clear");
            SceneManager.LoadScene(2);
            finished = true;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("More Than two instance");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
