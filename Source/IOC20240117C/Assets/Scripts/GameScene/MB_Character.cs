using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MB_Character : MonoBehaviour
{
    void Update()
    {
        KeyboardMove();
        MouseMove();
    }

    private void KeyboardMove()
    {
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 vertical = new Vector3(0, Input.GetAxis("Vertical"), 0);
        Vector3 movement = horizontal + vertical;
        //判断方向
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //判断移动状态
        if (movement != Vector3.zero)
        {
            //GetComponent<Animator>().SetBool("isMoving", true);
            movement = transform.TransformDirection(movement);
            movement = movement * Config.Instance.moveSpeed;
            transform.Translate(movement * Time.deltaTime);
        }
        else
        {
            //GetComponent<Animator>().SetBool("isMoving", false);
        }
    }
    
    private void MouseMove()
    {
        if (Input.GetMouseButton(0)) // 鼠标左键按下时
        {
            //获取鼠标位置的世界坐标
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //激活状态机跑步动画
            //GetComponent<Animator>().SetBool("isMoving", true);
            //判断角色方向
            if (mousePos.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (mousePos.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            //移动
            transform.position = Vector3.MoveTowards(transform.position, mousePos, Config.Instance.moveSpeed * Time.deltaTime);
        }
    }
}
