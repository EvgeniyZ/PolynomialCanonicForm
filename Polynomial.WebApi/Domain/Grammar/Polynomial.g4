grammar Polynomial;

parse           : canonical EOF
                ;

canonical       : polynomial+                                     #canonicalPolynom
                | polynomial+ EQUAL polynomial+                   #equality
                ;

polynomial      : SIGN? '(' (polynomial)* ')'                     #parens
                | monomial                                        #monom
                ;

monomial        : SIGN? coefficient? VAR ('^' INT)?               #addend
                | SIGN? coefficient                               #number
                ;

coefficient             : INT | DEC;

INT                     : ('0'..'9')+;
DEC                     : INT '.' INT;
VAR                     : [a-z]+;
SIGN                    : '+' | '-';
EQUAL                   : '=';
WHITESPACE              : (' '|'\t')+ -> skip;
// Fallback rule: matches any single character if not matched by another lexer rule
UNKNOWN : . ;