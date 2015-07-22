using System.Xml.Schema;
using UnityEngine;

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
            _tileMoveSpeed = (10f*Time.deltaTime);
        }
        void Update ()
        {
            GetInput();
            Move();
        }

        private void Move()
        {
            if (_direction == 'N')
            {
                if (!_isMoving)
                {
                    Vector3 rayPosition = new Vector3(transform.position.x,(transform.position.y + 1),transform.position.z);
                    Ray collisionRay = new Ray(rayPosition, Vector3.forward);
                    RaycastHit hit;

                    Debug.DrawRay(rayPosition, Vector3.forward*gridSize);
                    if (Physics.Raycast(collisionRay, out hit, gridSize))
                    {
                        _movePosition = new Vector3(hit.point.x, (hit.point.y -1), (hit.point.z - 0.5f));
                        _isMoving = true;
                        Debug.Log(_movePosition);
                    }
                }
            }
            if (_direction == 'S')
            {
                if (!_isMoving)
                {
                    Vector3 rayPosition = new Vector3(transform.position.x, (transform.position.y + 1), transform.position.z);
                    Ray collisionRay = new Ray(rayPosition, Vector3.back);
                    RaycastHit hit;

                    Debug.DrawRay(rayPosition, Vector3.back * gridSize);
                    if (Physics.Raycast(collisionRay, out hit, gridSize))
                    {
                        _movePosition = new Vector3(hit.point.x, (hit.point.y - 1), (hit.point.z + 0.5f));
                        _isMoving = true;
                        Debug.Log(_movePosition);
                    }
                }
            }
            if (_direction == 'E')
            {
                if (!_isMoving)
                {
                    Vector3 rayPosition = new Vector3(transform.position.x, (transform.position.y + 1), transform.position.z);
                    Ray collisionRay = new Ray(rayPosition, Vector3.left);
                    RaycastHit hit;

                    Debug.DrawRay(rayPosition, Vector3.left * gridSize);
                    if (Physics.Raycast(collisionRay, out hit, gridSize))
                    {
                        _movePosition = new Vector3((hit.point.x + 0.5f), (hit.point.y - 1), hit.point.z);
                        _isMoving = true;
                        Debug.Log(_movePosition);
                    }
                }
            }
            if (_direction == 'W')
            {
                if (!_isMoving)
                {
                    Vector3 rayPosition = new Vector3(transform.position.x,(transform.position.y + 1),transform.position.z);
                    Ray collisionRay = new Ray(rayPosition, Vector3.right);
                    RaycastHit hit;

                    Debug.DrawRay(rayPosition, Vector3.right * gridSize);
                    if (Physics.Raycast(collisionRay, out hit, gridSize))
                    {
                        _movePosition = new Vector3((hit.point.x - 0.5f), (hit.point.y - 1), hit.point.z);
                        _isMoving = true;
                        Debug.Log(_movePosition);
                    }
                }
            }

            if (transform.position == _movePosition)
            {
                _isMoving = false;
                return;
            }
            transform.position = Vector3.Lerp(transform.position, _movePosition, _tileMoveSpeed);

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
