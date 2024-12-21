using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Teleport : MonoBehaviour
{
    [SerializeField, Label("�e���|�[�g�̏o��")]
    private GameObject teleportExitPos;
    [SerializeField, Tag, Label("�Փ˂������e���|�[�g����Ώۂ̃^�O")]
    private string teleportTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ΏۂƏՓ˂�����
        if(collision.gameObject.CompareTag(teleportTag))
        {
            //�w��ꏊ�ɋ����ړ�������
            collision.gameObject.transform.position = teleportExitPos.transform.position;
        }
    }
}
