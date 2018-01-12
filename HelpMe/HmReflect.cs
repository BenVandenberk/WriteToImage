using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SchrijvenOpAfbeelding.Crud;
using SchrijvenOpAfbeelding.Reflection;

namespace SchrijvenOpAfbeelding.HelpMe
{
    public class HmReflect
    {
        private static HmReflect single;
        public static HmReflect Single => single ?? (single = new HmReflect());

        private HmReflect() {
            
        }

        public string AttributeStringData(Type type, Type attributeType, string attributeDataName) {
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



        public List<PropertyInfo> PropertiesWithAttribute(Type type, Type attributeType) {
            return type.GetProperties().Where(prop => prop.IsDefined(attributeType, false)).ToList();
        }

        public List<PropertyInfo> PropertiesWithBPropertyAttribute(Type type) {
            return PropertiesWithAttribute(type, typeof(BProperty));
        }

        public PropertyInfo BPropertyWithDescription(Type type, string desc) {
            return PropertiesWithBPropertyAttribute(type)
                .Find(prop => prop.GetCustomAttribute<BProperty>().Description.Equals(desc));
        } 

        public T AttributeOfType<T>(PropertyInfo property) where T : Attribute {
            return (T) property.GetCustomAttribute(typeof(T));
        }
        
        public T PropertyValue<T>(Object obj, PropertyInfo property) {
            return (T) property.GetValue(obj);
        }

        public string PropertyValueString(Object obj, PropertyInfo property) {
            return property.GetValue(obj).ToString();
        }
    }
}