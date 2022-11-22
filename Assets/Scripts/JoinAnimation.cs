using UnityEngine;

public class JoinAnimation : MonoBehaviour
{
    public Animator doorAnimator; //ссылка на аниматор двери  
    public Transform target; //ссылка на точку для начала анимации
    private PlayerAnimation anim; //аниматор персонажа
    private bool secondTurn = false;
    private InputService _inputService;
    

    private void Start()
    {
        anim = GetComponent<PlayerAnimation>(); //инициализируем аниматор
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Vector3.Distance(transform.position, target.position) <= 0.5) //дошел
            {
                transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
                _inputService.SetMovementActive(false);
                doorAnimator.SetTrigger("open"); //запуск анимации двери
                anim.PlayOpenAnimation(); //запуск анимации персонажа
            }
            // else
            // {
            //     _inputService.SetMovementActive(true);
            // }
        }
    }
}