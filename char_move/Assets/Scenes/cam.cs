using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cam : MonoBehaviour
{
    public Transform target;




    Vector3 dis;

    // Start is called before the first frame update
    void Start()
    {
        dis = transform.position - target.position;
      //  Debug.Log(dis);
    }

    // Update is called once per frame
    void Update()
    {
        /* if (target != null)
         {
             Vector3 vec = target.position - transform.position;

             vec.Normalize();
             Quaternion q = Quaternion.LookRotation(vec);
             transform.rotation = q;
         }
         */
        Vector3 target_pos = target.position + dis;
       
        transform.position = Vector3.Lerp(transform.position, target_pos, Time.deltaTime); //(카메라, 캐릭터, 속도)
        

    }
    public void Set_dis()
    {
        dis = transform.position - target.position;
    }
    private int a;
    public int b;
    public void he()
    {
        a = 10;
    }

}
