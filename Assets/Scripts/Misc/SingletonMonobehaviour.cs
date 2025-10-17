
using UnityEngine;

public abstract class SingletonMonobehaviour<T> : MonoBehaviour where T : MonoBehaviour
    //在创建抽象类时需要使用abstract关键字
    //SingletonMonoBehaviour<T> 是一个用于 Unity 游戏的泛型单例模式实现，专门设计用于继承自 MonoBehaviour 组件。
    //其核心作用是确保在 Unity 场景中仅存在一个 T 类型的实例，并提供了创建、获取该实例的方法。
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
    // 检查实例是否已存在
    // 如果不存在，将当前对象转换为T类型并赋值给instance使用as操作符进行安全类型转换
    // 如果已存在实例，销毁当前对象以确保单例

}//4-34 使用单例模式创建角色对象，保证整个游戏中只有一个角色，并且让游戏对象具有全局可访问性。