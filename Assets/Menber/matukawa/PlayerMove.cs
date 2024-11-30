using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    protected float speed = 3.0f;
    private bool _isGameOver = false;
    public GameObject target;

    private Vector3 mousePosition;
    private Vector3 objPosition;


    private void Start()
    {
        //�X�^�[�g�ʒu�A�^�[�Q�b�g�̍��W�A���x
        //transform.position
        //    = Vector3.MoveTowards(transform.position, target.transform.position, speed);

    }        
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        // ��ʊO�ɏo���Ȃ�
        transform.position = new Vector2(
        //�G���A�w�肵�Ĉړ�����
        Mathf.Clamp(transform.position.x + moveX, -8.5f, 8.5f),
        Mathf.Clamp(transform.position.y + moveY, -100000f, 100000f)
        );

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f;
            objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            this.transform.position = objPosition;
        }

    }
}
