using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pleer : MonoBehaviour
{

    [SerializeField] private float speed = 2.5f;
    public float Speed
    { 
        get { return speed; } 
        set 
        { 
            if (value > 0.5)
                speed = value;
        } 
    }

    [SerializeField] private BuffReciever buffReciever;
    [SerializeField] private float force;
    [SerializeField] private Rigidbody2D rigidboby;
    [SerializeField] private float minimalHeght;
    [SerializeField] private bool isCheatMode;
    [SerializeField] private GroundDetection groundDetection;
    [SerializeField] private Vector3 direction;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool isJamping;
    [SerializeField] private Arrow arrow;
    [SerializeField] private Transform arrowSpawnPoint;
    public object parent;
    private float lifeTime = 1;
    public bool recharge;
    private int arrowsCount = 3;
    [SerializeField] private Arrow currentArrow;
    private List<Arrow> arrowPool;
    [SerializeField] private Health health;
    [SerializeField] private Item item;
    [SerializeField] private Camera playerCamera;

    private float bonusForce;
    private float bonusDamage;
    private float bonusHealth;

    private UICharacterController controller;
    public Health Health { get { return health; } }


    private void Start()
    {
        arrowPool = new List<Arrow>();
        for (int i = 0; i < arrowsCount; i++)
        {
            var arrowTemp = Instantiate(arrow, arrowSpawnPoint);
            arrowPool.Add(arrowTemp);
            arrowTemp.gameObject.SetActive(false);
        }

        buffReciever.OnBaffsChanged += ApplyBuffs;
;
    }   

    public void InitUIController(UICharacterController uiController)
    {
        controller = uiController;
        controller.Jamp.onClick.AddListener(Jump);
        controller.Fire.onClick.AddListener(CheckShoot);


    }

    private void ApplyBuffs()
    {
        //Debug.Log("Произошел вызов делегата!");
        var forceBuff = buffReciever.Buffs.Find(t => t.type == BuffType.Force);
        var damageBuff = buffReciever.Buffs.Find(t => t.type == BuffType.Damage);
        var armorBuff = buffReciever.Buffs.Find(t => t.type == BuffType.Armor);
        bonusForce = forceBuff == null ? 0 : forceBuff.additiveBonus;
        bonusHealth = armorBuff == null ? 0 : armorBuff.additiveBonus;
        health.SetHealth((int)bonusHealth);
        bonusDamage = damageBuff == null ? 0 : damageBuff.additiveBonus;

    }

    private void Awake()
    {
        Instance = this;
    }
    #region Singleton
    public static Pleer Instance { get; set; }
    #endregion

    void FixedUpdate()
    {
        Move();
        animator.SetFloat("speed", Mathf.Abs(direction.x));
        CheckFall();
    }

    private void Move()
    {
        animator.SetBool("IsGrounded", groundDetection.isGrounded);
        if (!isJamping && !groundDetection.isGrounded)
            animator.SetTrigger("StartFall");
        isJamping = /*isJamping && */!groundDetection.isGrounded;
        direction = Vector3.zero;

#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A))
            direction = Vector3.left;
        if (Input.GetKey(KeyCode.D))
            direction = Vector3.right;
#endif
        if (controller.Left.IsPressed)
            direction = Vector3.left;

        if (controller.Right.IsPressed)
            direction = Vector3.right;
        direction *= speed;
        direction.y = rigidboby.velocity.y;
        rigidboby.velocity = direction;


        if (direction.x > 0)
            spriteRenderer.flipX = false;

        if (direction.x < 0)
            spriteRenderer.flipX = true;

    }

    private void Jump()
    {
        if (groundDetection.isGrounded && !isJamping)
        {

            rigidboby.AddForce(Vector2.up * (force + bonusForce), ForceMode2D.Impulse);
            animator.SetTrigger("StartJump");
            isJamping = true;

        }
    }

    private Arrow GetArrowFromPool()
    {
        if (arrowPool.Count > 0)
        {
            var arrowTemp = arrowPool[0];
            arrowPool.Remove(arrowTemp);
            arrowTemp.gameObject.SetActive(true);
            arrowTemp.transform.parent = null;
            arrowTemp.transform.position = arrowSpawnPoint.transform.position;
            return arrowTemp;
        }
        return Instantiate
            (arrow, arrowSpawnPoint.position, Quaternion.identity);
    }
    public void ReturnArrowToPool(Arrow arrowTemp)
    {
        if (!arrowPool.Contains(arrowTemp))
            arrowPool.Add(arrowTemp);

        arrowTemp.transform.parent = arrowSpawnPoint;
        arrowTemp.transform.position = arrowSpawnPoint.transform.position;
        arrowTemp.gameObject.SetActive(false);

    }
    void CheckFall()
    {
        if (transform.position.y < minimalHeght && isCheatMode)
        {
            rigidboby.velocity = new Vector2(0, 0);
            transform.position = new Vector2(0, 0);
        }
        else if (transform.position.y < minimalHeght && !isCheatMode)
            Destroy(gameObject);
    }

    private void Update()
    {
    
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
#endif
    }
    void CheckShoot()
    {
        if (!recharge && !isJamping)
        {
            recharge = true;
            StartCoroutine(StarRecharge());
            animator.SetTrigger("StartRecharge");

            currentArrow = GetArrowFromPool();  

            currentArrow.SetImpulse
                (Vector2.right, spriteRenderer.flipX ? -force * 5 : force * 5 , (int)bonusDamage, this) ;
        }
    }
    private IEnumerator StarRecharge()
    {
        yield return new WaitForSeconds(lifeTime);
        recharge = false;
        yield break;
    }

  /*  private void OnDestroy()
    {
        playerCamera.transform.parent = null;
        playerCamera.enabled = true;
    }*/
}
