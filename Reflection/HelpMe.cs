using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SchrijvenOpAfbeelding.Crud;

namespace SchrijvenOpAfbeelding.Reflection
{
    public static class HelpMe
    {
        public static string AttributeStringData(Type type, Type attributeType, string attributeDataName) {
            CustomAttributeData customAttributeData = type.CustomAttributes
                .FirstOrDefault(attr => attr.AttributeType.Equals(attributeType));

            if (customAttributeData == null) {
                throw new BReflectionException("Cannot initialise an object of type PropertyUpdateMenu for classes are not annotated with the BClass attribute");
            }

            CustomAttributeNamedArgument customAttributeNamedArgument =
                customAttributeData.NamedArguments.FirstOrDefault(arg => arg.MemberName.Equals(attributeDataName));

            if (customAttributeNamedArgument == null) {
                throw new BReflectionException($"Could not find attribute argument named {attributeDataName}");
            }

            return customAttributeNamedArgument.TypedValue.Value.ToString();
        }

        public static List<PropertyInfo> PropertiesWithAttribute(Type type, Type attributeType) {
            return type.GetProperties().Where(prop => prop.IsDefined(attributeType, false)).ToList();
        }

        public static List<PropertyInfo> PropertiesWithBPropertyAttribute(Type type) {
            return PropertiesWithAttribute(type, typeof(BProperty));
        }

        public static T AttributeOfType<T>(PropertyInfo property) where T : Attribute {
            return (T) property.GetCustomAttribute(typeof(T));
        }
        
        public static T PropertyValue<T>(Object obj, PropertyInfo property) {
            return (T) property.GetValue(obj);
        }

        public static string PropertyValueString(Object obj, PropertyInfo property) {
            return property.GetValue(obj).ToString();
        }
    }
}