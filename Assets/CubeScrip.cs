using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public float length_per_second = 2.0f;        //�ړ��X�s�[�h

    Vector3 destination;    //�ړI�n�̍��W
    Vector3 start_point;    //�ړ��J�n���̍��W
    float start_time;        //�ړ��J�n���̎���
    float journey_length;   //�ړ�����

    bool is_moving = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.start_point = this.transform.position;

            Vector3 screen_point = Input.mousePosition;
            screen_point.z = 1.0f;
            this.destination = Camera.main.ScreenToWorldPoint(screen_point);

            this.start_time = Time.time;
            this.journey_length = Vector3.Distance(this.start_point, this.destination);

            this.is_moving = true;
            Debug.Log(destination);
        }

        if (this.is_moving)
        {
            float length_by_elapsed_time = (Time.time - this.start_time) * this.length_per_second;
            float fraction_length_by_elapsed_time = length_by_elapsed_time / this.journey_length;

            Vector3 lerp = Vector3.Lerp(this.start_point, this.destination, fraction_length_by_elapsed_time);
            this.transform.position = lerp;

            if (Vector3.Distance(this.transform.position, this.destination) < 0.1f)
            {
                //	�ړI�n�܂ł̋����� 0.1 �����ɂȂ�����ړ�����
                this.is_moving = false;
            }
        }
    }
}