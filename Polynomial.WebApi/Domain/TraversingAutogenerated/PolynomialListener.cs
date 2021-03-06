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
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="PolynomialParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface IPolynomialListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolynomialParser.parse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParse([NotNull] PolynomialParser.ParseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolynomialParser.parse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParse([NotNull] PolynomialParser.ParseContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>canonicalPolynom</c>
	/// labeled alternative in <see cref="PolynomialParser.canonical"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCanonicalPolynom([NotNull] PolynomialParser.CanonicalPolynomContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>canonicalPolynom</c>
	/// labeled alternative in <see cref="PolynomialParser.canonical"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCanonicalPolynom([NotNull] PolynomialParser.CanonicalPolynomContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>equality</c>
	/// labeled alternative in <see cref="PolynomialParser.canonical"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEquality([NotNull] PolynomialParser.EqualityContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>equality</c>
	/// labeled alternative in <see cref="PolynomialParser.canonical"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEquality([NotNull] PolynomialParser.EqualityContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>parens</c>
	/// labeled alternative in <see cref="PolynomialParser.polynomial"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParens([NotNull] PolynomialParser.ParensContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>parens</c>
	/// labeled alternative in <see cref="PolynomialParser.polynomial"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParens([NotNull] PolynomialParser.ParensContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>monom</c>
	/// labeled alternative in <see cref="PolynomialParser.polynomial"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMonom([NotNull] PolynomialParser.MonomContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>monom</c>
	/// labeled alternative in <see cref="PolynomialParser.polynomial"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMonom([NotNull] PolynomialParser.MonomContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>addend</c>
	/// labeled alternative in <see cref="PolynomialParser.monomial"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddend([NotNull] PolynomialParser.AddendContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>addend</c>
	/// labeled alternative in <see cref="PolynomialParser.monomial"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddend([NotNull] PolynomialParser.AddendContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>number</c>
	/// labeled alternative in <see cref="PolynomialParser.monomial"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumber([NotNull] PolynomialParser.NumberContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>number</c>
	/// labeled alternative in <see cref="PolynomialParser.monomial"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumber([NotNull] PolynomialParser.NumberContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PolynomialParser.coefficient"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCoefficient([NotNull] PolynomialParser.CoefficientContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PolynomialParser.coefficient"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCoefficient([NotNull] PolynomialParser.CoefficientContext context);
}
