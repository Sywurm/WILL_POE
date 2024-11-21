using UnityEngine;

public class RandomIdleandTalk : MonoBehaviour
{
    public Animator animator;
    private float timer;
    private bool isIdle;

    [SerializeField] private float minTime = 2f; // Minimum time before switching animations
    [SerializeField] private float maxTime = 5f; // Maximum time before switching animations

    private void Start()
    {
      

        // Set initial state
        isIdle = true;
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsTalking", false);

        // Set initial timer
        SetRandomTimer();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            // Toggle between idle and talking
            isIdle = !isIdle;
            animator.SetBool("IsIdle", isIdle);
            animator.SetBool("IsTalking", !isIdle);

            // Reset timer
            SetRandomTimer();
        }
    }

    private void SetRandomTimer()
    {
        timer = Random.Range(minTime, maxTime);
    }
}
