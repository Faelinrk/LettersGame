using UnityEngine;
using View;

namespace Builders
{
    public class CellFactory
    {
        private CellObject _cellPrefab;
        public CellFactory(CellObject cellPrefab)
        {
            _cellPrefab = cellPrefab;        }

        public CellObject BuildCell(Vector2 position, int rowsSize)
        {
            CellObject cellInstance = GameObject.Instantiate(_cellPrefab);
            Vector3 cellBounds = cellInstance.GetComponent<Collider2D>().bounds.size;
            Vector2 screenCenterOffset = new Vector2(position.x * cellBounds.x - cellBounds.x, position.y * cellBounds.y - cellBounds.y / 2 * (rowsSize - 1));
            cellInstance.transform.position = screenCenterOffset;
            return cellInstance;
        }
        public void UnbuildCell(CellObject cell)
        {
            GameObject.Destroy(cell.gameObject);
        }
    }

}
