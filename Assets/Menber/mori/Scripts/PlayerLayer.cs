using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class PlayerLayer : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _playerSpriteRend;

    public static bool _doFollow;

    [SerializeField]
    private GameObject _GameObject;

    [SerializeField]
    private GameObject _startC;

    public static bool IsGameTime = false;

    public static bool DoFuwa;
    void Start()
    {
    //    DG.Tweening.DOTween.SetTweensCapacity(tweenersCapacity: 800, sequencesCapacity: 200);
        _playerSpriteRend =this.GetComponent<SpriteRenderer>();
        //    transform.DOMoveY(this.transform.position.y-0.2f, 2f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
        IsGameTime = false;
    }

    private void Update()
    {
        if(_doFollow)
        {
            this.transform.position=_GameObject.transform.position;
        }
    }

    [SerializeField, Button]
    public async void ToGame()
    {
        await this.gameObject.transform.DOMoveY(-125, 3f).SetEase(Ease.InOutQuad);
        IsGameTime = true;
        ChangeParent();
    }
    [SerializeField, Button]
    public void ToResult()
    {
        IsGameTime = false;
        this.gameObject.transform.DOMoveY(0, 3f).SetEase(Ease.InOutQuad);
    }
    void ChangeParent()
    {
        _doFollow = true;
        _startC.SetActive(false);
    }
}
