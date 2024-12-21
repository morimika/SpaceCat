using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Teleport : MonoBehaviour
{
    [SerializeField, Label("テレポートの出口")]
    private GameObject teleportExitPos;
    [SerializeField, Tag, Label("衝突した時テレポートする対象のタグ")]
    private string teleportTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //対象と衝突したら
        if(collision.gameObject.CompareTag(teleportTag))
        {
            //指定場所に強制移動させる
            collision.gameObject.transform.position = teleportExitPos.transform.position;
        }
    }
}
