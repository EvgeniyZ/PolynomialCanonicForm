## Prerequisites
Polynomial.WebApi uses Antlr4. In case if you want to regenerate classes by changing a grammar
you must:
* Install latest Java JDK
* Add Java bin to Path
* Execute from the Grammar directory of the Polynomial.WebApi project <br> ```java -jar antlr-4.8-complete.jar -Dlanguage=CSharp -visitor Polynomial.g4 -o ..\Traversing\ ```
