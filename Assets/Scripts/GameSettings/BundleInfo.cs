using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "New BundleInfo", menuName = "BundleInfo", order = 0)]
    public class BundleInfo : ScriptableObject
    {
        [SerializeField] private CellInfo[] _bundle;

        public CellInfo[] Bundle
        {
            get { return _bundle; }
        }
    }

}
