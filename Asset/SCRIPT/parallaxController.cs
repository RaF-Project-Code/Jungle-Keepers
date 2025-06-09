using UnityEngine;

public class parallaxController : MonoBehaviour
{
    Transform cam; // camera transform
    Vector3 camStartPos;
    float distance; // distance between the camera and the object

    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed; // the proportion of the camera's movement to the object's movement

    float farthestBack;

    [Range(0.01f, 0.5f)]
    public float parallaxSpeed; // speed of the parallax effect


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i]=transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(backCount); // Find the farthest background and calculate the speed of each background
    }

    void BackSpeedCalculate(int backCount) // Find the farthest background and calculate the speed of each background
    {
        for (int i = 0; i < backCount; i++)
        {
            if ((backgrounds[i].transform.position.z - cam.position.z) >farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for (int i = 0; i < backCount; i++) // Set the speed of each background
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / farthestBack;
        }
    }

    private void LateUpdate()
    {
        distance = cam.position.x - camStartPos.x; // distance moved by the camera
        transform.position = new Vector3(cam.position.x, transform.position.y, transform.position.z); // move the object with the camera

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed; // speed of the background
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed); // set the texture offset of the background
        }
    }
}
