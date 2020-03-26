## Prerequisites
Polynomial.WebApi uses Antlr4. In case if you want to regenerate classes by changing a grammar
you must have:
* Installed latest Java JDK
* Add Java bin to Path
* Download ANTLR tool and Java Target binaries, copy this .jar to \Grammar folder
* Execute from the root of the project <br> ```java -jar Polynomial.WebApi\Grammar\antlr-4.8-complete.jar -Dlanguage=CSharp -visitor Polynomial.WebApi\Grammar\Polynomial.g4 -o ..\Traversing\ ```
