using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodCTRL : MonoBehaviour
{
    public GameObject cut;
    public GameObject add;
    public static float bloodChange = 0;
    Image img;
    public static bool flag_cut = false;
    public static bool flag_add = false;
    Vector3 healthPos;
    float length=500;
    RectTransform healthRect;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        img = this.GetComponent<Image>();
        healthRect = this.gameObject.GetComponent<RectTransform>();
        healthPos = this.gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(img.fillAmount>1)
        {
            img.fillAmount = 1;
        }
        else if(img.fillAmount<0)
        {
            img.fillAmount = 0;
        }
        
        if (flag_cut)
        {
            img.fillAmount += bloodChange / 100;
            flag_cut = false;
            healthPos.x += img.fillAmount * length;
            print(healthPos);
            cut.transform.localPosition = healthPos;
            //float newWidth=250
            cut.GetComponent<RectTransform>().sizeDelta = new Vector2(-bloodChange/100*500, 50);
            cut.SetActive(true);
            StartCoroutine(HealthCut());
        }
        if (flag_add)
        {
           
            flag_add = false;
            healthPos.x += img.fillAmount * length;
            print(healthPos);
            add.transform.localPosition = healthPos;
            //float newWidth=250
            if (img.fillAmount+ bloodChange / 100 < 1)
            {
                img.fillAmount += bloodChange / 100;
                add.GetComponent<RectTransform>().sizeDelta = new Vector2(bloodChange / 100 * 500, 50);
            }
            else
            {
   
                add.GetComponent<RectTransform>().sizeDelta = new Vector2((1-img.fillAmount) * 500, 50);
                img.fillAmount = 1;
            }
            add.SetActive(true);
            StartCoroutine(HealthAdd());
        }
        healthPos = this.gameObject.transform.localPosition;
    }
    IEnumerator HealthCut()
    {

        Image imgCut = cut.GetComponent<Image>();
        while (imgCut.fillAmount>0)
        {
            imgCut.fillAmount -= speed;
            yield return 0;
        }
        cut.SetActive(false);
        imgCut.fillAmount = 1;
        
    }
    IEnumerator HealthAdd()
    {

        Image imgAdd = add.GetComponent<Image>();
        while (imgAdd.fillAmount >0)
        {
            imgAdd.fillAmount -= speed;
            yield return 0;
        }
        add.SetActive(false);
        imgAdd.fillAmount = 1;

    }
}
