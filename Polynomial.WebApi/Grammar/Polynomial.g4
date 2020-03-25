grammar Polynomial;

polynomial      : polynomial op=('+'|'-') polynomial   #addSub
                | '(' polynomial ')'                   #parens
                | SUB? DOUBLE? INT? VAR ('^' INT)?     #monomial
                | DOUBLE                               #double
                | INT                                  #integer
                ;


DOUBLE                  : ('0'..'9')+ '.'+ ('0'..'9')*;
INT                     : [0-9]+;
VAR                     : [a-z]+;
ADD                     : '+';
SUB                     : '-';
WHITESPACE              : (' '|'\t')+ -> skip;