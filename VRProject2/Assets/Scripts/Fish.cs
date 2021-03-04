using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    bool hasTarget = false;
    Vector3 target;
   
    
    [SerializeField]
    float turnSpeed = 2;
    [SerializeField]
    float moveSpeed = 5;
    [SerializeField]
    AudioClip sBubble;

    bool ishit;

    AudioSource fx;
    // Start is called before the first frame update
    void Start()
    {
        fx = GameObject.FindGameObjectWithTag("FX").GetComponent<AudioSource>();
        fx.PlayOneShot(sBubble);
    }

  
    // Update is called once per frame
    void Update()
    {
        if (hasTarget)
        {
            rotateTowards(target);
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed);
        }
        
    }

    public void SetTarget(Vector3 position)
    {
        target = position;
        hasTarget = true;

    }

    
    protected void rotateTowards(Vector3 to)
    {

        Quaternion lookRotation =
            Quaternion.LookRotation((to - transform.position).normalized);

        //over time
        transform.rotation =
            Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void miss()
    {
        StartCoroutine(SelfDestruct());
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Turtle")
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(.5f);   //hardcoded, fix when needed
        Destroy(this.gameObject);
    }


    }
