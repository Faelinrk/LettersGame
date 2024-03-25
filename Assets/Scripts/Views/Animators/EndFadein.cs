using Interfaces;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Views
{
    public class EndFadein : IAnimatable
    {
        MaskableGraphic _parentObject;
        public EndFadein(MaskableGraphic parentObject)
        {
            _parentObject = parentObject;
        }
        public void PlayAnimation()
        {
            _parentObject.color = new Color(1, 1, 1, 1f);
            _parentObject.DOColor(new Color(1, 1, 1, 0f), 1f);
        }
    }

}
