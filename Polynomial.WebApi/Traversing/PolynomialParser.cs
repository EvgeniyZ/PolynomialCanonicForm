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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

namespace Polynomial.WebApi.Traversing
{
	[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
	[System.CLSCompliant(false)]
	public partial class PolynomialParser : Parser {
		protected static DFA[] decisionToDFA;
		protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
		public const int
			T__0=1, T__1=2, INT=3, DOUBLE=4, VAR=5, POW=6, SIGN=7, WHITESPACE=8;
		public const int
			RULE_polynomial = 0, RULE_monomial = 1;
		public static readonly string[] ruleNames = {
			"polynomial", "monomial"
		};

		private static readonly string[] _LiteralNames = {
			null, "'('", "')'", null, null, null, "'^'"
		};
		private static readonly string[] _SymbolicNames = {
			null, null, null, "INT", "DOUBLE", "VAR", "POW", "SIGN", "WHITESPACE"
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
			public PolynomialContext polynomial() {
				return GetRuleContext<PolynomialContext>(0);
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
		}
		public partial class AddSubContext : PolynomialContext {
			public MonomialContext[] monomial() {
				return GetRuleContexts<MonomialContext>();
			}
			public MonomialContext monomial(int i) {
				return GetRuleContext<MonomialContext>(i);
			}
			public ITerminalNode[] SIGN() { return GetTokens(PolynomialParser.SIGN); }
			public ITerminalNode SIGN(int i) {
				return GetToken(PolynomialParser.SIGN, i);
			}
			public AddSubContext(PolynomialContext context) { CopyFrom(context); }
			public override void EnterRule(IParseTreeListener listener) {
				IPolynomialListener typedListener = listener as IPolynomialListener;
				if (typedListener != null) typedListener.EnterAddSub(this);
			}
			public override void ExitRule(IParseTreeListener listener) {
				IPolynomialListener typedListener = listener as IPolynomialListener;
				if (typedListener != null) typedListener.ExitAddSub(this);
			}
		}

		[RuleVersion(0)]
		public PolynomialContext polynomial() {
			PolynomialContext _localctx = new PolynomialContext(Context, State);
			EnterRule(_localctx, 0, RULE_polynomial);
			int _la;
			try {
				State = 20;
				ErrorHandler.Sync(this);
				switch (TokenStream.LA(1)) {
					case INT:
					case DOUBLE:
					case VAR:
					case SIGN:
						_localctx = new AddSubContext(_localctx);
						EnterOuterAlt(_localctx, 1);
					{
						{
							State = 5;
							ErrorHandler.Sync(this);
							_la = TokenStream.LA(1);
							if (_la==SIGN) {
								{
									State = 4; Match(SIGN);
								}
							}

							State = 7; monomial();
						}
						State = 13;
						ErrorHandler.Sync(this);
						_la = TokenStream.LA(1);
						while (_la==SIGN) {
							{
								{
									State = 9; Match(SIGN);
									State = 10; monomial();
								}
							}
							State = 15;
							ErrorHandler.Sync(this);
							_la = TokenStream.LA(1);
						}
					}
						break;
					case T__0:
						_localctx = new ParensContext(_localctx);
						EnterOuterAlt(_localctx, 2);
					{
						State = 16; Match(T__0);
						State = 17; polynomial();
						State = 18; Match(T__1);
					}
						break;
					default:
						throw new NoViableAltException(this);
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
		public partial class RealMonomialContext : MonomialContext {
			public ITerminalNode VAR() { return GetToken(PolynomialParser.VAR, 0); }
			public ITerminalNode DOUBLE() { return GetToken(PolynomialParser.DOUBLE, 0); }
			public ITerminalNode[] INT() { return GetTokens(PolynomialParser.INT); }
			public ITerminalNode INT(int i) {
				return GetToken(PolynomialParser.INT, i);
			}
			public ITerminalNode POW() { return GetToken(PolynomialParser.POW, 0); }
			public RealMonomialContext(MonomialContext context) { CopyFrom(context); }
			public override void EnterRule(IParseTreeListener listener) {
				IPolynomialListener typedListener = listener as IPolynomialListener;
				if (typedListener != null) typedListener.EnterRealMonomial(this);
			}
			public override void ExitRule(IParseTreeListener listener) {
				IPolynomialListener typedListener = listener as IPolynomialListener;
				if (typedListener != null) typedListener.ExitRealMonomial(this);
			}
		}
		public partial class DoubleContext : MonomialContext {
			public ITerminalNode DOUBLE() { return GetToken(PolynomialParser.DOUBLE, 0); }
			public DoubleContext(MonomialContext context) { CopyFrom(context); }
			public override void EnterRule(IParseTreeListener listener) {
				IPolynomialListener typedListener = listener as IPolynomialListener;
				if (typedListener != null) typedListener.EnterDouble(this);
			}
			public override void ExitRule(IParseTreeListener listener) {
				IPolynomialListener typedListener = listener as IPolynomialListener;
				if (typedListener != null) typedListener.ExitDouble(this);
			}
		}
		public partial class IntegerContext : MonomialContext {
			public ITerminalNode INT() { return GetToken(PolynomialParser.INT, 0); }
			public IntegerContext(MonomialContext context) { CopyFrom(context); }
			public override void EnterRule(IParseTreeListener listener) {
				IPolynomialListener typedListener = listener as IPolynomialListener;
				if (typedListener != null) typedListener.EnterInteger(this);
			}
			public override void ExitRule(IParseTreeListener listener) {
				IPolynomialListener typedListener = listener as IPolynomialListener;
				if (typedListener != null) typedListener.ExitInteger(this);
			}
		}

		[RuleVersion(0)]
		public MonomialContext monomial() {
			MonomialContext _localctx = new MonomialContext(Context, State);
			EnterRule(_localctx, 2, RULE_monomial);
			int _la;
			try {
				State = 35;
				ErrorHandler.Sync(this);
				switch ( Interpreter.AdaptivePredict(TokenStream,6,Context) ) {
					case 1:
						_localctx = new RealMonomialContext(_localctx);
						EnterOuterAlt(_localctx, 1);
					{
						State = 23;
						ErrorHandler.Sync(this);
						_la = TokenStream.LA(1);
						if (_la==DOUBLE) {
							{
								State = 22; Match(DOUBLE);
							}
						}

						State = 26;
						ErrorHandler.Sync(this);
						_la = TokenStream.LA(1);
						if (_la==INT) {
							{
								State = 25; Match(INT);
							}
						}

						State = 28; Match(VAR);
						State = 31;
						ErrorHandler.Sync(this);
						_la = TokenStream.LA(1);
						if (_la==POW) {
							{
								State = 29; Match(POW);
								State = 30; Match(INT);
							}
						}

					}
						break;
					case 2:
						_localctx = new DoubleContext(_localctx);
						EnterOuterAlt(_localctx, 2);
					{
						State = 33; Match(DOUBLE);
					}
						break;
					case 3:
						_localctx = new IntegerContext(_localctx);
						EnterOuterAlt(_localctx, 3);
					{
						State = 34; Match(INT);
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

		private static char[] _serializedATN = {
			'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
			'\x5964', '\x3', '\n', '(', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', '\t', 
			'\x3', '\x3', '\x2', '\x5', '\x2', '\b', '\n', '\x2', '\x3', '\x2', '\x3', 
			'\x2', '\x3', '\x2', '\x3', '\x2', '\a', '\x2', '\xE', '\n', '\x2', '\f', 
			'\x2', '\xE', '\x2', '\x11', '\v', '\x2', '\x3', '\x2', '\x3', '\x2', 
			'\x3', '\x2', '\x3', '\x2', '\x5', '\x2', '\x17', '\n', '\x2', '\x3', 
			'\x3', '\x5', '\x3', '\x1A', '\n', '\x3', '\x3', '\x3', '\x5', '\x3', 
			'\x1D', '\n', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x5', 
			'\x3', '\"', '\n', '\x3', '\x3', '\x3', '\x3', '\x3', '\x5', '\x3', '&', 
			'\n', '\x3', '\x3', '\x3', '\x2', '\x2', '\x4', '\x2', '\x4', '\x2', '\x2', 
			'\x2', '-', '\x2', '\x16', '\x3', '\x2', '\x2', '\x2', '\x4', '%', '\x3', 
			'\x2', '\x2', '\x2', '\x6', '\b', '\a', '\t', '\x2', '\x2', '\a', '\x6', 
			'\x3', '\x2', '\x2', '\x2', '\a', '\b', '\x3', '\x2', '\x2', '\x2', '\b', 
			'\t', '\x3', '\x2', '\x2', '\x2', '\t', '\n', '\x5', '\x4', '\x3', '\x2', 
			'\n', '\xF', '\x3', '\x2', '\x2', '\x2', '\v', '\f', '\a', '\t', '\x2', 
			'\x2', '\f', '\xE', '\x5', '\x4', '\x3', '\x2', '\r', '\v', '\x3', '\x2', 
			'\x2', '\x2', '\xE', '\x11', '\x3', '\x2', '\x2', '\x2', '\xF', '\r', 
			'\x3', '\x2', '\x2', '\x2', '\xF', '\x10', '\x3', '\x2', '\x2', '\x2', 
			'\x10', '\x17', '\x3', '\x2', '\x2', '\x2', '\x11', '\xF', '\x3', '\x2', 
			'\x2', '\x2', '\x12', '\x13', '\a', '\x3', '\x2', '\x2', '\x13', '\x14', 
			'\x5', '\x2', '\x2', '\x2', '\x14', '\x15', '\a', '\x4', '\x2', '\x2', 
			'\x15', '\x17', '\x3', '\x2', '\x2', '\x2', '\x16', '\a', '\x3', '\x2', 
			'\x2', '\x2', '\x16', '\x12', '\x3', '\x2', '\x2', '\x2', '\x17', '\x3', 
			'\x3', '\x2', '\x2', '\x2', '\x18', '\x1A', '\a', '\x6', '\x2', '\x2', 
			'\x19', '\x18', '\x3', '\x2', '\x2', '\x2', '\x19', '\x1A', '\x3', '\x2', 
			'\x2', '\x2', '\x1A', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x1D', 
			'\a', '\x5', '\x2', '\x2', '\x1C', '\x1B', '\x3', '\x2', '\x2', '\x2', 
			'\x1C', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x1D', '\x1E', '\x3', '\x2', 
			'\x2', '\x2', '\x1E', '!', '\a', '\a', '\x2', '\x2', '\x1F', ' ', '\a', 
			'\b', '\x2', '\x2', ' ', '\"', '\a', '\x5', '\x2', '\x2', '!', '\x1F', 
			'\x3', '\x2', '\x2', '\x2', '!', '\"', '\x3', '\x2', '\x2', '\x2', '\"', 
			'&', '\x3', '\x2', '\x2', '\x2', '#', '&', '\a', '\x6', '\x2', '\x2', 
			'$', '&', '\a', '\x5', '\x2', '\x2', '%', '\x19', '\x3', '\x2', '\x2', 
			'\x2', '%', '#', '\x3', '\x2', '\x2', '\x2', '%', '$', '\x3', '\x2', '\x2', 
			'\x2', '&', '\x5', '\x3', '\x2', '\x2', '\x2', '\t', '\a', '\xF', '\x16', 
			'\x19', '\x1C', '!', '%',
		};

		public static readonly ATN _ATN =
			new ATNDeserializer().Deserialize(_serializedATN);


	}
}
