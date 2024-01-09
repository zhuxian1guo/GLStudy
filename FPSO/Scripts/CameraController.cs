using DG.Tweening;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Transform target;
    public float xSpeed = 200, ySpeed = 200, mSpeed = 10;  //�ֱ�����������������ת�ٶȣ���Ұ�����ٶ�
    public float yMinLimit = 5, yMaxLimit = 50; //�����������С�����ת��
    public float distance = 50, minDistance = 2, maxDistance = 100; //���ó�ʼ״̬�������Ұ��Χ���Լ�����������ŵ���С���Χ
    public bool needDamping = true; //�Ƿ���Ҫ�������Ч��
    float damping = 5f; //�������ϵ��
    public float x = 0f; //��ʼ״̬�����������ת�Ƕ�
    public float y = 0f; //��ʼ״̬�����������ת�Ƕ�
    public bool isS;

    private Vector3 m_mouseMovePos;
    private Camera camera;

    public static CameraController _instance;
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        camera = GetComponent<Camera>();
    }


    // �������������
    public float sensitivity = 2f;
    // ��������ƶ��ٶ�
    public float moveSpeed = 3f; 
    // Update is called once per frame
    void LateUpdate()
    {

        if (target)
        {
            //�ƶ����
            if (isS&&Input.GetMouseButton(2))
            {
                float mouseX = Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;
                Vector3 move = new Vector3(-mouseX, -mouseY, 0);
          
                move = transform.localToWorldMatrix.MultiplyVector(move);
                target.Translate(move, Space.World);
            }

            if (Input.GetMouseButton(1))
            {
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                y = ClampAngle(y, yMinLimit, yMaxLimit);
            }
            distance -= Input.GetAxis("Mouse ScrollWheel") * mSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);

            Quaternion rotation = Quaternion.Euler(y, x, 0.0f);  //
            Vector3 disVector = new Vector3(0f, 0f, -distance);
            Vector3 position = rotation * disVector + target.position;

            if (needDamping)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * damping);
                transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * damping);
            }
            else
            {
                transform.rotation = rotation;
                transform.position = position;
            }

        }
    }
    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

    public void FlyAni(float dis,float time)
    {
        DOTween.To(() => distance, x => distance = x, dis, time);
    }

}
