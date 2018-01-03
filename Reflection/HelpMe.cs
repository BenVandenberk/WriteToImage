using System;
using System.Linq;
using System.Reflection;
using SchrijvenOpAfbeelding.Crud;

namespace SchrijvenOpAfbeelding.Reflection
{
    public static class HelpMe
    {
        public static string AttributeStringData(Object obj, Type attributeType, string attributeDataName) {
            CustomAttributeData customAttributeData = obj.GetType().CustomAttributes
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
    }
}