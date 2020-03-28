grammar Polynomial;

canonical       : (polynomial)+                                   #canonicalPolynom
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
WHITESPACE              : (' '|'\t')+ -> skip;