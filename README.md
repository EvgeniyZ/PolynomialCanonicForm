# Polynomial Canonical Form
ASP.Net core service that reduces given expression to a canonic form.
```
10+y^4+(y^4+44)      -> 2y^4+54
x+3+1+2              -> x+6
x^2+3.5xy+y=y^2-xy+y -> x^2-y^2+4.5xy=0
12=44                -> -32
```
More examples you can find in Polynomial.UnitTests.CanonicalFormerTests

### Supported operations
They're defined in ```Polynomial.g4```, right now it's '+', '-', '='

## Prerequisites
Polynomial.WebApi uses ANTLR4. In case if you want to regenerate classes by changing a grammar
you must:
* Install latest Java JDK
* Add Java bin to Path
* Execute from the Grammar directory of the Polynomial.WebApi project <br> ```java -jar antlr-4.8-complete.jar -Dlanguage=CSharp -visitor Polynomial.g4 -o ..\Traversing\ ```

## What might help
I'm using Jetbrains Rider as IDE for programming. I found ANTLR v4 grammar plugin
which is super useful for creating a stable grammar for ANTLR.

https://plugins.jetbrains.com/plugin/7358-antlr-v4-grammar-plugin

What I really love is that ANTLR 4 grammar plugin can test specific grammar rules
via your input and generate Abstract Syntax Tree regarding of this input.
