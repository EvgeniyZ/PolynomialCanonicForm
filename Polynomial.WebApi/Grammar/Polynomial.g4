grammar Polynomial;

polynomial      : (SIGN? monomial)(SIGN monomial)*     #addSum
                | '(' polynomial ')'                   #parens
                ;

monomial        : DOUBLE? INT? VAR (POW INT)?          #realMonomial
                | DOUBLE #double
                | INT #integer
                ;

INT                     : [0-9]+;
DOUBLE                  : ('0'..'9')+ '.'+ ('0'..'9')*;
VAR                     : [a-z]+;
POW                     : '^';
SIGN                    : '+' | '-';
WHITESPACE              : (' '|'\t')+ -> skip;