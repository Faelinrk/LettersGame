using DG.Tweening;
using GameSettings;
using Interfaces;
using System;
using UnityEngine;
using Views;

namespace View
{
    public class CellObject : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        private CellInfo _cellInfo;
        private IClickAnimatable _clickInterface;
        private IAnimatable _startInterface;
        public event Action WinAnimationFinished;
        [SerializeField] ParticleSystem _particleSystem;
        public IClickAnimatable ClickAnimInterface
        {
            get { return _clickInterface; }
            set { _clickInterface = value; }
        }
        public CellInfo Info
        {
            get
            {
                return _cellInfo;
            }
            set
            {
                _cellInfo = value;
                transform.rotation = Quaternion.Euler(_cellInfo.SpriteRotation);
            }
        }
        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _renderer.sprite = Info.CellSprite;
            _startInterface = new CellStartAnim(this);
            _startInterface.PlayAnimation();
        }
        private void OnMouseDown()
        {
            if (!DOTween.IsTweening(transform))
            {
                ClickAnimInterface.PlayClickAnimation();
            }
        }

        public void WinParticles()
        {
            _particleSystem.Play();
        }
        public void Win()
        {
            WinAnimationFinished?.Invoke();
        }

    }

}
