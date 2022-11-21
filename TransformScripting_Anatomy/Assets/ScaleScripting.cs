using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScripting : MonoBehaviour
{
    public GameObject obj1;

    float orgScaleY = 3400F; //org model data
    float scaleY = 1700.9F; //unity model 
   
    float num3, num4;


    // Start is called before the first frame update
    void Start()
    {
        //���� ������ ��� -> ����� ��ȯ 
        if (scaleY < 0)
            scaleY = -scaleY;

        if (orgScaleY < 0)
            orgScaleY = -orgScaleY;

        //cnt : ��� ������������ ���ϱ� ���� 
        int i;
        int cnt = 1;

        if (orgScaleY >= scaleY) //num1�� num2���� ū ��� 
        {
            for (i = 1; i <= orgScaleY; i++)
            {
                if (orgScaleY% i == 0 && scaleY% i == 0)
                    cnt++;

            }
        }
        else
        {
            for (i = 1; i <= scaleY; i++)
            {
                if (orgScaleY% i == 0 && scaleY%i == 0)
                    cnt++;

            }
        }

        //��ʽ� ���ϱ� 
        if (cnt == 1)
        {
            num3 = orgScaleY;
            num4 = scaleY;
        }
        else
        {
            for (i = 1; i <= orgScaleY; i++)
            {
                if (orgScaleY% i == 0 && scaleY% i == 0)
                {
                    num3 = orgScaleY / i;
                    num4 = scaleY / i;
                }

            }
        }

        //printf("%f : %f\n", num3, num4);

        //���� ���ϱ�  
        float x;

        x = num4 * 1 / num3;
        //printf("x : %.2f", x);
        Debug.Log(x);
        obj1.transform.localScale = new Vector3(1, 1, x);
    }

   
}
