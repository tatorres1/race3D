using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraOrbit : MonoBehaviour
{
    private float angle = -90 * Mathf.Deg2Rad;
    public Transform follow;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        if(hor != 0)
        {
            angle += hor * Mathf.Deg2Rad;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 orbit =  new Vector3(
            Mathf.Cos(angle),
            0,
            Mathf.Sin(angle) 
            );
        transform.position = follow.position + orbit * distance;
        
        transform.rotation = Quaternion.LookRotation(follow.position - transform.position);
    }
}
