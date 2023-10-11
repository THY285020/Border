using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{
    private float HP = 100;
    private Animator m_animator;
    private bool behurted = false;
    private bool death = false;
    //public Animator death_animator;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            //Vector2 p = collision.ClosestPoint(transform.position);
            Vector2 p = transform.position - collision.GetComponent<Transform>().parent.position;
            p.y = p.y - 0.638f;
            //Vector2 oriention = new Vector2(transform.position.x, transform.position.y) - p;
          
            Rigidbody2D rd = GetComponent<Rigidbody2D>();
            float originSpeed = GetComponent<EnemyAttack>().flySpeed;
            IEnumerator duringTime = DuringTime(rd, originSpeed);//攻击附加的位移仅持续一定时间
            //StartCoroutine(duringTime);
            if (collision.name == "Attack1")
            {
                if(Hurt(10, duringTime))
                {
                    print("Damage: 10");
                    //rd.AddForce(p * 10);
                    rd.velocity = (p);
                }

            }
            else if (collision.name == "Attack2")
            {
                if(Hurt(6, duringTime))
                {
                    print("Damage: 6");
                    //rd.AddForce(p * 6);
                    rd.velocity = (p * 0.6f);
                }
            }
            else if (collision.name == "Attack3")
            {
                //Hurt(12, duringTime);
                //print("Damage: 12");
                ////rd.AddForce(p * 12);
                //rd.velocity = (p*1.2f);
                if (Hurt(12, duringTime))
                {
                    print("Damage: 12");
                    //rd.AddForce(p * 6);
                    rd.velocity = (p * 1.2f);
                }
            }
            
            m_animator.SetTrigger("Hurt");
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag == "Weapon")
    //    {
    //        if (collision.collider.name == "Attack1")
    //        {
    //            Hurt(10);
    //            print("Damage: 10");

    //        }
    //        else if (collision.collider.name == "Attack2")
    //        {
    //            Hurt(6);
    //            print("Damage: 6");

    //        }
    //        else if (collision.collider.name == "Attack3")
    //        {
    //            Hurt(12);
    //            print("Damage: 12");
    //        }
    //        m_animator.SetTrigger("Hurt");
    //    }

    //}

    //扣血并显示动画
    bool Hurt(float damage, IEnumerator duringTime)
    {
        HP -= damage;
        if(HP > 0)
        {
            StartCoroutine(duringTime);
            return true;
        }
        else //HP<=0
        {
            death = true;
            //GetComponent<EnemyAttack>().Hover();
            m_animator.SetTrigger("Death");
            IEnumerator Death_I = Death();
            StartCoroutine(Death_I);
            return false;
        }

    }


    IEnumerator DuringTime(Rigidbody2D rd, float originSpeed)
    {
        GetComponent<EnemyAttack>().flySpeed = 0.0f;
        behurted = true;
        yield return new WaitForSecondsRealtime(0.5f);
        if(behurted && !death)
        {
            rd.velocity = (new Vector2(0.0f, 0.0f));
            GetComponent<EnemyAttack>().flySpeed = 1.1f;
            behurted = false;
        }
    }
    IEnumerator Death()
    {
        GetComponent<EnemyAttack>().flySpeed = 0.0f;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        yield return new WaitForSecondsRealtime(1.1f);
        Destroy(gameObject);
    }
}
