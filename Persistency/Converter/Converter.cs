using System;

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

        public virtual TOutput Convert() {
            throw new NotImplementedException();
        }
    }
}