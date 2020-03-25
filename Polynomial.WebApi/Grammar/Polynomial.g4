grammar Polynomial;

polynomial      : polynomial op=('+'|'-') polynomial   #addSub
                | '(' polynomial ')'                   #parens
                | DOUBLE? INT? VAR ('^' INT)?          #monomial
                | DOUBLE                               #double
                | INT                                  #integer
                ;

INT                     : [0-9]+;
DOUBLE                  : ('0'..'9')+ '.'+ ('0'..'9')*;
VAR                     : [a-z]+;
ADD                     : '+';
SUB                     : '-';
WHITESPACE              : (' '|'\t')+ -> skip;