using UnityEngine;

namespace GameSettings
{
    [CreateAssetMenu(fileName = "New CellInfo", menuName = "CellInfo", order = 0)]
    public class CellInfo : ScriptableObject
    {
        [SerializeField] private string _cellName;
        [SerializeField] private Sprite _cellSprite;
        [SerializeField] private Vector3 _spriteRotation;

        public string CellName
        {
            get { return _cellName; }
        }
        public Sprite CellSprite
        {
            get { return _cellSprite; }
        }
        public Vector3 SpriteRotation
        {
            get
            {
                return _spriteRotation;
            }
        }
    }

}
