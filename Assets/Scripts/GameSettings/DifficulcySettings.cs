using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "New Difficulcy", menuName = "Difficulcy", order = 0)]
    public class DifficulcySettings : ScriptableObject
    {
        [SerializeField] private int _rowCount;
        [SerializeField] private int _colCount;
        public int RowCount
        {
            get { return _rowCount; }
        }
        public int ColumnCount
        {
            get { return _colCount; }
        }
    }

}
