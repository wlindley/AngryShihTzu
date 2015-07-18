using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AST
{
    public class TypeFinder
    {
        public Type[] FindTypesWhere(Func<Type, bool> predicate)
        {
            List<Type> types = new List<Type>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
                GetTypesInAssemblyWhere(assembly, predicate, types);

            return types.ToArray();
        }

        public Type[] FindTypesInAssemblyWhere(Assembly assembly, Func<Type, bool> predicate)
        {
            List<Type> types = new List<Type>();
            GetTypesInAssemblyWhere(assembly, predicate, types);
            return types.ToArray();
        }

        private void GetTypesInAssemblyWhere(Assembly assembly, Func<Type, bool> predicate, List<Type> types)
        {
            types.AddRange(assembly.GetTypes().Where(predicate));
        }

        private TypeFinder() { }

        public static TypeFinder GetInstance()
        {
            return new TypeFinder();
        }
    }
}
