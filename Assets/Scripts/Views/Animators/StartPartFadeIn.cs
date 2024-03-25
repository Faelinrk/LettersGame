using DG.Tweening;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class StartPartFadeIn : IAnimatable
    {
        MaskableGraphic _parentObject;
        public StartPartFadeIn (MaskableGraphic parentObject)
        {
            _parentObject = parentObject;
        }
        public void PlayAnimation()
        {
            _parentObject.color = new Color(1, 1, 1, 0);
            _parentObject.DOColor(new Color(1, 1, 1, .7f), 1f);
        }
    }

}
