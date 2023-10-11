using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Body playerBody;
    Vector2 originPos;
    public float searchRadius;
    public float flySpeed;
    public float Timer;
    private int face = -1;
    private bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        float distance = Vector3.Distance(playerBody.transform.position, transform.position);
        if((playerBody.transform.position.x - transform.position.x) * face < 0)
        {
            face *= -1;
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        
        if(distance <= searchRadius && flySpeed > 0)//½øÈë¹¥»÷·¶Î§
        {
            flyAttack(dt);
            attacking = true;
        }
        else if(distance > searchRadius)
        {
            flyOrigin(dt);
            attacking = false;
        }
        attacking = false;
        
    }

    public void Hover()
    {
        flySpeed = 0.0f;
    }

    void flyAttack(float dt)
    {
        transform.position = Vector2.MoveTowards(transform.position, playerBody.GetComponent<Transform>().position + new Vector3(0, 0.638f, 0), flySpeed * dt);
    }

    void flyOrigin(float dt)
    {
        transform.position = Vector2.MoveTowards(transform.position, originPos, flySpeed * dt);

    }
}
