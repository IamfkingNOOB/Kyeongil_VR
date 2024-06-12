using System;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public enum MoveStyleType
{
    HEAD_RELATIVE,
    HAND_RELATIVE,
}

public enum TurnStyleType
{
    SNAP,
    CONTINUOUS,
}

public class LocomoteManager : MonoBehaviour
{
    #region Component / Field

    [Header("XR")]
    [SerializeField] private XROrigin _XROrigin;
    [SerializeField] private XRBaseController _XRBaseController_Left;
    [SerializeField] private XRBaseController _XRBaseController_Right;

    [Header("Locomotion")]
    [SerializeField] private ContinuousMoveProviderBase _continuousMoveProviderBase;
    [SerializeField] private ContinuousTurnProviderBase _continuousTurnProviderBase;
    [SerializeField] private SnapTurnProviderBase _snapTurnProviderBase;
    [SerializeField] private TeleportationProvider _teleportationProvider;

    [Header("Property")]
    [SerializeField] private MoveStyleType _leftHandMoveStyle;
    [SerializeField] private TurnStyleType _rightHandTurnStyle;
    [SerializeField, Range(0.0f, 5.0f)] private float _moveSpeed;
    [SerializeField] private bool _isEnableStrafe;
    [SerializeField] private bool _isUseGravity;
    [SerializeField] private bool _isEnableFly;
    [SerializeField, Range(0.0f, 100.0f)] private float _turnSpeed;
    [SerializeField] private bool _isEnableTurnAround;
    [SerializeField, Range(0.0f, 90.0f)] private float _snapTurnAmount;

    #endregion Component / Field

    #region Getter / Setter

    // [C# Property Style] Getter, Setter
    public MoveStyleType MoveStyle
    {
        get { return _leftHandMoveStyle; }
        set
        {
            _leftHandMoveStyle = value;

            switch (_leftHandMoveStyle)
            {
                case MoveStyleType.HEAD_RELATIVE:
                    _continuousMoveProviderBase.forwardSource = _XROrigin.Camera.transform;
                    break;
                case MoveStyleType.HAND_RELATIVE:
                    _continuousMoveProviderBase.forwardSource = _XRBaseController_Left.transform;
                    break;
            }
        }
    }

    public TurnStyleType TurnStyle
    {
        get { return _rightHandTurnStyle; }
        set
        {
            _rightHandTurnStyle = value;

            switch (_rightHandTurnStyle)
            {
                case TurnStyleType.SNAP:
                    _continuousTurnProviderBase.enabled = false;
                    _snapTurnProviderBase.enabled = true;
                    break;
                case TurnStyleType.CONTINUOUS:
                    _continuousTurnProviderBase.enabled = true;
                    _snapTurnProviderBase.enabled = false;
                    break;
            }
        }
    }

    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set
        {
            _moveSpeed = value;
            _continuousMoveProviderBase.moveSpeed = _moveSpeed;
        }
    }

    public bool IsEnableStrafe
    {
        get { return _isEnableStrafe; }
        set
        {
            _isEnableStrafe = value;
            _continuousMoveProviderBase.enableStrafe = _isEnableStrafe;
        }
    }

    public bool IsUseGravity
    {
        get { return _isUseGravity; }
        set
        {
            _isUseGravity = value;
            _continuousMoveProviderBase.useGravity = _isUseGravity;
        }
    }

    public bool IsEnableFly
    {
        get { return _isEnableFly; }
        set
        {
            _isEnableFly = value;
            _continuousMoveProviderBase.enableFly = _isEnableFly;
        }
    }

    public float TurnSpeed
    {
        get { return _turnSpeed; }
        set
        {
            _turnSpeed = value;
            _continuousTurnProviderBase.turnSpeed = _turnSpeed;
        }
    }

    public bool IsEnableTurnAround
    {
        get { return _isEnableTurnAround; }
        set
        {
            _isEnableTurnAround = value;
            _snapTurnProviderBase.enableTurnAround = _isEnableTurnAround;
        }
    }

    public float SnapTurnAmount
    {
        get { return _snapTurnAmount; }
        set
        {
            _snapTurnAmount = value;
            _snapTurnProviderBase.turnAmount = _snapTurnAmount;
        }
    }

    // [Method Style] Getter, Setter
    // public MoveStyleType GetMoveStyle() { return _leftHandMoveStyle; }
    // public void SetMoveStyle(MoveStyleType value) { _leftHandMoveStyle = value; }

    #endregion Getter / Setter


    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        MoveStyle = _leftHandMoveStyle;
        TurnStyle = _rightHandTurnStyle;
        MoveSpeed = _moveSpeed;
        IsEnableStrafe = _isEnableStrafe;
        IsUseGravity = _isUseGravity;
        IsEnableFly = _isEnableFly;
        TurnSpeed = _turnSpeed;
        IsEnableTurnAround = _isEnableTurnAround;
        SnapTurnAmount = _snapTurnAmount;
    }
}
