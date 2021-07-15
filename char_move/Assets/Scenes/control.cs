using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class control : MonoBehaviour,IBeginDragHandler,IDragHandler
{
    public GameObject cam;
    public Transform target;
    Vector3 pos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        pos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {

        cam.transform.RotateAround(target.position, Vector3.down, pos.x - eventData.position.x);
        pos = eventData.position;
        cam.GetComponent<cam>().Set_dis();
        cam.GetComponent<cam>().he(); //접근가능.
        cam.GetComponent<cam>().b = 10;

    }

   
}
