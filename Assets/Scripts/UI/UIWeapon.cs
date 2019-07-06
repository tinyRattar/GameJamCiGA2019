using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeapon : MonoBehaviour
{
    [SerializeField] Image mask;
    [SerializeField] float switchTime = 0.5f;
    Image image;
    Vector3 sourcePos;
    Vector3 targetPos;
    Color sourceColor;
    Color targetColor;
    Vector3 sourceScale;
    Vector3 targetScale;
    float timerSwitch = 0f;
    bool onSwitch = false;
    

    public void StartSwitch(Vector3 tarPos, bool toEnable)
    {
        sourcePos = this.transform.position;
        targetPos = tarPos;
        if (toEnable)
        {
            targetColor = new Color(0.5f, 0.5f, 0.5f, 0f);
            targetScale = new Vector3(1.4f, 1.4f, 1f);
        }
        else
        {
            targetColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
            targetScale = new Vector3(1f, 1f, 1f);
        }
        sourceColor = mask.color;
        sourceScale = this.transform.localScale;
        timerSwitch = switchTime;
        onSwitch = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onSwitch)
        {
            timerSwitch -= Time.deltaTime;
            if(timerSwitch <= 0)
            {
                timerSwitch = 0;
                onSwitch = false;
            }
            this.transform.position = Vector3.Lerp(sourcePos, targetPos, 1 - timerSwitch / switchTime);
            mask.color = Color.Lerp(sourceColor, targetColor, 1 - timerSwitch / switchTime);
            this.transform.localScale = Vector3.Lerp(sourceScale, targetScale, 1 - timerSwitch / switchTime);
        }
    }
}
