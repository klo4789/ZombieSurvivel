using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 500f;

    float xRotation = 0;
    float yRotation = 0;

    public float topClamp = -90f;
    public float bottomClamp = 90f;

    void Start()
    {
        //커서를 화면 중앙에 고정하고 보이지 않게 만들기
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //마우스 입력값 가져오기
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //X축 회전 (위,아래)
        xRotation -= mouseY;

        //회전값 제한
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        //Y축 회전 (좌,우)
        yRotation += mouseX;

        //회전값을 transform 에 적용
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
