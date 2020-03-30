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

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class PolynomialParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, INT=4, DEC=5, VAR=6, SIGN=7, EQUAL=8, WHITESPACE=9, 
		UNKNOWN=10;
	public const int
		RULE_parse = 0, RULE_canonical = 1, RULE_polynomial = 2, RULE_monomial = 3, 
		RULE_coefficient = 4;
	public static readonly string[] ruleNames = {
		"parse", "canonical", "polynomial", "monomial", "coefficient"
	};

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "'^'", null, null, null, null, "'='"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, "INT", "DEC", "VAR", "SIGN", "EQUAL", "WHITESPACE", 
		"UNKNOWN"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Polynomial.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static PolynomialParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public PolynomialParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public PolynomialParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class ParseContext : ParserRuleContext {
		public CanonicalContext canonical() {
			return GetRuleContext<CanonicalContext>(0);
		}
		public ITerminalNode Eof() { return GetToken(PolynomialParser.Eof, 0); }
		public ParseContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_parse; } }
		public override void EnterRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.EnterParse(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.ExitParse(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolynomialVisitor<TResult> typedVisitor = visitor as IPolynomialVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParse(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ParseContext parse() {
		ParseContext _localctx = new ParseContext(Context, State);
		EnterRule(_localctx, 0, RULE_parse);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 10; canonical();
			State = 11; Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class CanonicalContext : ParserRuleContext {
		public CanonicalContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_canonical; } }
	 
		public CanonicalContext() { }
		public virtual void CopyFrom(CanonicalContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class CanonicalPolynomContext : CanonicalContext {
		public PolynomialContext[] polynomial() {
			return GetRuleContexts<PolynomialContext>();
		}
		public PolynomialContext polynomial(int i) {
			return GetRuleContext<PolynomialContext>(i);
		}
		public CanonicalPolynomContext(CanonicalContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.EnterCanonicalPolynom(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.ExitCanonicalPolynom(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolynomialVisitor<TResult> typedVisitor = visitor as IPolynomialVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCanonicalPolynom(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class EqualityContext : CanonicalContext {
		public ITerminalNode EQUAL() { return GetToken(PolynomialParser.EQUAL, 0); }
		public PolynomialContext[] polynomial() {
			return GetRuleContexts<PolynomialContext>();
		}
		public PolynomialContext polynomial(int i) {
			return GetRuleContext<PolynomialContext>(i);
		}
		public EqualityContext(CanonicalContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.EnterEquality(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.ExitEquality(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolynomialVisitor<TResult> typedVisitor = visitor as IPolynomialVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitEquality(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public CanonicalContext canonical() {
		CanonicalContext _localctx = new CanonicalContext(Context, State);
		EnterRule(_localctx, 2, RULE_canonical);
		int _la;
		try {
			State = 29;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,3,Context) ) {
			case 1:
				_localctx = new CanonicalPolynomContext(_localctx);
				EnterOuterAlt(_localctx, 1);
				{
				State = 14;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				do {
					{
					{
					State = 13; polynomial();
					}
					}
					State = 16;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__0) | (1L << INT) | (1L << DEC) | (1L << VAR) | (1L << SIGN))) != 0) );
				}
				break;
			case 2:
				_localctx = new EqualityContext(_localctx);
				EnterOuterAlt(_localctx, 2);
				{
				State = 19;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				do {
					{
					{
					State = 18; polynomial();
					}
					}
					State = 21;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__0) | (1L << INT) | (1L << DEC) | (1L << VAR) | (1L << SIGN))) != 0) );
				State = 23; Match(EQUAL);
				State = 25;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				do {
					{
					{
					State = 24; polynomial();
					}
					}
					State = 27;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__0) | (1L << INT) | (1L << DEC) | (1L << VAR) | (1L << SIGN))) != 0) );
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PolynomialContext : ParserRuleContext {
		public PolynomialContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_polynomial; } }
	 
		public PolynomialContext() { }
		public virtual void CopyFrom(PolynomialContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class ParensContext : PolynomialContext {
		public ITerminalNode SIGN() { return GetToken(PolynomialParser.SIGN, 0); }
		public PolynomialContext[] polynomial() {
			return GetRuleContexts<PolynomialContext>();
		}
		public PolynomialContext polynomial(int i) {
			return GetRuleContext<PolynomialContext>(i);
		}
		public ParensContext(PolynomialContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.EnterParens(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.ExitParens(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolynomialVisitor<TResult> typedVisitor = visitor as IPolynomialVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParens(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class MonomContext : PolynomialContext {
		public MonomialContext monomial() {
			return GetRuleContext<MonomialContext>(0);
		}
		public MonomContext(PolynomialContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.EnterMonom(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.ExitMonom(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolynomialVisitor<TResult> typedVisitor = visitor as IPolynomialVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMonom(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PolynomialContext polynomial() {
		PolynomialContext _localctx = new PolynomialContext(Context, State);
		EnterRule(_localctx, 4, RULE_polynomial);
		int _la;
		try {
			State = 43;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,6,Context) ) {
			case 1:
				_localctx = new ParensContext(_localctx);
				EnterOuterAlt(_localctx, 1);
				{
				State = 32;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==SIGN) {
					{
					State = 31; Match(SIGN);
					}
				}

				State = 34; Match(T__0);
				State = 38;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__0) | (1L << INT) | (1L << DEC) | (1L << VAR) | (1L << SIGN))) != 0)) {
					{
					{
					State = 35; polynomial();
					}
					}
					State = 40;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				State = 41; Match(T__1);
				}
				break;
			case 2:
				_localctx = new MonomContext(_localctx);
				EnterOuterAlt(_localctx, 2);
				{
				State = 42; monomial();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class MonomialContext : ParserRuleContext {
		public MonomialContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_monomial; } }
	 
		public MonomialContext() { }
		public virtual void CopyFrom(MonomialContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class NumberContext : MonomialContext {
		public CoefficientContext coefficient() {
			return GetRuleContext<CoefficientContext>(0);
		}
		public ITerminalNode SIGN() { return GetToken(PolynomialParser.SIGN, 0); }
		public NumberContext(MonomialContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.EnterNumber(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.ExitNumber(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolynomialVisitor<TResult> typedVisitor = visitor as IPolynomialVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitNumber(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class AddendContext : MonomialContext {
		public ITerminalNode VAR() { return GetToken(PolynomialParser.VAR, 0); }
		public ITerminalNode SIGN() { return GetToken(PolynomialParser.SIGN, 0); }
		public CoefficientContext coefficient() {
			return GetRuleContext<CoefficientContext>(0);
		}
		public ITerminalNode INT() { return GetToken(PolynomialParser.INT, 0); }
		public AddendContext(MonomialContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.EnterAddend(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.ExitAddend(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolynomialVisitor<TResult> typedVisitor = visitor as IPolynomialVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAddend(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public MonomialContext monomial() {
		MonomialContext _localctx = new MonomialContext(Context, State);
		EnterRule(_localctx, 6, RULE_monomial);
		int _la;
		try {
			State = 60;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,11,Context) ) {
			case 1:
				_localctx = new AddendContext(_localctx);
				EnterOuterAlt(_localctx, 1);
				{
				State = 46;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==SIGN) {
					{
					State = 45; Match(SIGN);
					}
				}

				State = 49;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==INT || _la==DEC) {
					{
					State = 48; coefficient();
					}
				}

				State = 51; Match(VAR);
				State = 54;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==T__2) {
					{
					State = 52; Match(T__2);
					State = 53; Match(INT);
					}
				}

				}
				break;
			case 2:
				_localctx = new NumberContext(_localctx);
				EnterOuterAlt(_localctx, 2);
				{
				State = 57;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==SIGN) {
					{
					State = 56; Match(SIGN);
					}
				}

				State = 59; coefficient();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class CoefficientContext : ParserRuleContext {
		public ITerminalNode INT() { return GetToken(PolynomialParser.INT, 0); }
		public ITerminalNode DEC() { return GetToken(PolynomialParser.DEC, 0); }
		public CoefficientContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_coefficient; } }
		public override void EnterRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.EnterCoefficient(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IPolynomialListener typedListener = listener as IPolynomialListener;
			if (typedListener != null) typedListener.ExitCoefficient(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolynomialVisitor<TResult> typedVisitor = visitor as IPolynomialVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCoefficient(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public CoefficientContext coefficient() {
		CoefficientContext _localctx = new CoefficientContext(Context, State);
		EnterRule(_localctx, 8, RULE_coefficient);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 62;
			_la = TokenStream.LA(1);
			if ( !(_la==INT || _la==DEC) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\f', '\x43', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', 
		'\x6', '\t', '\x6', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', 
		'\x6', '\x3', '\x11', '\n', '\x3', '\r', '\x3', '\xE', '\x3', '\x12', 
		'\x3', '\x3', '\x6', '\x3', '\x16', '\n', '\x3', '\r', '\x3', '\xE', '\x3', 
		'\x17', '\x3', '\x3', '\x3', '\x3', '\x6', '\x3', '\x1C', '\n', '\x3', 
		'\r', '\x3', '\xE', '\x3', '\x1D', '\x5', '\x3', ' ', '\n', '\x3', '\x3', 
		'\x4', '\x5', '\x4', '#', '\n', '\x4', '\x3', '\x4', '\x3', '\x4', '\a', 
		'\x4', '\'', '\n', '\x4', '\f', '\x4', '\xE', '\x4', '*', '\v', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\x5', '\x4', '.', '\n', '\x4', '\x3', '\x5', 
		'\x5', '\x5', '\x31', '\n', '\x5', '\x3', '\x5', '\x5', '\x5', '\x34', 
		'\n', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x5', '\x5', '\x39', 
		'\n', '\x5', '\x3', '\x5', '\x5', '\x5', '<', '\n', '\x5', '\x3', '\x5', 
		'\x5', '\x5', '?', '\n', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', 
		'\x2', '\x2', '\a', '\x2', '\x4', '\x6', '\b', '\n', '\x2', '\x3', '\x3', 
		'\x2', '\x6', '\a', '\x2', 'I', '\x2', '\f', '\x3', '\x2', '\x2', '\x2', 
		'\x4', '\x1F', '\x3', '\x2', '\x2', '\x2', '\x6', '-', '\x3', '\x2', '\x2', 
		'\x2', '\b', '>', '\x3', '\x2', '\x2', '\x2', '\n', '@', '\x3', '\x2', 
		'\x2', '\x2', '\f', '\r', '\x5', '\x4', '\x3', '\x2', '\r', '\xE', '\a', 
		'\x2', '\x2', '\x3', '\xE', '\x3', '\x3', '\x2', '\x2', '\x2', '\xF', 
		'\x11', '\x5', '\x6', '\x4', '\x2', '\x10', '\xF', '\x3', '\x2', '\x2', 
		'\x2', '\x11', '\x12', '\x3', '\x2', '\x2', '\x2', '\x12', '\x10', '\x3', 
		'\x2', '\x2', '\x2', '\x12', '\x13', '\x3', '\x2', '\x2', '\x2', '\x13', 
		' ', '\x3', '\x2', '\x2', '\x2', '\x14', '\x16', '\x5', '\x6', '\x4', 
		'\x2', '\x15', '\x14', '\x3', '\x2', '\x2', '\x2', '\x16', '\x17', '\x3', 
		'\x2', '\x2', '\x2', '\x17', '\x15', '\x3', '\x2', '\x2', '\x2', '\x17', 
		'\x18', '\x3', '\x2', '\x2', '\x2', '\x18', '\x19', '\x3', '\x2', '\x2', 
		'\x2', '\x19', '\x1B', '\a', '\n', '\x2', '\x2', '\x1A', '\x1C', '\x5', 
		'\x6', '\x4', '\x2', '\x1B', '\x1A', '\x3', '\x2', '\x2', '\x2', '\x1C', 
		'\x1D', '\x3', '\x2', '\x2', '\x2', '\x1D', '\x1B', '\x3', '\x2', '\x2', 
		'\x2', '\x1D', '\x1E', '\x3', '\x2', '\x2', '\x2', '\x1E', ' ', '\x3', 
		'\x2', '\x2', '\x2', '\x1F', '\x10', '\x3', '\x2', '\x2', '\x2', '\x1F', 
		'\x15', '\x3', '\x2', '\x2', '\x2', ' ', '\x5', '\x3', '\x2', '\x2', '\x2', 
		'!', '#', '\a', '\t', '\x2', '\x2', '\"', '!', '\x3', '\x2', '\x2', '\x2', 
		'\"', '#', '\x3', '\x2', '\x2', '\x2', '#', '$', '\x3', '\x2', '\x2', 
		'\x2', '$', '(', '\a', '\x3', '\x2', '\x2', '%', '\'', '\x5', '\x6', '\x4', 
		'\x2', '&', '%', '\x3', '\x2', '\x2', '\x2', '\'', '*', '\x3', '\x2', 
		'\x2', '\x2', '(', '&', '\x3', '\x2', '\x2', '\x2', '(', ')', '\x3', '\x2', 
		'\x2', '\x2', ')', '+', '\x3', '\x2', '\x2', '\x2', '*', '(', '\x3', '\x2', 
		'\x2', '\x2', '+', '.', '\a', '\x4', '\x2', '\x2', ',', '.', '\x5', '\b', 
		'\x5', '\x2', '-', '\"', '\x3', '\x2', '\x2', '\x2', '-', ',', '\x3', 
		'\x2', '\x2', '\x2', '.', '\a', '\x3', '\x2', '\x2', '\x2', '/', '\x31', 
		'\a', '\t', '\x2', '\x2', '\x30', '/', '\x3', '\x2', '\x2', '\x2', '\x30', 
		'\x31', '\x3', '\x2', '\x2', '\x2', '\x31', '\x33', '\x3', '\x2', '\x2', 
		'\x2', '\x32', '\x34', '\x5', '\n', '\x6', '\x2', '\x33', '\x32', '\x3', 
		'\x2', '\x2', '\x2', '\x33', '\x34', '\x3', '\x2', '\x2', '\x2', '\x34', 
		'\x35', '\x3', '\x2', '\x2', '\x2', '\x35', '\x38', '\a', '\b', '\x2', 
		'\x2', '\x36', '\x37', '\a', '\x5', '\x2', '\x2', '\x37', '\x39', '\a', 
		'\x6', '\x2', '\x2', '\x38', '\x36', '\x3', '\x2', '\x2', '\x2', '\x38', 
		'\x39', '\x3', '\x2', '\x2', '\x2', '\x39', '?', '\x3', '\x2', '\x2', 
		'\x2', ':', '<', '\a', '\t', '\x2', '\x2', ';', ':', '\x3', '\x2', '\x2', 
		'\x2', ';', '<', '\x3', '\x2', '\x2', '\x2', '<', '=', '\x3', '\x2', '\x2', 
		'\x2', '=', '?', '\x5', '\n', '\x6', '\x2', '>', '\x30', '\x3', '\x2', 
		'\x2', '\x2', '>', ';', '\x3', '\x2', '\x2', '\x2', '?', '\t', '\x3', 
		'\x2', '\x2', '\x2', '@', '\x41', '\t', '\x2', '\x2', '\x2', '\x41', '\v', 
		'\x3', '\x2', '\x2', '\x2', '\xE', '\x12', '\x17', '\x1D', '\x1F', '\"', 
		'(', '-', '\x30', '\x33', '\x38', ';', '>',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
