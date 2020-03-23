//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Polynomial.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419


using Antlr4.Runtime.Misc;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

namespace Polynomial.WebApi.Traversing
{
	/// <summary>
	/// This class provides an empty implementation of <see cref="IPolynomialListener"/>,
	/// which can be extended to create a listener which only needs to handle a subset
	/// of the available methods.
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
	[System.CLSCompliant(false)]
	public partial class PolynomialBaseListener : IPolynomialListener {
		/// <summary>
		/// Enter a parse tree produced by the <c>addSub</c>
		/// labeled alternative in <see cref="PolynomialParser.polynomial"/>.
		/// <para>The default implementation does nothing.</para>
		/// </summary>
		/// <param name="context">The parse tree.</param>
		public virtual void EnterAddSub([NotNull] PolynomialParser.AddSubContext context) { }
		/// <summary>
		/// Exit a parse tree produced by the <c>addSub</c>
		/// labeled alternative in <see cref="PolynomialParser.polynomial"/>.
		/// <para>The default implementation does nothing.</para>
		/// </summary>
		/// <param name="context">The parse tree.</param>
		public virtual void ExitAddSub([NotNull] PolynomialParser.AddSubContext context) { }
		/// <summary>
		/// Enter a parse tree produced by the <c>parens</c>
		/// labeled alternative in <see cref="PolynomialParser.polynomial"/>.
		/// <para>The default implementation does nothing.</para>
		/// </summary>
		/// <param name="context">The parse tree.</param>
		public virtual void EnterParens([NotNull] PolynomialParser.ParensContext context) { }
		/// <summary>
		/// Exit a parse tree produced by the <c>parens</c>
		/// labeled alternative in <see cref="PolynomialParser.polynomial"/>.
		/// <para>The default implementation does nothing.</para>
		/// </summary>
		/// <param name="context">The parse tree.</param>
		public virtual void ExitParens([NotNull] PolynomialParser.ParensContext context) { }
		/// <summary>
		/// Enter a parse tree produced by the <c>realMonomial</c>
		/// labeled alternative in <see cref="PolynomialParser.monomial"/>.
		/// <para>The default implementation does nothing.</para>
		/// </summary>
		/// <param name="context">The parse tree.</param>
		public virtual void EnterRealMonomial([NotNull] PolynomialParser.RealMonomialContext context) { }
		/// <summary>
		/// Exit a parse tree produced by the <c>realMonomial</c>
		/// labeled alternative in <see cref="PolynomialParser.monomial"/>.
		/// <para>The default implementation does nothing.</para>
		/// </summary>
		/// <param name="context">The parse tree.</param>
		public virtual void ExitRealMonomial([NotNull] PolynomialParser.RealMonomialContext context) { }
		/// <summary>
		/// Enter a parse tree produced by the <c>double</c>
		/// labeled alternative in <see cref="PolynomialParser.monomial"/>.
		/// <para>The default implementation does nothing.</para>
		/// </summary>
		/// <param name="context">The parse tree.</param>
		public virtual void EnterDouble([NotNull] PolynomialParser.DoubleContext context) { }
		/// <summary>
		/// Exit a parse tree produced by the <c>double</c>
		/// labeled alternative in <see cref="PolynomialParser.monomial"/>.
		/// <para>The default implementation does nothing.</para>
		/// </summary>
		/// <param name="context">The parse tree.</param>
		public virtual void ExitDouble([NotNull] PolynomialParser.DoubleContext context) { }
		/// <summary>
		/// Enter a parse tree produced by the <c>integer</c>
		/// labeled alternative in <see cref="PolynomialParser.monomial"/>.
		/// <para>The default implementation does nothing.</para>
		/// </summary>
		/// <param name="context">The parse tree.</param>
		public virtual void EnterInteger([NotNull] PolynomialParser.IntegerContext context) { }
		/// <summary>
		/// Exit a parse tree produced by the <c>integer</c>
		/// labeled alternative in <see cref="PolynomialParser.monomial"/>.
		/// <para>The default implementation does nothing.</para>
		/// </summary>
		/// <param name="context">The parse tree.</param>
		public virtual void ExitInteger([NotNull] PolynomialParser.IntegerContext context) { }

		/// <inheritdoc/>
		/// <remarks>The default implementation does nothing.</remarks>
		public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
		/// <inheritdoc/>
		/// <remarks>The default implementation does nothing.</remarks>
		public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
		/// <inheritdoc/>
		/// <remarks>The default implementation does nothing.</remarks>
		public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
		/// <inheritdoc/>
		/// <remarks>The default implementation does nothing.</remarks>
		public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
	}
}
