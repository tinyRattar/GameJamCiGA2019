using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkill : MonoBehaviour
{
    enum HLState
    {
        Idle = 0,
        ShowIn = 1,
        ShowOut = 2
    }


    [SerializeField] Image CDMask;
    [SerializeField] Image HLMask;
    [SerializeField] Text txtNum;
    [SerializeField] bool isCD = false;
    HLState hlState = HLState.Idle;
    [SerializeField] float CDTime = 1f;
    [SerializeField] float timerCD = 0f;
    [SerializeField] float HLTime = 0.2f;
    [SerializeField] float HLTimeOut = 0.5f;
    float timerHL = 0f;

    #region debug
    [SerializeField] bool debugCD = false;
    #endregion

    public void StartCD(float time)
    {
        CDTime = time;
        timerCD = CDTime;
        isCD = true;
    }

    public void SetNum(int num)
    {
        txtNum.text = num.ToString();
    }

    void ShowHighlight()
    {
        hlState = HLState.ShowIn;
        timerHL = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (debugCD)
        {
            StartCD(5f);
            debugCD = false;
        }
        if (isCD)
        {
            timerCD -= Time.deltaTime;
            if (timerCD <= 0)
            {
                timerCD = 0;
                isCD = false;
                ShowHighlight();
            }
            CDMask.fillAmount = timerCD / CDTime;
        }
        if(hlState == HLState.ShowIn)
        {
            timerHL += Time.deltaTime;
            if (timerHL > HLTime)
            {
                timerHL = HLTimeOut;
                hlState = HLState.ShowOut;
            }
            HLMask.color = new Color(1, 1, 1, timerHL / HLTime);
        }else if (hlState == HLState.ShowOut)
        {
            timerHL -= Time.deltaTime;
            if (timerHL <= 0)
            {
                timerHL = 0f;
                hlState = HLState.Idle;
            }
            HLMask.color = new Color(1, 1, 1, timerHL / HLTimeOut);
        }
    }
}
