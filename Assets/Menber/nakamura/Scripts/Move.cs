using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Move : MonoBehaviour
{
    [SerializeField, Foldout("�|�C���g"), Label("���[")]
    private Vector2 leftEdge;
    [SerializeField, Foldout("�|�C���g"), Label("�E�[")]
    private Vector2 rightEdge;
    [SerializeField, Label("�X�s�[�h")]
    private float moveSpeed = 1.0f;
    //����
    private int direction = 1;

    void FixedUpdate()
    {
        //�����]��
        if (transform.position.x >= rightEdge.x)
            direction = -1;
        if (transform.position.x <= leftEdge.x)
            direction = 1;
        //�ړ�
        transform.position = new Vector2(transform.position.x + moveSpeed * Time.fixedDeltaTime * direction, 0);
    }
}
