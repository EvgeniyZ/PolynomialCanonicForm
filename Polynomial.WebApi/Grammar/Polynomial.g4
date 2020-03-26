grammar Polynomial;

polynomial      : (SIGN? monomial)(SIGN monomial)*          #addSub
                | '(' polynomial ')'                        #parens
                ;

monomial        : coefficient? VAR ('^' POWER)?             #addend
                | coefficient                               #number
                ;

coefficient     : INT | DEC;


fragment DIGIT : [0-9];

INT                     : ('0'..'9')+;
POWER                   : INT;
DEC                     : INT '.' INT;
VAR                     : [a-z]+;
SIGN                    : '+' | '-';
WHITESPACE              : (' '|'\t')+ -> skip;