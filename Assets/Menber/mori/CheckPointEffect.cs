using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class CheckPointEffect : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _tmPro;
    private CanvasGroup _canvasGroup => _tmPro.GetComponent<CanvasGroup>();
    [SerializeField]
    private GameObject _effect;

    [SerializeField]
    private Transform _effectTra1;
    [SerializeField]
    private Transform _effectTra2;

    private void Awake()
    {
        _tmPro.gameObject.transform.localScale = new Vector3(4, 4, 4);
        _canvasGroup.alpha = 0;
    }
    void Start()
    {
        TextAnimation();
    }
    private void TextAnimation()
    {
        var sequence = DOTween.Sequence();
        var In = _tmPro.transform.DOScale(new Vector3(1, 1, 1), 0.3f).SetEase(Ease.InCirc);
        var FadeIn = DOVirtual.Float(
              from: 0,
              to: 1,
              duration: 0.2f,
              onVirtualUpdate: (tweenValue) => {
                  _canvasGroup.alpha = tweenValue;
              }
        );
        var FadeOut = DOVirtual.Float(
              from: 1,
              to: 0,
              duration: 0.7f,
              onVirtualUpdate: (tweenValue) => {
                  _canvasGroup.alpha = tweenValue;
              }
        );

        sequence.AppendCallback(() => Set());

        sequence.Join(In);
        sequence.Join(FadeIn);

        sequence.AppendInterval(0.2f);

        //sequence.Append(() => Eff1());
        //sequence.Append(() => Eff2());

        sequence.Append(FadeOut);

        sequence.AppendInterval(0.5f);

        sequence.OnComplete(()=>Destroy(this.gameObject));
    }

    private void Set()
    {
        _tmPro.gameObject.transform.localScale = new Vector3(4, 4, 4);
        _canvasGroup.alpha = 0;
    }

    private void Eff1()
    {
        Instantiate(_effect
            , new Vector2(_effectTra1.position.x,_effectTra1.position.y), Quaternion.identity);
    }
    private void Eff2()
    {
        Instantiate(_effect
            , new Vector2(_effectTra2.position.x, _effectTra2.position.y), Quaternion.identity);
    }
}
/*
 *
 *        sequence.Join( In );
        sequence.Join( FadeIn );

        sequence.AppendInterval(0.7f);

        sequence.Append(FadeOut);

        sequence.AppendInterval(0.5f);

        sequence.OnComplete(()=>Destroy(this.gameObject));
 *
 *
 *
 */
