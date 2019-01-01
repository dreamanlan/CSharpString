using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Symbols;

namespace RoslynTool
{
    internal class CSharpCodeWalker : CSharpSyntaxWalker
    {
        public List<string> StringList
        {
            get { return m_StringList; }
        }
        public override void VisitLiteralExpression(LiteralExpressionSyntax node)
        {
            var oper = m_Model.GetOperation(node);
            if (oper.ConstantValue.HasValue) {
                string str = oper.ConstantValue.Value as string;
                if (null != str) {

                }
            }
            base.VisitLiteralExpression(node);
        }

        public CSharpCodeWalker(SemanticModel model)
        {
            m_Model = model;
        }

        private SemanticModel m_Model = null;
        private List<string> m_StringList = new List<string>();
    }
}
