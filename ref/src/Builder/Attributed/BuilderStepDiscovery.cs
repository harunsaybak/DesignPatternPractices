using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
namespace MarvellousWorks.PracticalPattern.Builder.Attributed
{
    public class BuildStep
    {
        public MethodInfo Method { get; set; }
        public int Times { get; set; }
        public int Sequence { get; set; }
    }

    /// <summary>
    /// ͨ��������ĳ���������BuildPart()����ָ����Ϣ�Ĺ�������
    /// </summary>
    public class BuilderStepDiscovery
    {
        /// <summary>
        /// �����Ѿ���������������Ϣ
        /// </summary>
        static IDictionary<Type, IEnumerable<BuildStep>> cache =
            new Dictionary<Type, IEnumerable<BuildStep>>();

        /// <summary>
        /// �Ǽ���Щ�Ѿ��϶�û��Build Step ���Ե�����
        /// </summary>
        static IList<Type> errorCache = new List<Type>();

        /// <summary>
        /// �������������� T ����ִ��BuildPart()���Զ����ֻ���
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BuildStep> DiscoveryBuildSteps(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
            if (errorCache.Contains(type)) return null;
            if (!cache.ContainsKey(type))
            {
                var aType = typeof(BuildStepAttribute);
                var methods = from item in
                    (from method in type.GetMethods()
                     where method.IsDefined(aType, false)
                     select new
                     {
                         M = method,
                         A = (BuildStepAttribute)method.GetCustomAttributes(aType, false).First()
                     }
                     )orderby item.A.Sequence
                              select new BuildStep
                              {
                                  Method = item.M,
                                  Times = item.A.Times,
                                  Sequence = item.A.Sequence
                              };
                if (methods.Count() == 0)
                {
                    errorCache.Add(type); // register invalidate type
                    return null;
                }
                else
                {
                    cache.Add(type, methods); // register validate type
                    return methods;
                }
            }
            else
                return cache[type];
        }
    }
}
