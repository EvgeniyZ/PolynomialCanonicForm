grammar Polynomial;

polynomial      : (SIGN? monomial)(SIGN monomial)*     #addSub
                | '(' polynomial ')'                   #parens
                ;

monomial        : DOUBLE? INT? VAR ('^' INT)?          #realMonomial
                | DOUBLE                               #double
                | INT                                  #integer
                ;

INT                     : [0-9]+;
DOUBLE                  : ('0'..'9')+ '.'+ ('0'..'9')*;
VAR                     : [a-z]+;
SIGN                    : '+' | '-';
WHITESPACE              : (' '|'\t')+ -> skip;