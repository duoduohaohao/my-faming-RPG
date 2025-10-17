
using UnityEngine;

public abstract class SingletonMonobehaviour<T> : MonoBehaviour where T : MonoBehaviour
    //�ڴ���������ʱ��Ҫʹ��abstract�ؼ���
    //SingletonMonoBehaviour<T> ��һ������ Unity ��Ϸ�ķ��͵���ģʽʵ�֣�ר��������ڼ̳��� MonoBehaviour �����
    //�����������ȷ���� Unity �����н�����һ�� T ���͵�ʵ�������ṩ�˴�������ȡ��ʵ���ķ�����
{
    private static T instance;

    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // ���ʵ���Ƿ��Ѵ���
    // ��������ڣ�����ǰ����ת��ΪT���Ͳ���ֵ��instanceʹ��as���������а�ȫ����ת��
    // ����Ѵ���ʵ�������ٵ�ǰ������ȷ������

}//4-34 ʹ�õ���ģʽ������ɫ���󣬱�֤������Ϸ��ֻ��һ����ɫ����������Ϸ�������ȫ�ֿɷ����ԡ�