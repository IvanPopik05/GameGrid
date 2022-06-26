using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Element : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMeshPro;
        
        private bool _isMove = true;
        private bool _isFree = true;
        
        private Element _target;
        private Vector3 _targetPosition;
        private Vector3 _startPosition;
        private Vector3 _direction;
        private float _step;
        private float _progress = 0;
        public bool IsMove => _isMove;
        public bool IsFree => _isFree;

        public void Initialize(float timeMotion) => 
            _step = timeMotion / (timeMotion * 100);

        public void ChangeText() => 
            _textMeshPro.GetRandomWord();
        public void ChangeStateOfMove(bool isMove) => 
            _isMove = isMove;
        public void ChangeStateOfFree(bool isFree) => 
            _isFree = isFree;
        public TextMeshProUGUI GetTextMeshPro() => _textMeshPro;

        public void SetTarget(Element target)
        {
            _target = target;
            _targetPosition = target.transform.position;
            _startPosition = transform.position;
            _progress = 0;
        }
        private void FixedUpdate()
        {
            if(!_target)
                return;
            
            transform.position = Vector3.Lerp(_startPosition,_targetPosition,_progress);
            _progress += _step;
        }
    }
}