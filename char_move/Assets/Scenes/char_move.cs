using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_move : MonoBehaviour
{
    private Vector3 moveVec;

    private float hAxis, vAxis;
    public float speed = 20.0f;

    public Animator anim;
    public Rigidbody ri;
    public Vector3 vector;
    public Quaternion newRotation; //벡터(x,y,z)와 스칼라(w)로 구성. 


    void Awake()
    {
        ri = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal"); //0~1
        vAxis = Input.GetAxisRaw("Vertical");
        //*만약 shift와 같은 버튼값을 받으려면 GetButton()사용.

        //캐릭터 이동
        vector.Set(hAxis, 0, vAxis); //x,y,z를 설정.
        vector = vector.normalized * speed * Time.deltaTime; //normalized 0,1로 정규화 
        ri.MovePosition(transform.position + vector);  //이동 포지션으로도 가능하지만 rigidbody랑 충돌될 수 있음. 
        //리지드바디로 이동할 때는 터레인과 같은 곳에서 물리적용이 되어 알아서 계산해줌. 딱히 따로 안건드려도 리지트바디를 적용하면 알어서 해줌. 
        //캐릭터 애니메이션
        anim.SetBool("Moving", vector != Vector3.zero);

        //캐릭터 회전
        newRotation = Quaternion.LookRotation(vector); 
        //원래 V1과 새로 들어온 V2(키보드 입력)를 뺄셈을 해서 사이의 벡터에서 방향을 구함. 쿼터니언은 방향만 가짐.
        
        //지정된 upwards와 upwards 방향들과 함께 rotation을 생성합니다.???? Quaternion반환
        
        
        if (vector != Vector3.zero) 
        {   
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 10f * Time.deltaTime);
            //( , , 속도) 값을 넣어 회전을 하는 함수.
            //transform.rotation과 newRotation사이를 Time.deltaTime로 구형보간(두 점 사이 가장 짧은 호)함. ????

            //transform.rotation = Quaternion.Lerp(newRotation, transform.rotation, Time.deltaTime);
        }
    }

}
 