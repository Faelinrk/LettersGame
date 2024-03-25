using DG.Tweening;
using Interfaces;
using UnityEngine;

namespace View
{
    public class CorrectCellObject : IClickAnimatable
    {
        CellObject _parent;
        public CorrectCellObject(CellObject parent)
        {
            _parent = parent;
        }
        public void PlayClickAnimation()
        {
            _parent.WinParticles();
            DOTween.Sequence()
                .Append(_parent.transform.DOScale(new Vector2(1.1f, 1.1f), .5f))
                .Append(_parent.transform.DOScale(new Vector2(0.1f, 0.1f), .3f))
                .Append(_parent.transform.DOScale(new Vector2(1f, 1f), .5f))
                .OnComplete(ExecuteWin);
        }
        public void ExecuteWin()
        {
            _parent.Win();
        }
    }

}
