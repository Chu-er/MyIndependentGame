using UnityEngine;
using System.Collections;

public class ActorController : MonoBehaviour
{
    #region AnimatorID
    private int forwardID = Animator.StringToHash("forward");

    #endregion



    public GameObject Model;
    public PlayerInput Pi;
    [SerializeField]
    private Animator anim;
    private Rigidbody rigid;


    #region Vector3
    private Vector3 moveingVec;
    #endregion
    #region Parameter
    public float WalkSpeed;
    #endregion

    public bool isOpen = false;
    void Awake()
    {
        Pi = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat(forwardID, Pi.Dmag);
        if (Model && Pi.Dmag > 0.1f)
        {
            Vector3 targetForward = Vector3.Slerp(Model.transform.forward, Pi.Dvec, 0.3f);
            Model.transform.forward = targetForward;

        }
        moveingVec = Pi.Dmag * Model.transform.forward;
    }
    private void FixedUpdate()
    {
        if (rigid)
        {
            //rigid.position += moveingVec * Time.fixedDeltaTime*WalkSpeed;
            rigid.velocity = WalkSpeed*  moveingVec+new Vector3(0,rigid.velocity.y,0);
        }
    }
   
}
