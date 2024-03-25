using DG.Tweening;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class FullFadeIn : IAnimatable
    {
        MaskableGraphic _parentObject;
        public FullFadeIn(MaskableGraphic parentObject)
        {
            _parentObject = parentObject;
        }
        public void PlayAnimation()
        {
            _parentObject.color = new Color(1, 1, 1, 0);
            _parentObject.DOColor(new Color(1, 1, 1, 1f), 1f);
        }
    }

}
