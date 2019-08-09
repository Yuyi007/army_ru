
// #define PROFILE_FILE

using UnityEngine;

using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;


#if NETFX_CORE
using System.Collections;
using System.Collections.Generic;
#endif

namespace CinemaSuite.Common
{
    /// A helper class for reflection calls, that allows for calls on multiple platforms.
    public static class ReflectionHelper
    {
        private static Dictionary<Type, Dictionary<string, PropertyInfo>> _typePropertyDict = new Dictionary<Type, Dictionary<string, PropertyInfo>>();
        private static Dictionary<Type, Dictionary<string, FieldInfo>> _typeFieldDict = new Dictionary<Type, Dictionary<string, FieldInfo>>();
        private static Dictionary<Type, Dictionary<string, MemberInfo[]>> _typeMemberDict = new Dictionary<Type, Dictionary<string, MemberInfo[]>>();
        private static bool useCodeGen = true;

        public static bool UseCodeGen
        {
            get
            {
                return useCodeGen;
            }
        }

        public static Assembly[] GetAssemblies()
        {
#if PROFILE_FILE
            Profiler.BeginSample("ReflectionHelper.GetAssemblies");
#endif // PROFILE_FILE
            Assembly[] result;
#if NETFX_CORE
                var assemblies = new List<Assembly>();
                var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                var files = folder.GetFilesAsync();
                files.AsTask().Wait();

                var fileResults = files.GetResults();
                for (int i = 0; i < fileResults.Count; ++i)
                {
                    var file = fileResults[i];
                    if (file.FileType == ".dll" || file.FileType == ".exe")
                    {
				        try
				        {
				            var filename = file.Name.Substring(0, file.Name.Length - file.FileType.Length);
				            AssemblyName name = new AssemblyName { Name = filename };
				            Assembly assembly = Assembly.Load(name);
				            assemblies.Add(assembly);
				        }
				        catch (Exception)
				        {
				            continue;
				        }
				    }
			    }
                result = assemblies.ToArray();
#else
            result = AppDomain.CurrentDomain.GetAssemblies();
#endif
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
            return result;
        }

        public static Type[] GetTypes(Assembly assembly)
        {
#if PROFILE_FILE
            Profiler.BeginSample("ReflectionHelper.GetTypes");
#endif // PROFILE_FILE
            Type[] result;
#if NETFX_CORE
                var types = new List<Type>();
                foreach (var t in assembly.GetTypes())
                {
                    types.Add(t);
                }
                result = types.ToArray();
#else
            result = assembly.GetTypes();
#endif
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
            return result;
        }

        public static bool IsSubclassOf(Type type, Type c)
        {
#if PROFILE_FILE
            Profiler.BeginSample("ReflectionHelper.IsSubclassOf");
#endif // PROFILE_FILE
            bool result;
#if NETFX_CORE
	        result = type.GetTypeInfo().IsSubclassOf(c);
#else
            result = type.IsSubclassOf(c);
#endif
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
            return result;
        }

        public static MemberInfo[] GetMemberInfo(Type type, string name)
        {
#if PROFILE_FILE
            Profiler.BeginSample("ReflectionHelper.GetMemberInfo");
#endif // PROFILE_FILE


            Dictionary<string, MemberInfo[]> dict = null;
            if (_typeMemberDict.TryGetValue(type, out dict))
            {
                MemberInfo[] result1 = null;
                if (dict.TryGetValue(name, out result1))
                {
#if PROFILE_FILE
                    Profiler.EndSample();
#endif // PROFILE_FILE
                    return result1;
                }
            }


            MemberInfo[] result;
#if NETFX_CORE
                var members = new List<MemberInfo>();
                members.Add(GetField(type, name));
                members.Add(GetProperty(type, name));
                result = members.ToArray();
#else
            result = type.GetMember(name);
#endif
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
            if (dict == null)
            {
                dict = new Dictionary<string, MemberInfo[]>();
                _typeMemberDict[type] = dict;
            }
            dict[name] = result;
            return result;
        }

        public static FieldInfo GetField(Type type, string name)
        {

#if PROFILE_FILE
            Profiler.BeginSample("ReflectionHelper.GetField");
#endif // PROFILE_FILE
            Dictionary<string, FieldInfo> dict = null;
            if (_typeFieldDict.TryGetValue(type, out dict))
            {
                FieldInfo result1 = null;
                if (dict.TryGetValue(name, out result1))
                {
#if PROFILE_FILE
                    Profiler.EndSample();
#endif // PROFILE_FILE
                    return result1;
                }
            }


            FieldInfo result;
#if NETFX_CORE
                result = type.GetTypeInfo().GetDeclaredField(name);
#else
            result = type.GetField(name);
#endif
            if (dict == null)
            {
                dict = new Dictionary<string, FieldInfo>();
                _typeFieldDict[type] = dict;
            }

            dict[name] = result;

#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE

            return result;
        }

        public static PropertyInfo GetProperty(Type type, string name)
        {

#if PROFILE_FILE
            Profiler.BeginSample("ReflectionHelper.GetProperty");
#endif // PROFILE_FILE
            Dictionary<string, PropertyInfo> dict = null;
            if (_typePropertyDict.TryGetValue(type, out dict))
            {
                PropertyInfo result1 = null;
                if (dict.TryGetValue(name, out result1))
                {
#if PROFILE_FILE
                    Profiler.EndSample();
#endif // PROFILE_FILE
                    return result1;
                }
            }


            PropertyInfo result;
#if NETFX_CORE
		result = type.GetTypeInfo().GetDeclaredProperty(name);
#else
            result = type.GetProperty(name);
#endif
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
            if (dict == null)
            {
                dict = new Dictionary<string, PropertyInfo>();
                _typePropertyDict[type] = dict;
            }

            dict[name] = result;

            return result;
        }

        public static T[] GetCustomAttributes<T>(Type type, bool inherited) where T : Attribute
        {
#if PROFILE_FILE
            Profiler.BeginSample("ReflectionHelper.GetCustomAttributes");
#endif // PROFILE_FILE
            T[] result;
#if NETFX_CORE
		result = (T[]) type.GetTypeInfo().GetCustomAttributes(typeof(T), inherited);
#else
            result = (T[])type.GetCustomAttributes(typeof(T), inherited);
#endif
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
            return result;
        }
    }
}