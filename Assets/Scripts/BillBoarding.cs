using UnityEngine;

public class BillBoarding : MonoBehaviour

{
    public enum BillBoardType { LookAtCamera, CameraForward };
    [SerializeField] private BillBoardType billboardtype;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
        }
    }
}
