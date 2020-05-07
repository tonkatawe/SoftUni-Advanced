
using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        var result = new StringBuilder();

        Type classType = Type.GetType($"{investigatedClass}");
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public |
                                                      BindingFlags.Static);

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        result.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (var field in classFields.Where(f => requestedFields.Contains(f.Name)))
        {
            result.AppendLine($"{field.Name} == {field.GetValue(classInstance)}");
        }
        return result.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string nameOfClass)
    {
        var result = new StringBuilder();
        Type classType = Type.GetType($"{nameOfClass}");
        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (FieldInfo field in classFields)
        {
            result.AppendLine($"{field.Name} must be private!");
        }
        foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            result.AppendLine($"{method.Name} have to be public!");
        }

        foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            result.AppendLine($"{method.Name} have to be private!");
        }


        return result.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string nameOfClass)
    {
        var result = new StringBuilder();
        Type classType = Type.GetType($"{nameOfClass}");
        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        result.AppendLine($"All Private Methods of Class: {nameOfClass}");
        result.AppendLine($"Base Class: {classType.BaseType.Name}");
        foreach (MethodInfo method in classMethods)
        {
            result.AppendLine(method.Name);
        }

        return result.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string nameOfClass)
    {
        var result = new StringBuilder();
        Type classType = Type.GetType($"{nameOfClass}");
        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        foreach (MethodInfo method in classMethods.Where(m=>m.Name.StartsWith("get")))
        {
            result.AppendLine($"{method.Name} will return {method.ReturnType}");
           
        }

        foreach (MethodInfo method in classMethods.Where(m=>m.Name.StartsWith("set")))
        {
            result.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }
        return result.ToString().TrimEnd();
    }
}

