using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPChange : MonoBehaviour
{
    // Start is called before the first frame update
    public float Total_HP = 1000;
    public float HP;
    public Slider slider;
    public Text text;
    public Image image;
    private float HPpercent;
    public HeroKnight hero;
    void Start()
    {
        HPpercent = HP / Total_HP;
    }

    // Update is called once per frame
    void Update()
    {
        if(HPpercent != HP / Total_HP)
        {
            HPchanged();
        }

    }

    public void ReGenerate()
    {
        HP = Total_HP;
    }

    public void Decrease()
    {
        if (HP <= 0)
        {
            hero.Death();
            return;
        }
            HP -= 100;
    }

    void HPchanged()
    {
        HPpercent = HP / Total_HP;
        HPpercent = HPpercent >= 0.0f ? HPpercent : 0.0f;
        slider.value = HPpercent;
        text.text = HP.ToString();

        if (HP <= 0) hero.Death();

        if(HPpercent >= 0.5f)
        {
            image.color = Color.green;
        }
        else if (HPpercent <= 0.5f && HPpercent >= 0.2f)
        {
            image.color = Color.yellow;//255, 165, 0, 255
        }
        else if (HPpercent <= 0.2f)
        {
            image.color = Color.red;
        }
    }

    IEnumerator HPdecreaseUI()
    {
        yield return new WaitForSeconds(1);

    }
}

