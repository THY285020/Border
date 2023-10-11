using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private int size;
    private Vector2[] PointsR;
    private Vector2[] PointsL;
    private int face = 1;
    public HeroKnight Hero;
    // Start is called before the first frame update
    void Start()
    {
        size = GetComponent<PolygonCollider2D>().GetTotalPointCount();
        PointsR = GetComponent<PolygonCollider2D>().points;
        PointsL = new Vector2[size];
        if(size == 20)
        {
            PointsL[0] = new Vector2(0.394f, 0.985f);
            PointsL[1] = new Vector2(0.538f, 1.029f);
            PointsL[2] = new Vector2(0.997f, 1.02088f);
            PointsL[3] = new Vector2(1.43097f, 0.842f);
            PointsL[4] = new Vector2(1.514f, 0.793f);
            PointsL[5] = new Vector2(1.456f, 0.764f);
            PointsL[6] = new Vector2(0.966f, 0.704f);
            PointsL[7] = new Vector2(0.645f, 0.500f);
            PointsL[8] = new Vector2(0.564f, 0.308f);
            PointsL[9] = new Vector2(0.561f, 0.061f);
            PointsL[10] = new Vector2(0.486f, -0.148f);
            PointsL[11] = new Vector2(0.469f, -0.1659f);
            PointsL[12] = new Vector2(0.423f, -0.341f);
            PointsL[13] = new Vector2(0.3039f, -0.573f);
            PointsL[14] = new Vector2(-0.164f, -0.377f);
            PointsL[15] = new Vector2(-0.525f, -0.0639f);
            PointsL[16] = new Vector2(-0.4579f, 0.247f);
            PointsL[17] = new Vector2(-0.3379f, 0.4610f);
            PointsL[18] = new Vector2(0.065f, 0.802f);
            PointsL[19] = new Vector2(0.189f, 0.866f);
        }
        else if(size == 23)
        {
            PointsL[0] = new Vector2(0.320f, 0.646f);
            PointsL[1] = new Vector2(0.464f, 0.665f);
            PointsL[2] = new Vector2(0.922f, 0.649f);
            PointsL[3] = new Vector2(0.960f, 0.652f);
            PointsL[4] = new Vector2(1.084f, 0.578f);
            PointsL[5] = new Vector2(1.464f, 0.425f);
            PointsL[6] = new Vector2(1.0408f, 0.481f);
            PointsL[7] = new Vector2(0.645f, 0.500f);
            PointsL[8] = new Vector2(0.424f, 0.391f);
            PointsL[9] = new Vector2(0.239f, 0.284f);
            PointsL[10] = new Vector2(0.1895f, 0.0335f);
            PointsL[11] = new Vector2(0.188f, -0.172f);
            PointsL[12] = new Vector2(0.1938f, -0.116f);
            PointsL[13] = new Vector2(0.473f, -0.217f);
            PointsL[14] = new Vector2(0.658f, -0.279f);
            PointsL[15] = new Vector2(0.672f, -0.360f);
            PointsL[16] = new Vector2(0.6779f, -0.4319f);
            PointsL[17] = new Vector2(-0.164f, -0.406f);
            PointsL[18] = new Vector2(-0.583f, 0.084f);
            PointsL[19] = new Vector2(-0.4579f, 0.247f);
            PointsL[20] = new Vector2(-0.321f, 0.452f);
            PointsL[21] = new Vector2(-0.198f, 0.521f);
            PointsL[22] = new Vector2(0.040f, 0.585f);
        }
        else if(size == 22)
        {
            PointsL[0] = new Vector2(0.394f, 0.985f);
            PointsL[1] = new Vector2(0.564f, 0.978f);
            PointsL[2] = new Vector2(1.022f, 1.0038f);
            PointsL[3] = new Vector2(1.4309f, 0.842f);
            PointsL[4] = new Vector2(1.5139f, 0.793f);
            PointsL[5] = new Vector2(1.456f, 0.764f);
            PointsL[6] = new Vector2(0.966f, 0.704f);
            PointsL[7] = new Vector2(0.645f, 0.500f);
            PointsL[8] = new Vector2(0.564f, 0.308f);
            PointsL[9] = new Vector2(0.502f, 0.0019f);
            PointsL[10] = new Vector2(0.486f, -0.148f);
            PointsL[11] = new Vector2(0.469f, -0.1659f);
            PointsL[12] = new Vector2(0.474f, -0.571f);
            PointsL[13] = new Vector2(-0.107f, -0.820f);
            PointsL[14] = new Vector2(-0.4879f, -0.556f);
            PointsL[15] = new Vector2(-0.594f, -0.354f);
            PointsL[16] = new Vector2(-0.619f, -0.0809f);
            PointsL[17] = new Vector2(-0.648f, 0.189f);
            PointsL[18] = new Vector2(-0.551f, 0.3409f);
            PointsL[19] = new Vector2(-0.414f, 0.588f);
            PointsL[20] = new Vector2(0.065f, 0.802f);
            PointsL[21] = new Vector2(0.189f, 0.866f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeDirection()
    {
        if(face == 1)
        {
            GetComponent<PolygonCollider2D>().points = PointsL;
            GetComponent<PolygonCollider2D>().offset = new Vector2(-2.0f, 0.0f);
            face = -1;
        }
        else if(face == -1)
        {
            GetComponent<PolygonCollider2D>().points = PointsR;
            GetComponent<PolygonCollider2D>().offset = new Vector2(0.0f, 0.0f);
            face = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hero.OnCollisionEnterProxy(GetComponent<Collider2D>(), collision);
       
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Hero.OnCollisionEnterProxy(GetComponent<Collider2D>(), collision);
    //}
}
