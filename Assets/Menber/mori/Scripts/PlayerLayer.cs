using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayer : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _playerSpriteRend;

    public static bool DoFuwa;
    void Start()
    {
        DG.Tweening.DOTween.SetTweensCapacity(tweenersCapacity: 800, sequencesCapacity: 200);
        _playerSpriteRend =this.GetComponent<SpriteRenderer>();
        transform.DOMoveY(this.transform.position.y-0.2f, 2f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {

    }

    [SerializeField, Button]
    public void OnFront()
    {
        _playerSpriteRend.sortingOrder = 10;
    }
    [SerializeField, Button]
    public void OnBack()
    {
        _playerSpriteRend.sortingOrder = -30000;
    }

    [SerializeField, Button]
    public void ToGame()
    {
        this.gameObject.transform.DOMoveY(-95,3f).SetEase(Ease.InOutQuad);
    }
    [SerializeField, Button]
    public void ToResult()
    {
        this.gameObject.transform.DOMoveY(0, 3f).SetEase(Ease.InOutQuad);
    }
}
