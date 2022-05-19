using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class ClassElement
    {
        public string ClassName;
        public List<(string,string)> properies = new List<(string, string)>();
        private const int indentSize = 2;

        public override string ToString()
        {
            var sb = new StringBuilder();
            var indent = new string(' ', indentSize);

            sb.AppendLine($"public class {ClassName}");
            sb.AppendLine("{");
            foreach (var proper in properies)
            {
                sb.AppendLine($"{indent}public {proper.Item1} {proper.Item2};");
            }
            sb.AppendLine("}");
            return sb.ToString();

        }
    }

    public  class CodeBuilder
    {
        private ClassElement classElement = new ClassElement(); 
        public CodeBuilder(string className)
        {
            this.classElement.ClassName = className;
        }

        public CodeBuilder AddField(string name, string type)
        {
            classElement.properies.Add((type, name));
            return this;
        }

        public override string ToString()
        {
            return classElement.ToString();
        }
    }
}
