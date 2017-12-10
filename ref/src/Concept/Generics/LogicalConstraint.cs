namespace MarvellousWorks.PracticalPattern.Concept.Generics
{
    /// <summary>
    /// ģ�� where T : A || B 
    /// </summary>
    /// <remarks>֮ǰOrA��OrB���������������ͣ�Ϊ���ҵ����ߵĹ�ͬ�㣬���ⶨ����һ��INewComer�ӿڣ�����Χǿ�ƽ�����һ���µġ��򡱹�ϵ</remarks>
    interface INewComer { }
    class OrA : INewComer { }
    class OrB : INewComer { }
    class OrClient<T> where T : INewComer { }


    /// <summary>
    /// ģ�� where T : A && B
    /// </summary>
    interface ILayer11 { }
    interface ILayer12 { }
    interface ILayer2 : ILayer11, ILayer12 { }
    class AndA : ILayer11 { }
    class AndB : ILayer12 { }
    class AndClient<T> where T : ILayer2 { }
}
