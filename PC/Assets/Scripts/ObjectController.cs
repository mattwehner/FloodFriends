using System.Linq;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class ObjectController : MonoBehaviour
    {

        private int _gridSize;
        private float _tileMoveSpeed;
        private Vector3 _movePosition;

        private void Start()
        {
            _gridSize = WorldController.GridSize;
            _tileMoveSpeed = Settings.GameObjects.TileMovementSpeed;
            _movePosition = transform.position;
        }

        private void Update()
        {
            PositionCheck();
        }

        public void Move(char direction)
        {
            Vector3 rayPosition = new Vector3(transform.position.x, (transform.position.y + 1), transform.position.z);
            Ray collisionRay = new Ray();
            RaycastHit hit;

            switch (direction)
            {
                case 'N':

                    collisionRay = new Ray(rayPosition, Vector3.forward);
                    break;

                case 'S':

                    collisionRay = new Ray(rayPosition, Vector3.back);
                    break;

                case 'E':

                    collisionRay = new Ray(rayPosition, Vector3.left);
                    break;

                case 'W':

                    collisionRay = new Ray(rayPosition, Vector3.right);
                    break;

                default:

                    Debug.Log("No Direction Set");
                    break;
            }

            Physics.Raycast(collisionRay, out hit, _gridSize);

                Vector3 position;

                switch (direction)
                {
                    case 'N':
                        position = new Vector3(hit.point.x, (hit.point.y - 1), (hit.point.z - 0.5f));
                        break;
                    case 'S':
                        position = new Vector3(hit.point.x, (hit.point.y - 1), (hit.point.z + 0.5f));
                        break;
                    case 'E':
                        position = new Vector3((hit.point.x + 0.5f), (hit.point.y - 1), hit.point.z);
                        break;
                    case 'W':
                        position = new Vector3((hit.point.x - 0.5f), (hit.point.y - 1), hit.point.z);
                        break;
                    default:
                        position = transform.position;
                        break;
                }
                _movePosition = position;
        }

        private void PositionCheck()
        {
            var stillMovingList = WorldController.MovingTiles;
            var thisTile = gameObject.name;

            if (transform.position == _movePosition)
            {
                if (stillMovingList.Contains(thisTile))
                {
                    stillMovingList.Remove(thisTile);
                }
                return;
            }
            if (!stillMovingList.Contains(thisTile))
            {
                stillMovingList.Add(thisTile);
            }
            transform.position = Vector3.MoveTowards(transform.position, _movePosition, _tileMoveSpeed);
        }
    }
}