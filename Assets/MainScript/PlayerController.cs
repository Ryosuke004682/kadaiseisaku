using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerStatus))]
[RequireComponent(typeof(MobAttack))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float MS = 4; //MS = MoveSpeed
    [SerializeField] private float JP = 3; //JP = JumpPawer
    [SerializeField] private Animator animator;

    private CharacterController _characterController;
    private Transform _transfrom;
    private Vector3 _moveVelocity;
    private PlayerStatus _status;
    private MobAttack _attack;
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _transfrom = transform;
        _status = GetComponent<PlayerStatus>();
        _attack = GetComponent<MobAttack>();
    }

    private void Update()
    {
        Debug.Log(_characterController.isGrounded ?
            "地上にいる" : "空中にいる");
        if (Input.GetButtonDown("Fire1"))
        {
            _attack.AttackIfPossible();
        }
        if (_status.IsMovable)
        {
            _moveVelocity.x = Input.GetAxis("Horizontal") * MS;
            _moveVelocity.z = Input.GetAxis("Vertical") * MS;

            _transfrom.LookAt(_transfrom.position + new Vector3(_moveVelocity.x
                 , 0, _moveVelocity.z));
        }
        else
        {
            _moveVelocity.x = 0;
            _moveVelocity.z = 0;
        }
        animator.SetFloat("MoveSpeed", new Vector3(_moveVelocity.x
           , 0, _moveVelocity.z).magnitude);

        if (_characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("ジャンプ！");
                _moveVelocity.y = JP;
            }
        }
        else
        {
            _moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        }
        _characterController.Move(_moveVelocity * Time.deltaTime);

    }



}
