using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "New CommonSetting", menuName = "CommonSetting", order = 0)]
    public class CommonSettings : ScriptableObject
    {
        [SerializeField] private BundleInfo[] _bundles;
        [SerializeField] private DifficulcySettings[] _difficulcies;

        public BundleInfo[] Bundles
        {
            get { return _bundles; }
        }

        public DifficulcySettings[] Difficulcies
        {
            get
            {
                return _difficulcies;
            }
        }
    }

}
