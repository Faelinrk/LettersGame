using GameSettings;
using Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace Views
{
    public class TextView : MonoBehaviour
    {
        private IAnimatable _startInterface;
        private RuleCorrector _ruleCorrector;
        private TMP_Text _text;
        [Inject]
        private void Construct(RuleCorrector ruleCorrector)
        {
            _ruleCorrector = ruleCorrector;
            _text = GetComponent<TMP_Text>();
            _startInterface = new StartPartFadeIn(_text);
        }
        private void Awake()
        {   
            _ruleCorrector.RoundStarted += ShowQuestion;
        }

        private void OnDestroy()
        {
            _ruleCorrector.RoundStarted -= ShowQuestion;
        }
        private void ShowQuestion(string winnerInfo)
        {
            _text.text = $"Find {winnerInfo}";
            _startInterface.PlayAnimation();
        }
    }

}
