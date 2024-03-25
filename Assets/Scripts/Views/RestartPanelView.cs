using GameSettings;
using Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Views;
using Zenject;

public class RestartPanelView : MonoBehaviour
{
    private IAnimatable _startInterface;
    private IAnimatable _hideInterface;
    private IAnimatable _finishInterface;
    private RuleCorrector _ruleCorrector;
    private Image _panel;
    [SerializeField] private Button _restartButton;
    [Inject]
    private void Construct(RuleCorrector ruleCorrector)
    {
        _ruleCorrector = ruleCorrector;
        _panel = GetComponent<Image>();
        _startInterface = new StartPartFadeIn(_panel);
        _hideInterface = new EndFadein(_panel);
        _finishInterface = new FullFadeIn(_panel);
        _restartButton.onClick.AddListener(ActivateLoading);
        _restartButton.onClick.AddListener(() => { _ruleCorrector.BuildLevel(0); });
    }
    private void Awake()
    {
        _ruleCorrector.GameEnded += ShowPanel;
    }

    private void OnDestroy()
    {
        _ruleCorrector.GameEnded -= ShowPanel;
    }

    private void ShowPanel()
    {
        _startInterface.PlayAnimation();
        _restartButton.gameObject.SetActive(true);
    }
    private void ActivateLoading()
    {
        _finishInterface.PlayAnimation();
        _restartButton.gameObject.SetActive(false);
        HidePanel();
    }
    private void HidePanel()
    {
        _hideInterface.PlayAnimation();
        _restartButton?.gameObject.SetActive(false);
    }

}
