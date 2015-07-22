using System.Xml.Schema;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class ObjectController : MonoBehaviour
    {
        private int gridSize = 5;
        private bool _isMoving;
        private char _direction;
        private Vector3 _movePosition;
        private float _tileMoveSpeed;

        void Start()
        {
            _movePosition = transform.position;
            _tileMoveSpeed = (20f*Time.deltaTime);
        }
        void Update ()
        {
            GetInput();
            MoveDirection();
        }

        private void MoveDirection()
        {
            Vector3 position = transform.position;

            if (!_isMoving)
            {
                Vector3 rayPosition = new Vector3(transform.position.x, (transform.position.y + 1), transform.position.z);
                Ray collisionRay = new Ray();
                RaycastHit hit;

                switch (_direction)
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
                
                if (Physics.Raycast(collisionRay, out hit, gridSize))
                {
                    switch (_direction)
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

                            Debug.Log("No Direction Set");
                            break;
                    }

                    _movePosition = position;
                    _isMoving = true;
                }
            }

            if (transform.position == _movePosition)
            {
                _isMoving = false;
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, _movePosition, _tileMoveSpeed);
        }

        private void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _direction = 'N';
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _direction = 'S';
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _direction = 'E';
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _direction = 'W';
            }
        }
    }
}
