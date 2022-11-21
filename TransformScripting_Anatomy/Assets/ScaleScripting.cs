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
        //값이 음수인 경우 -> 양수로 변환 
        if (scaleY < 0)
            scaleY = -scaleY;

        if (orgScaleY < 0)
            orgScaleY = -orgScaleY;

        //cnt : 몇번 나누어지는지 구하기 위해 
        int i;
        int cnt = 1;

        if (orgScaleY >= scaleY) //num1이 num2보다 큰 경우 
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

        //비례식 구하기 
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

        //비율 구하기  
        float x;

        x = num4 * 1 / num3;
        //printf("x : %.2f", x);
        Debug.Log(x);
        obj1.transform.localScale = new Vector3(1, 1, x);
    }

   
}
