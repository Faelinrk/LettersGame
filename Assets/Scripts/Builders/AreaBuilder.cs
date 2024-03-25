using GameSettings;
using UnityEngine;
using View;

namespace Builders
{
    public class AreaBuilder
    {
        private CellObject[,] _cells;
        private CommonSettings _gameSettings;
        private AreaBuilder(CommonSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }
        public CellObject[,] FillObjectsArea(CellFactory cellFactory, int level)
        {
            _cells = new CellObject[_gameSettings.Difficulcies[level].RowCount, _gameSettings.Difficulcies[level].ColumnCount];
            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for(int j = 0; j < _cells.GetLength(1); j++)
                {
                    _cells[i,j] = cellFactory.BuildCell(new Vector2(j,i), _cells.GetLength(0));
                }
            }
           return _cells;
        }
        public void DestroyObjectsArea(CellFactory cellFactory)
        {
            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    cellFactory.UnbuildCell(_cells[i,j]);
                }
            }
            _cells = new CellObject[,] { };
        }
    }

}
