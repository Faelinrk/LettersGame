using GameSettings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Common
{
    public class GameStarter : MonoBehaviour
    {
        private RuleCorrector _ruleCorrector;
        [Inject]
        private void Construct(RuleCorrector ruleCorrector)
        {
            _ruleCorrector = ruleCorrector;
        }
        void Start()
        {
            _ruleCorrector.BuildLevel(0);
        }

    }
}
