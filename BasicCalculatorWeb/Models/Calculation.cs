using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BasicCalculatorWeb.Models
{

    public class Calculation
    {
        public enum Operators
        {
            [Description("+")]
            Add,

            [Description("−")]
            Subtract,

            [Description("×")]
            Multiply,

            [Description("÷")]
            Divide
        }

        public Operators Operator { get; set; }

        [Display(Name = "First Number:")]
        public double Value1 { get; set; }

        [Display(Name = "Second Number:")]
        public double Value2 { get; set; }

        public double Result { get; set; }

        [Display(Name = "Answer:")]
        public String Message { get; set; }
        
        // Returns the Description attribute of the enum item
        public static string GetSymbol(Enum GenericEnum)
        {
            Type type = GenericEnum.GetType();
            string name = Enum.GetName(type, GenericEnum);
            if (name != null)
            {
                var field = type.GetField(name);
                if (field != null)
                {
                    if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                    {
                        return attr.Description;
                    }
                }
            }
            return GenericEnum.ToString();
        }
    }
}
