using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NController.NPlayer
{
    public class PlayerController 
        : MonoBehaviour
    {
        private const string KeyInputHorizontal = "Horizontal";
        private const string KeyInputVertical = "Vertical";
        private const string keyInputMouseX = "Mouse X";

        public float MoveSpeed = 10.0f;
        public float RotateSpeed = 100.0f;

        private Transform _playerTransform;

        // Start is called before the first frame update
        void Start()
        {
            _playerTransform = GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            //var r = Input.GetAxis(keyInputMouseX);

            TranslatePlayer();
            RotatePlayer();
        }

        void TranslatePlayer()
        {
            if (_playerTransform == null)
            {
                return;
            }

            var h = Input.GetAxis(KeyInputHorizontal);
            var v = Input.GetAxis(KeyInputVertical);

            var moveDir = Vector3.forward * v + Vector3.right * h;

            _playerTransform.Translate(moveDir.normalized * MoveSpeed * Time.deltaTime, Space.Self);
        }

        void RotatePlayer()
        {
            var h = Input.GetAxis(KeyInputHorizontal);
            var r = Input.GetAxis(keyInputMouseX);

            _playerTransform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime * r);
        }
    }
}

