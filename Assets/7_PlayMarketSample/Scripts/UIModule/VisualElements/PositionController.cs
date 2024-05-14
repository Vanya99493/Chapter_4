using System;
using System.Collections;
using UnityEngine;

namespace _7_PlayMarketSample.Scripts.UIModule.VisualElements
{
    public class PositionController : MonoBehaviour
    {
        [SerializeField] private Transform[] _positionsTransform;
        [SerializeField] private int _startPositionIndex;
        [Header("Position update checker")] 
        [SerializeField] private int _checkPS;
        [Header("Move animation settings")] 
        [SerializeField] private float _movementDuration;
        [SerializeField] private int _movemetUpdatePS;
        [SerializeField] private bool _useComponentYPosition = false;
        [Header("Debug")]
        [SerializeField] private bool _isDebugging;

        private int _currentPositionIndex;
        private bool _isMoving;
        
        private void Awake()
        {
            _currentPositionIndex = _startPositionIndex;
        }

        private void OnEnable()
        {
            InstantChangeCurrentPosition();
        }

        private void Start()
        {
            StartCoroutine(CheckCoroutine());
        }

        public void Move(int transformIndex)
        {
            _currentPositionIndex = transformIndex;
            StartCoroutine(MoveCoroutine(_positionsTransform[_currentPositionIndex].position));
        }

        private IEnumerator CheckCoroutine()
        {
            float delay = 1f / _checkPS; 
            while (true)
            {
                if (_isDebugging)
                {
                    Debug.Log(_isMoving);
                }
                if (!_isMoving && Vector3.Distance(transform.position, _positionsTransform[_currentPositionIndex].position) > 1)
                {
                    InstantChangeCurrentPosition();
                }
                yield return new WaitForSeconds(delay);
            }
        }

        private IEnumerator MoveCoroutine(Vector3 targetPosition)
        {
            _isMoving = true;
            float delay = 1f / _movemetUpdatePS;
            Vector3 startPosition = transform.position;
            targetPosition.y = startPosition.y;
            float passedTime = 0f;

            while (passedTime <= _movementDuration)
            {
                passedTime += delay;
                float t = Mathf.Clamp01(passedTime / _movementDuration);
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                yield return new WaitForSeconds(delay);
            }

            _isMoving = false;
        }

        private void OnRectTransformDimensionsChange()
        {
            InstantChangeCurrentPosition();
        }

        private void InstantChangeCurrentPosition()
        {
            Vector3 newPosition = _positionsTransform[_currentPositionIndex].position;
            if (!_useComponentYPosition)
            {
                newPosition.y = transform.position.y;
            }
            transform.position = newPosition;
        }
    }
}