using DG.Tweening;
using Interfaces;
using View;

namespace Views
{
    public class IncorrectCellObject : IClickAnimatable
    {
        private CellObject _parent;
        private Tween _currentTween;

        public IncorrectCellObject(CellObject parent)
        {
            _parent = parent;
        }
        public void PlayClickAnimation()
        {
            if (_currentTween == null ||  _currentTween.IsComplete() )
            {
                _currentTween = DOTween.Sequence()
                .SetEase(Ease.InBounce)
                .Append(_parent.transform.DOMoveX(_parent.transform.position.x - .5f, .3f))
                .Append(_parent.transform.DOMoveX(_parent.transform.position.x + .5f, .3f))
                .Append(_parent.transform.DOMoveX(_parent.transform.position.x, .3f));
            }
        }
    }

}
