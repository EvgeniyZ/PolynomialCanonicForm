grammar Polynomial;

polynomial      : (SIGN? monomial)(SIGN monomial)*          #addSub
                | '(' polynomial ')'                        #parens
                ;

monomial        : coefficient? VAR ('^' INT)?             #addend
                | coefficient                               #number
                ;

coefficient     : INT | DEC;

INT                     : ('0'..'9')+;
DEC                     : INT '.' INT;
VAR                     : [a-z]+;
SIGN                    : '+' | '-';
WHITESPACE              : (' '|'\t')+ -> skip;