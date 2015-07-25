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
        private bool _toDelete;
        internal int TileSize;

        internal Rigidbody Rigidbody;

        private void Start()
        {
            _gridSize = WorldController.GridSize;
            _tileMoveSpeed = Settings.GameObjects.TileMovementSpeed;
            _movePosition = transform.position;

            Rigidbody = gameObject.GetComponent<Rigidbody>();
            TileSize = (int) Rigidbody.mass;
        }

        private void Update()
        {
            PositionCheck();
        }

        void OnTriggerEnter(Collider collided)
        {
            if (collided.tag != "Tile") return;

            var toSelf = Vector3.Distance(transform.position, _movePosition);
            var toCollided = Vector3.Distance(collided.transform.position, _movePosition);
            
            _toDelete = (toSelf > toCollided);

            if (!_toDelete)
            {
                TileSize += (int) collided.GetComponent<Rigidbody>().mass;
                Debug.Log("Increasing " + gameObject.name + " tile size from " + Rigidbody.mass + " to " + TileSize);

                var raftSize = WorldController.Raft_SM;
                var raftPosition = transform.position;

                switch (TileSize)
                {
                    case 2:
                        raftSize = WorldController.Raft_MD;
                        raftPosition = new Vector3(transform.position.x, 0.25f, transform.position.z);
                        break;
                    case 3:
                        raftSize = WorldController.Raft_LG;
                        raftPosition = new Vector3(transform.position.x, 0.375f, transform.position.z);
                        break;
                    case 4:
                        raftSize = WorldController.Raft_XL;
                        raftPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                        break;
                }
                Destroy(transform.GetChild(0).gameObject);
                GameObject newRaft = Instantiate(raftSize, raftPosition, Quaternion.identity) as GameObject;
                if (newRaft != null) newRaft.transform.parent = transform;
                Rigidbody.mass = TileSize;
            }
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

                if (_toDelete)
                {
                    WorldController.Tiles.Remove(gameObject);
                    Destroy(gameObject);
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