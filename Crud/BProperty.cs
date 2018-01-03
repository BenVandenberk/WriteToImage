using System;

namespace SchrijvenOpAfbeelding.Crud
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BProperty : Attribute
    {
        public string Description { get; set; }
    }
}