
using UnityEngine;

public static class Settings//声明为公开且静态的内部类
{
    // Player Movement玩家移动（添加两个常量）
    public const float runningSpeed = 5.333f;
    public const float walkingSpeed = 2.666f;

    // Player Animation Parameters(共享动画参数)

    //例子：public static int xInput;解释
    //public - 访问修饰符，表示这个变量是公开的，可以从任何其他类中访问
    //static - 静态修饰符，表示这个变量属于类本身，而不是类的实例。所有该类的对象共享同一个xInput变量
    //int - 数据类型，表示这是一个整数类型的变量
    //xInput - 变量名称，通常用来表示某种输入值

    public static int xInput;
    public static int yInput;
    public static int isWalking;
    public static int isRunning;
    public static int toolEffect;
    public static int isUsingToolRight;
    public static int isUsingToolLeft;
    public static int isUsingToolUp;
    public static int isUsingToolDown;
    public static int isLiftingToolRight;
    public static int isLiftingToolLeft;
    public static int isLiftingToolUp;
    public static int isLiftingToolDown;
    public static int isSwingingToolRight;
    public static int isSwingingToolLeft;
    public static int isSwingingToolUp;
    public static int isSwingingToolDown;
    public static int isPickingRight;
    public static int isPickingLeft;
    public static int isPickingUp;
    public static int isPickingDown;

    // Shared Animation Parameters
    //这个类将所有动画参数集中管理，便于在动画状态机和脚本中统一调用，提高代码可维护性。
    //在实际使用中，这些静态变量通常会在游戏初始化时通过Animator.StringToHash方法转换为哈希值，以提高动画状态机的性能
    public static int idleUp;
    public static int idleDown;
    public static int idleLeft;
    public static int idleRight;


    // static constructor（静态构造函数）
    static Settings()
    {
        // Player Animation Parameters(玩家动画参数)
        //在Unity引擎中，Animator.StringToHash专门用于动画状态和参数的快速访问
        //当使用Animator控制动画时，
        //、可以通过字符串名称或整数HashID两种方式引用状态和参数，而使用哈希值能够避免重复的字符串比较操作，显著提升动画系统的运行效率

        xInput = Animator.StringToHash("xInput");
        yInput = Animator.StringToHash("yInput");
        isWalking = Animator.StringToHash("isWalking");
        isRunning = Animator.StringToHash("isRunning");
        toolEffect = Animator.StringToHash("toolEffect");
        isUsingToolRight = Animator.StringToHash("isUsingToolRight");
        isUsingToolLeft = Animator.StringToHash("isUsingToolLeft");
        isUsingToolUp = Animator.StringToHash("isUsingToolUp");
        isUsingToolDown = Animator.StringToHash("isUsingToolDown");
        isLiftingToolRight = Animator.StringToHash("isLiftingToolRight");
        isLiftingToolLeft = Animator.StringToHash("isLiftingToolLeft");
        isLiftingToolUp = Animator.StringToHash("isLiftingToolUp");
        isLiftingToolDown = Animator.StringToHash("isLiftingToolDown");
        isSwingingToolRight = Animator.StringToHash("isSwingingToolRight");
        isSwingingToolLeft = Animator.StringToHash("isSwingingToolLeft");
        isSwingingToolUp = Animator.StringToHash("isSwingingToolUp");
        isSwingingToolDown = Animator.StringToHash("isSwingingToolDown");
        isPickingRight = Animator.StringToHash("isPickingRight");
        isPickingLeft = Animator.StringToHash("isPickingLeft");
        isPickingUp = Animator.StringToHash("isPickingUp");
        isPickingDown = Animator.StringToHash("isPickingDown");

        // Shared Animation parameters(共享动画参数)
        idleUp = Animator.StringToHash("idleUp");
        idleDown = Animator.StringToHash("idleDown");
        idleLeft = Animator.StringToHash("idleLeft");
        idleRight = Animator.StringToHash("idleRight");
    }

}
