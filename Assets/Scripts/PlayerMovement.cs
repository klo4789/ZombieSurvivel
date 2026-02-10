using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    bool isMoving;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        //그라운드 체크
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //기본속도 리셋
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //입력값 가져오기
        float x = Input.GetAxis("Horizontal"); //좌우 입력 A,D
        float z = Input.GetAxis("Vertical"); // 앞뒤 입력 W,S

        //이동 백터 생성
        Vector3 move = transform.right * x + transform.forward * z; // right 빨간 축 / forward 파란 축

        //실제 플레이어 이동
        controller.Move(move * speed * Time.deltaTime);

        //플레이어가 점프할 수 있는지 확인
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //실제로 점프하기
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //낙하하기
        velocity.y += gravity * Time.deltaTime;

        //점프 실행
        controller.Move(velocity * Time.deltaTime);

        if(lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true; //나중에 사용
        }
        else
        {
            isMoving = false; //나중에 사용
        }

        lastPosition = gameObject.transform.position;
    }
}
