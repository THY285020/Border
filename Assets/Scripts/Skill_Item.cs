using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillItem : MonoBehaviour
{
    public float coldTime = 2;
    private float timer = 0;
    private bool isColding = false;
    private Image coldMask;
    // Start is called before the first frame update
    void Start()
    {
        coldMask = transform.Find("Cold_Mask").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isColding)
        {
            timer += Time.deltaTime;
            coldMask.fillAmount = (coldTime - timer) / coldTime;
        }
        if(timer >= coldTime)
        {
            isColding = false;
            timer = 0;
        }
    }

    public void OnSkillRelease()
    {
        if(isColding == false)
        {
            isColding = true;
            timer = 0;
            coldMask.fillAmount = 1;
        }
    }
}
