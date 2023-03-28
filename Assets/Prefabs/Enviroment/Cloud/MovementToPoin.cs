/*
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovementToPoin : MonoBehaviour
{
    public Action<bool, float> OnMoveForward;
    public Action<bool> OnIdle;

    [SerializeField] protected int _loopCount;
    [SerializeField] protected LoopType _loopType;
    [SerializeField] protected Ease _movementType;
    [SerializeField] protected float _delay;
    public float Delay => _delay;

    [SerializeField] protected float _durationMove;
    public float DurationMove => _durationMove;

    [SerializeField] protected bool _isMoveOnStart;
    public bool IsMoveOnStart
    {
        get => _isMoveOnStart;
        set { _isMoveOnStart = value; }
    }

    [SerializeField] protected Transform[] _pointArray;

    protected Guid _uid;
    protected Vector3 _prevPosition;
    protected bool _isMoveForward;
    protected int _currentStep = 0;

    private Sequence _moveSequence;

    private void Start()
    {
        SetActiveMove(_isMoveOnStart);
    }

    protected virtual void StartMove()
    {
        if(_moveSequence == null)
        {
            _prevPosition = transform.position;
            //CheckPositionAndSendEvent(0, Delay);

            _moveSequence = DOTween.Sequence();
            Tween bufMovetween;

            foreach (var pointTransform in _pointArray)
            {
                bufMovetween = transform.DOMove(pointTransform.position, _durationMove).Pause();
                _moveSequence.Append(bufMovetween).Pause();
            }

            _moveSequence.SetLoops(_loopCount, _loopType).
                AppendInterval(_delay).
                SetDelay(_delay).
                SetEase(_movementType).
                OnStepComplete(()=>
            {
                _currentStep = (_currentStep < _pointArray.Length - 1) ? _currentStep++ : 0;
                CheckPositionAndSendEvent(_currentStep, 0);
                _prevPosition = _pointArray[_currentStep].position;
            });

            _uid = System.Guid.NewGuid();
            _moveSequence.id = _uid;
        }

        _moveSequence.Play();
    }

    protected virtual void CheckPositionAndSendEvent(int positionIndex, float delayInSeconds)
    {
        _isMoveForward = _prevPosition.x < _pointArray[positionIndex].position.x;
        OnMoveForward?.Invoke(_isMoveForward, delayInSeconds);
    }

    protected virtual void StopMove()
    {
        if(_moveSequence != null)
        {
            DOTween.Kill(_uid);
            _moveSequence = null;
            _currentStep = 0;
        }   
    }

    public void SetActiveMove(bool isActive)
    {
        if(isActive)
        {
            StartMove();
        }
        else
        {
            StopMove();
        }
    }
}
*/
