using System.Linq;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class ObjectController : MonoBehaviour
    {
        private int _gridSize;
        private bool _isMoving;

        private char _direction;
        private Vector3 _movePosition;
        private float _tileMoveSpeed;

        void Start()
        {
            _gridSize = WorldController.GridSize;

            _movePosition = transform.position;
            _tileMoveSpeed = Settings.GameObjects.TileMovementSpeed;
        }
        void Update ()
        {
            _direction = WorldController.Direction;
        }

        //private void MoveDirection()
        //{
        //    Vector3 position = transform.position;

        //    if (transform.position == _movePosition)
        //    {
        //        _isMoving = false;

        //        if (WorldController.MovingTiles.Contains(gameObject.name))
        //        {
        //            WorldController.MovingTiles.Remove(gameObject.name);
        //        }
        //        return;
        //    }

        //    if (!_isMoving)
        //    {
        //        Vector3 rayPosition = new Vector3(transform.position.x, (transform.position.y + 1), transform.position.z);
        //        Ray collisionRay = new Ray();
        //        RaycastHit hit;

        //        switch (_direction)
        //        {
        //            case 'N':

        //                collisionRay = new Ray(rayPosition, Vector3.forward);
        //                break;

        //            case 'S':

        //                collisionRay = new Ray(rayPosition, Vector3.back);
        //                break;

        //            case 'E':

        //                collisionRay = new Ray(rayPosition, Vector3.left);
        //                break;

        //            case 'W':

        //                collisionRay = new Ray(rayPosition, Vector3.right);
        //                break;

        //            default:

        //                Debug.Log("No Direction Set");
        //                break;
        //        }
                
        //        if (Physics.Raycast(collisionRay, out hit, _gridSize))
        //        {
        //            switch (_direction)
        //            {
        //                case 'N':

        //                    position = new Vector3(hit.point.x, (hit.point.y - 1), (hit.point.z - 0.5f));
        //                    break;

        //                case 'S':

        //                    position = new Vector3(hit.point.x, (hit.point.y - 1), (hit.point.z + 0.5f));
        //                    break;

        //                case 'E':

        //                    position = new Vector3((hit.point.x + 0.5f), (hit.point.y - 1), hit.point.z);
        //                    break;

        //                case 'W':

        //                    position = new Vector3((hit.point.x - 0.5f), (hit.point.y - 1), hit.point.z);
        //                    break;

        //                default:

        //                    Debug.Log("No Direction Set");
        //                    break;
        //            }

        //            _movePosition = position;
        //            _isMoving = true;

        //            if (!WorldController.MovingTiles.Contains(gameObject.name) && notReported)
        //            {
        //                WorldController.MovingTiles.Add(gameObject.name);
        //                foreach (var Name in WorldController.MovingTiles)
        //                {
        //                    Debug.Log(Name.ToString() + " has started moving");
        //                }
        //            }
        //        }
        //    }

            
        //    transform.position = Vector3.MoveTowards(transform.position, _movePosition, _tileMoveSpeed);
        //}

        public void Move(char direction)
        {
            Debug.Log(gameObject.name + " has been asked to move " + direction);
        }
    }
}
