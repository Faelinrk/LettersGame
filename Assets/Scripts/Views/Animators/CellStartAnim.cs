using DG.Tweening;
using Interfaces;
using UnityEngine;
using View;

namespace Views
{
    public class CellStartAnim : IAnimatable
    {
        CellObject _parentObject;
        public CellStartAnim(CellObject parentObject)
        {
            _parentObject = parentObject;
        }

        public void PlayAnimation()
        {
            DOTween.Sequence()
                .Append(_parentObject.transform.DOScale(new Vector2(1.1f, 1.1f), .5f))
                .Append(_parentObject.transform.DOScale(new Vector2(0.1f, 0.1f), .3f))
                .Append(_parentObject.transform.DOScale(new Vector2(1f, 1f), .5f));
        }

    }
}
