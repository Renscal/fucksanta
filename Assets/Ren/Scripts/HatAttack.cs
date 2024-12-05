using UnityEngine;

public class AttackHat : MonoBehaviour {
    [Header("Gameobjects")]
    public GameObject attackHat;
    public GameObject attackHatDad;
    public GameObject santaHat;
    public GameObject point1;
    public GameObject point2;

    [Header("Configurations")]
    public float attackInterval;
    public float hatAttackSpeed1;
    public float hatAttackSpeed2;

    // Game components
    Transform santaHatTF;
    Transform attackHatTF;
    Transform attackHatDadTF;
    Transform point1TF;
    Transform point2TF;
    Animator attackHatAnim;

    float t;
    int state = 0; // 0: moving to point1, 1: moving to point2
    bool isMoving = false; // Flag to control movement

    void Start() {
        santaHatTF = santaHat.transform;
        attackHatTF = attackHat.transform;
        attackHatDadTF = attackHatDad.transform;
        attackHatAnim = attackHat.GetComponent<Animator>();
        attackHat.SetActive(false); // Start inactive
        point1TF = point1.transform;
        point2TF = point2.transform;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.O)) {
            // Initialize movement
            santaHat.SetActive(false);
            attackHat.SetActive(true);

            attackHatDadTF.rotation = Quaternion.Euler(0, santaHatTF.eulerAngles.y, 0);

            t = 0;
            state = 0; // Start moving to point1
            isMoving = true; // Enable movement
        }

        if (isMoving) {
            t += Time.deltaTime * hatAttackSpeed1;
            t = Mathf.Clamp01(t);

            if (state == 0) {
                // Move towards point1
                attackHatTF.position = Vector3.Slerp(santaHatTF.position, new Vector3(point1TF.position.x, -1, point1TF.position.z), t);

                if (t >= 1) {
                    Debug.Log("Hat reached Point1");
                    t = 0; // Reset t for next move
                    state = 1; // Switch to moving to point2
                }
            }
            else if (state == 1) {
                // Move towards point2
                attackHatTF.position = Vector3.Slerp(new Vector3(point1TF.position.x, -1, point1TF.position.z), new Vector3(point2TF.position.x, -1, point2TF.position.z), t);

                if (t >= 1) {
                    Debug.Log("Hat reached Point2");
                    isMoving = false; // Stop movement (or loop if desired)
                }
            }
        }
    }
}
