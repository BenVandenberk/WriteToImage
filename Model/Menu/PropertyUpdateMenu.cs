﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SchrijvenOpAfbeelding.Crud;
using SchrijvenOpAfbeelding.Model.Core;
using static SchrijvenOpAfbeelding.HelpMe.HelpMe;

namespace SchrijvenOpAfbeelding.Model.Menu
{
    /// <summary>
    /// Note that reflection is used to fill out the specifics of this menu. Exceptions of type BReflectionException 
    /// are thrown if any reflect operation fails to obtain a result due to misconfiguration of 
    /// the class of type T
    /// </summary>
    /// <typeparam name="T">The type of Class for which the menu enables modification</typeparam>
    public class PropertyUpdateMenu<T> : ConsoleProgrammaMenu where T : IBClass
    {
        private const string PLACEHOLDER = "£";
        private const string TITEL_TEMPLATE = "*** Pas £ gegevens aan ***";

        private List<PropertyInfo> bProperties;
        private Dictionary<int, PropertyInfo> indexedBProperties;

        public object Obj { get; }

        public PropertyUpdateMenu(object obj) : base(TITEL_TEMPLATE, new List<string>()) {
            this.Obj = obj;
            Configure();
        }

        public override void Kies() {
            base.Kies();

            Console.Clear();
            Console.WriteLine(new PropertyUpdateDetailMenu(this.indexedBProperties[this.Keuze], this.Obj));
        }

        private void Configure() {
            // Type argument
            Type typeArgument = this.GetType().GenericTypeArguments[0];

            // Menu title (=~ class type)
            string typeName =
                HelpMeReflect.AttributeStringData(typeArgument, typeof(BClass), "Description");
            this.Titel = TITEL_TEMPLATE.Replace(PLACEHOLDER, typeName);
            

            // Menu options (=~ class properties)
            this.bProperties = HelpMeReflect.PropertiesWithBPropertyAttribute(typeArgument);
            this.MenuOpties = this.bProperties.Select(HelpMeReflect.AttributeOfType<BProperty>)
                .Select(bProp => bProp.Description)
                .ToList();

            // Associate the order (=~ indexes shown to user) with right properties
            int startIndex = 1;
            this.bProperties.ForEach(prop => this.indexedBProperties.Add(startIndex++, prop));
        }
    }
}