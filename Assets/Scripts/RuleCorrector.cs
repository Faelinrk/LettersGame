using Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using View;
using Views;

namespace GameSettings
{
    public class RuleCorrector : IDisposable
    {
        private List<CellInfo> _availableCards;
        private List<CellInfo> _usedCards;
        private int _level = 0;
        private AreaBuilder _areaBuilder;
        private CellFactory _cellfactory;
        private CellObject _winCard;
        private CommonSettings _currentGameSettings;
        public event Action<string> RoundStarted;
        public event Action GameEnded;
        private RuleCorrector(AreaBuilder builder, CellFactory cellFactory, CommonSettings currentGameSettings)
        {
            _areaBuilder = builder;
            _cellfactory = cellFactory;
            _currentGameSettings = currentGameSettings;
        }
        public void BuildLevel(int currentLevel)
        {
            _level = currentLevel;
            if (_level == 0)
            {
                _usedCards = new List<CellInfo>();
            }
            BundleInfo bundleInfo = _currentGameSettings.Bundles[UnityEngine.Random.Range(0, _currentGameSettings.Bundles.Length)];
            _availableCards = new List<CellInfo>(bundleInfo.Bundle);
            _winCard = null;
            CellObject[,] cellObjects = _areaBuilder.FillObjectsArea(_cellfactory, currentLevel);
            for (int i = 0; i < cellObjects.GetLength(0); i++)
            {
                for (int j = 0; j < cellObjects.GetLength(1); j++)
                {
                    CellObject cellObject = cellObjects[i, j];
                    CellInfo currentInfo;
                    currentInfo = _availableCards[UnityEngine.Random.Range(0, _availableCards.Count)];
                    cellObject.Info = currentInfo;
                    _usedCards.Add(cellObject.Info);
                    _availableCards = _availableCards.Except(_usedCards).ToList();
                    if (_availableCards.Count <= 0)
                    {
                        throw new Exception("Not enough cards in one of the bundles!");
                    }
                    if (!_winCard && UnityEngine.Random.Range(0, bundleInfo.Bundle.Length) == 0)
                    {
                        cellObject.ClickAnimInterface = new CorrectCellObject(cellObject);
                        _winCard = cellObject;
                    }
                    else
                    {
                        cellObject.ClickAnimInterface = new IncorrectCellObject(cellObject);
                    }
                }
            }
            if (!_winCard)
            {
                CellObject cellObject = cellObjects[cellObjects.GetLength(0) - 1, cellObjects.GetLength(1) - 1];
                cellObject.ClickAnimInterface = new CorrectCellObject(cellObject);
                _winCard = cellObject;
            }
            _winCard.WinAnimationFinished += NextLevel;
            RoundStarted?.Invoke(_winCard.Info.CellName);
        }

        private void NextLevel()
        {
            Dispose();
            _level += 1;
            _areaBuilder.DestroyObjectsArea(_cellfactory);
            if (_level >= _currentGameSettings.Difficulcies.Length)
            {
                GameEnded?.Invoke();
                Debug.Log("Game Ended");
            }
            else
            {
                BuildLevel(_level);
            }
        }

        public void Dispose()
        {
            if (_winCard != null)
            {
                _winCard.WinAnimationFinished -= NextLevel;
            }
        }
    }
}

