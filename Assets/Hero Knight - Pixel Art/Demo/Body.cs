using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public HeroKnight Hero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Hero.OnCollisionEnterProxy(GetComponent<Collider2D>(), collision);
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            Rigidbody2D rd = GetComponent<Transform>().parent.GetComponent<Rigidbody2D>();
            Vector2 mp = transform.position;
            mp += new Vector2(0, 0.638f);
            Vector2 oriention = mp - new Vector2(collision.transform.position.x, collision.transform.position.y);
            rd.velocity = oriention;
        }    

        Hero.OnCollisionEnterProxy(GetComponent<Collider2D>(), collision.collider);
    }
}
