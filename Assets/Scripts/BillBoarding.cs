using UnityEngine;

public class BillBoarding : MonoBehaviour

{
    public enum BillBoardType { LookAtCamera, CameraForward };
    [SerializeField] private BillBoardType billboardtype;

    [SerializeField] private bool lockX;
    [SerializeField] private bool lockY;
    [SerializeField] private bool lockZ;

    private Vector3 ogRotation;

    void Awake()
    {
        ogRotation = transform.rotation.eulerAngles;
    }

    void LateUpdate()
    {
        switch (billboardtype)
        {
            case BillBoardType.LookAtCamera:
                transform.LookAt(Camera.main.transform.position, Vector3.up);
                break;
                case BillBoardType.CameraForward: 
                transform.forward = Camera.main.transform.forward;
                break;
            default: break;
        }

        Vector3 rotation = transform.rotation.eulerAngles;
        if (lockX) { rotation.x = ogRotation.x; }
        if (lockY) { rotation.x = ogRotation.y; }
        if (lockZ) { rotation.x = ogRotation.z; }
        transform.rotation = Quaternion.Euler(rotation);
    }
}
