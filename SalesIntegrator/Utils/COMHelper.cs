using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SalesIntegrator.Utils
{
    public class COMHelper
    {
        /// <summary>
        /// Sets value of dynamic property of given object
        /// </summary>
        /// <typeparam name="T">class or interface of given object</typeparam>
        /// <param name="obj">given object</param>
        /// <param name="type">Type instance representing given object (example: _types["_Recordset"], "Fields"))</param>
        /// <param name="property">name of the object's property</param>
        /// <param name="value">Value to set</param>
        public static void SetPropertyValue<T>(T obj, Type type, string property, object value)
        {
            try
            {
                var props = type.GetProperties();
                var runProps = type.GetRuntimeProperties();
                var propInfo = runProps.Where(p => p.Name.Equals(property)).FirstOrDefault();
                var propType = propInfo.PropertyType;
                var typedValue = System.Convert.ChangeType(value, propType);
                propInfo.SetValue(obj, typedValue);
            }
            catch (Exception e)
            {
                NonBlockingConsole.WriteLine(e.StackTrace);
                try
                {
                    var props = type.GetProperties();
                    var runProps = type.GetRuntimeProperties();
                    var propInfo = runProps.Where(p => p.Name.Equals(property)).FirstOrDefault();
                    var propType = propInfo.PropertyType;
                    var typedValue = System.Convert.ChangeType(value, propType);
                    propInfo.SetValue(obj, typedValue, null);
                }
                catch
                {
                    NonBlockingConsole.WriteLine($"MUST FIND OTHER METHOD INVOKATION FOR {property}");
                }
            }

        }
        /// <summary>
        /// Gets typed property of an object
        /// </summary>
        /// <typeparam name="T">Type of object which property you want to get</typeparam>
        /// <param name="obj">The object that has the property</param>
        /// <param name="type">Type instance representing given object (example: _types["_Recordset"], "Fields"))</param>
        /// <param name="property">Name of the property to return</param>
        /// <returns></returns>
        public static object GetPropertyValue<T>(T obj, Type type, string property)
        {
            try
            {
                var props = type.GetProperties();
                var runProps = type.GetRuntimeProperties();
                var propInfo = runProps.Where(p => p.Name.Equals(property)).FirstOrDefault();
                var propType = propInfo.PropertyType;
                //var typedValue = System.Convert.ChangeType(value, propType);
                return propInfo.GetValue(obj);
            }
            catch (Exception e)
            {
                NonBlockingConsole.WriteLine(e.StackTrace);
            }
            return null;


        }

        public static object GetFieldValue<T>(T obj, Type type, string field)
        {
            try
            {
                var fields = type.GetFields();
                var runFields = type.GetRuntimeFields();
                var fieldInfo = runFields.Where(p => p.Name.Equals(field)).FirstOrDefault();
                var fieldType = fieldInfo.FieldType;
                return fieldInfo.GetValue(obj);
            }
            catch (Exception e)
            {
                NonBlockingConsole.WriteLine(e.StackTrace);
            }
            return null;
        }

        public static object GetMemberValue<T>(T obj, Type type, string member)
        {
            try
            {
                var members = type.GetMembers();
                var runMembers = type.GetRuntimeFields();
                var memberInfo = runMembers.Where(p => p.Name.Equals(member)).FirstOrDefault();
                var memberType = memberInfo.MemberType;
                //var typedValue = System.Convert.ChangeType(value, propType);
                return memberInfo.GetValue(obj);
            }
            catch (Exception e)
            {
                NonBlockingConsole.WriteLine(e.StackTrace);
            }
            return null;
        }
    }
}
