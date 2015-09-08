using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    

    public class ControllerService : MonoBehaviour
    {
        private static IHandler _handler;

        public static ControllerService Instance;

        public char Direction
        {
            get { return _handler.Direction; }
        }

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }

            Instance = this;

            var platform = Application.platform;

            if (platform == RuntimePlatform.IPhonePlayer || platform == RuntimePlatform.Android)
            {
                _handler = new TouchHandler();
            }
            else
            {
                _handler = new KeyboardHandler();
            }
        }

        void Update()
        {
            _handler.CalculateDirection();
        }


    }

    public class KeyboardHandler : IHandler
    {
        public void CalculateDirection()
        {
            throw new System.NotImplementedException();
        }

        public char Direction { get; }
    }

    public interface IHandler
    {
        void CalculateDirection();
        char Direction { get; }
    }

    public class Character
    {
        private void MoveDirection()
        {
            var direction = ControllerService.Instance.Direction;
        }
    }

    public class TouchHandler : IHandler
    {
        public void CalculateDirection()
        {
            throw new System.NotImplementedException();
        }

        public char Direction { get; }
    }
}
