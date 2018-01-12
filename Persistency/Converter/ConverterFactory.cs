using System;
using System.CodeDom;
using System.Collections.Generic;

namespace SchrijvenOpAfbeelding.Persistency.Converter
{
    public class ConverterFactory
    {
        private static ConverterFactory single;

        

        public static ConverterFactory Single => single ?? (single = new ConverterFactory());

        private Dictionary<Type, Converter<Type>> converters;

        private ConverterFactory() {
            this.converters = new Dictionary<Type, Converter<Type>>();
        }


    }
}