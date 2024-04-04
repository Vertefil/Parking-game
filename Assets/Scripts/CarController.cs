using System;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

    private Rigidbody _rb;
    public float speed = 15f, finalSpeed = 30f, rotationSpeed = 300f;
    private bool isClicked;
    //����������� ��������
    private float curPointX, curPointY;

    //�����
    [NonSerialized] public Vector3 FinalPosition;

    public enum Axis
    {
        Vertical, Horizontal
    }

    public Axis CarAxis;

    private enum Direction
    {
        Right, Left, Top, Bottom, None
    }

    private Direction CarDirectionX = Direction.None;
    private Direction CarDirectionY = Direction.None;

    public Text CountMoves, CountCoins;
    public GameObject StartGameBtn;

    private static int CountCars = 0;

    private AudioSource _audio;
    public AudioClip AudioStart, AudioCrash;
    public ParticleSystem CrashEffect;



    public void Awake()
    {
        CountCars++;
        _rb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (FinalPosition.x != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, FinalPosition, finalSpeed * Time.deltaTime);

            Vector3 lookAtPos = FinalPosition - transform.position;
            lookAtPos.y = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookAtPos), Time.deltaTime * rotationSpeed);
        }

        if (transform.position == FinalPosition)
        {
            if ( StartGame.IsGameStarted)
            {
                PlayerPrefs.SetInt("CarCoins", PlayerPrefs.GetInt("CarCoins") + 1);
                CountCoins.text = Convert.ToString(Convert.ToInt32(CountCoins.text) + 1);
                Debug.Log(CountCars);
                CountCars--;
                if (CountCars == 0)
                    StartGameBtn.GetComponent<StartGame>().WinGame();
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }

    //��������� �����������
    public void OnMouseDown()
    {
        if (!StartGame.IsGameStarted) return;

        ////��������� �������
        //curPointX = Input.GetTouch(0).position.x;
        //curPointY = Input.GetTouch(0).position.y;
    
        //��������� �����
        curPointX = Input.mousePosition.x;
        curPointY = Input.mousePosition.y;

    }
    //��������� �����
    public void OnMouseUp()
    {
        if (!StartGame.IsGameStarted) return;

        ////�������
        //if (Input.GetTouch(0).position.x - curPointX > 0)
        //    CarDirectionX = Direction.Right;
        //else
        //    CarDirectionX = Direction.Left;

        //if (Input.GetTouch(0).position.y - curPointY > 0)
        //    CarDirectionY = Direction.Top;
        //else
        //    CarDirectionY = Direction.Bottom;

        //����
        if (Input.mousePosition.x - curPointX > 0)
            CarDirectionX = Direction.Right;
        else
            CarDirectionX = Direction.Left;

        if (Input.mousePosition.y - curPointY > 0)
            CarDirectionY = Direction.Top;
        else
            CarDirectionY = Direction.Bottom;
        isClicked = true;
        //������� ���������� �����
        CountMoves.text = Convert.ToString(Convert.ToInt32(CountMoves.text) - 1);

        //���� �����
        _audio.Stop();
        _audio.clip = AudioStart;
        _audio.Play();

    }

    //����������� ����
    public void FixedUpdate()
    {
        if (CountMoves.text == "0" && CountCars > 0 && !isClicked)
        {
            StartGameBtn.GetComponent<StartGame>().LoseGame();
            CountCars = 0;
        }

        if (isClicked && FinalPosition.x == 0)
        {
            //�����������
            Vector3 whichWay = CarAxis == Axis.Horizontal ? Vector3.forward : Vector3.left;

            speed = MathF.Abs(speed);
            if (CarDirectionX == Direction.Left && CarAxis == Axis.Horizontal)
                speed *= -1;
            else if (CarDirectionY == Direction.Bottom && CarAxis == Axis.Vertical)
                speed *= -1;

            _rb.MovePosition(_rb.position + whichWay * speed * Time.fixedDeltaTime);
        }

    }

    public void OnTriggerStay(Collider other)
    {
        //�������� �� ������������ ���� ������������
        if (other.CompareTag("Car") || other.CompareTag("Barrier"))
        {
            //������ ������ ���� � ���������� ���
            Destroy(
                Instantiate(CrashEffect, other.ClosestPoint(transform.position), Quaternion.Euler(new Vector3(270f, 0, 0))),
                1.5f);

            //���������� ���� ����� ������������
            if (_audio.clip != AudioCrash && _audio.isPlaying)
            {
                _audio.Stop();
                _audio.clip = AudioCrash;
                _audio.Play();
            }


            if (CarAxis == Axis.Horizontal && isClicked)
            {
                float adding = CarDirectionX == Direction.Left ? 0.5f : -0.5f;
                transform.position = new Vector3(transform.position.x, 0, transform.position.z + adding);
            }

            if (CarAxis == Axis.Vertical && isClicked)
            {
                float adding = CarDirectionY == Direction.Top ? 0.5f : -0.5f;
                transform.position = new Vector3(transform.position.x + adding, 0, transform.position.z);
            }


            isClicked = false;
        }
    }

}
