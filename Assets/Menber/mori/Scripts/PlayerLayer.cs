using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayer : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _playerSpriteRend;
    void Start()
    {
        _playerSpriteRend=this.GetComponent<SpriteRenderer>();
    }

    [SerializeField, Button]
    private void OnFront()
    {
        _playerSpriteRend.sortingOrder = 10;
    }
    [SerializeField, Button]
    private void OnBack()
    {
        _playerSpriteRend.sortingOrder = -30000;
    }
}
