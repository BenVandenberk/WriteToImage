using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace SchrijvenOpAfbeelding.Persistency.Converter
{
    /// <summary>
    /// Abstract base class for converting strings to objects of type TOutput
    /// </summary>
    /// <typeparam name="TOutput">The type of object to convert to</typeparam>
    public abstract class Converter<TOutput>
    {
        public string Input { get; }

        Converter(string input) {
            this.Input = input;
        }

        public virtual object Convert() {
            var @switch = new Dictionary<Type, Func<Type, object>> {
                { typeof(string), t => this.Input },
                { typeof(int), t => int.Parse(this.Input) },
                { typeof(double), t => double.Parse(this.Input) },
                { typeof(short), t => short.Parse(this.Input) }
            };

            return @switch[typeof(TOutput)];
        }
    }
}