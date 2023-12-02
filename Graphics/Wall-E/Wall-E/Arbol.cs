namespace Wall_E
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;


public enum TipoToken
{
    PalabraReservada,

    Funcion,
    Identificador,
    Numero,
    OperadorAritmético,
    OperadorLógico,
    OperadorAsignación,
    DelimitadorAbierto,
    DelimitadorCerrado,
    Math,
    Comillas,
    PuntoComa,
    Coma,

    Desconocido,

    Flecha,

    Cadena,

    Concatenador,


}






public class Token
{





    public Token(TipoToken tipo, string valor)
    {
        Tipo = tipo;
        Valor = valor;
    }
    public TipoToken Tipo { get; }
    public string Valor { get; }


}





public abstract class AST
{
    public abstract object Evaluar(Entorno entorno);

}

public abstract class Instruccion
{

}



public abstract class Funcion : Instruccion
{
    public abstract Token nombre { get; }
}


public sealed class FunctionLine : Funcion
{
    public override Token nombre { get; }
    public Punto P1 { get; }
    public Punto P2 { get; }

    public FunctionLine(Token nombre, Punto P1, Punto P2)
    {
        this.nombre = nombre;
        this.P1 = P1;
        this.P2 = P2;

    }
}

public sealed class FuncionSegment : Funcion
{
    public override Token nombre { get; }
    public Punto P1 { get; }
    public Punto P2 { get; }

    public FuncionSegment(Token nombre, Punto P1, Punto P2)
    {
        this.nombre = nombre;
        this.P1 = P1;
        this.P2 = P2;

    }
}

public sealed class Ray : Funcion
{
    public override Token nombre { get; }
    public Punto P1 { get; }
    public Punto P2 { get; }

    public Ray(Token nombre, Punto P1, Punto P2)
    {
        this.nombre = nombre;
        this.P1 = P1;
        this.P2 = P2;

    }
}


public sealed class Measure : Funcion
{
    public override Token nombre { get; }
    public Punto P1 { get; }
    public Punto P2 { get; }

    public Measure(Token nombre, Punto P1, Punto P2)
    {
        this.nombre = nombre;
        this.P1 = P1;
        this.P2 = P2;

    }
}

public sealed class Arc : Funcion
{
    public override Token nombre { get; }
    public Punto P1 { get; }
    public Punto P2 { get; }
    public double Measure { get; }

    public Arc(Token nombre, Punto P1, Punto P2, double Measure)
    {
        this.nombre = nombre;
        this.P1 = P1;
        this.P2 = P2;
        this.Measure = Measure;

    }
}

public sealed class Intersect : Funcion
{
    public override Token nombre { get; }
    public Figura Figure1 { get; }
    public Figura Figure2 { get; }


    public Intersect(Token nombre, Figura Figure1, Figura Figure2)
    {
        this.nombre = nombre;
        this.Figure1 = Figure1;
        this.Figure2 = Figure2;


    }
}

public class Draw
{
    public Token Nombre { get; }
    public string Label { get; }

    public Figura Figura { get; }

    public Draw(Token Nombre, Figura Figura) : this(Nombre, Figura, null) { }
    public Draw(Token Nombre, Figura Figura, string Label)
    {
        this.Nombre = Nombre;
        this.Label = Label;
        this.Figura = Figura;

    }
}


public abstract class Figura : Instruccion
{

    public abstract Token identificador { get; }
    public abstract Token nombre { get; }

}
public sealed class CircleFunction : Funcion
{
    public override Token nombre { get; }
    public Punto P1 { get; }

    public double Measure { get; }

    public CircleFunction(Token nombre, Punto P1, double Measure)
    {
        this.nombre = nombre;
        this.P1 = P1;
        this.Measure = Measure;

    }
}

public sealed class Count : Funcion
{
    public override Token nombre { get; }
    public Secuence Secuence { get; }
    public Count(Token nombre, Secuence Secuence)
    {

        this.nombre = nombre;
        this.Secuence = Secuence;
    }
}

public sealed class Randoms : Funcion
{
    public override Token nombre { get; }

    public Randoms(Token nombre)
    {

        this.nombre = nombre;
    }
}

public sealed class PointsFunction : Funcion
{
    public override Token nombre { get; }
    public Figura Figure1 { get; }

    public PointsFunction(Token nombre, Figura Figure1)
    {
        this.Figure1 = Figure1;
        this.nombre = nombre;
    }
}

public sealed class Samples : Funcion
{
    public override Token nombre { get; }

    public Samples(Token nombre)
    {

        this.nombre = nombre;
    }
}






public sealed class Punto : Figura
{

    public Punto(Token identificador, Token nombre)
    {
        this.identificador = identificador;
        this.nombre = nombre;

    }

    public override Token identificador { get; }
    public override Token nombre { get; }

}

public sealed class Circle : Figura
{

    public Circle(Token identificador, Token nombre) : this(identificador, nombre, nombre, nombre) { }

    public Circle(Token identificador, Token nombre, Token param1, Token param2)
    {
        this.identificador = identificador;
        this.nombre = nombre;
        this.param1 = param1;
        this.param2 = param2;
    }

    public override Token identificador { get; }
    public override Token nombre { get; }
    public Token param1 { get; }
    public Token param2 { get; }

}

public sealed class Line : Figura
{

    public Line(Token identificador, Token nombre) : this(identificador, nombre, nombre, nombre) { }

    public Line(Token identificador, Token nombre, Token param1, Token param2)
    {
        this.identificador = identificador;
        this.nombre = nombre;
        this.param1 = param1;
        this.param2 = param2;
    }

    public sealed class LineSecuence : Secuence
    {
        public override Token identificador { get; }

        public override Token nombre { get; }

        public List<Line> Line { get; }

        public LineSecuence(Token identificador, Token nombre, List<Line> Line)
        {
            this.identificador = identificador;
            this.nombre = nombre;
            this.Line = Line;

        }
    }

    public sealed class PointSecuence : Secuence
    {
        public override Token identificador { get; }

        public override Token nombre { get; }

        public List<Punto> Points { get; }

        public PointSecuence(Token identificador, Token nombre, List<Punto> Points)
        {
            this.identificador = identificador;
            this.nombre = nombre;
            this.Points = Points;

        }
    }





    public override Token identificador { get; }
    public override Token nombre { get; }
    public Token param1 { get; }
    public Token param2 { get; }

}

public abstract class Secuence : Figura
{

}

public class ValorNumerico : AST
{
    public double Valor { get; }

    public ValorNumerico(double value)
    {
        Valor = value;
    }

    public override object Evaluar(Entorno entorno)
    {

        return Valor;
    }


}

public class OperacionAritmetica : AST
{
    public AST OperandoIzquierdo { get; }
    public AST OperandoDerecho { get; }
    public string Operador { get; }

    public OperacionAritmetica(AST operandoIzquierdo, AST operandoDerecho, string operador)
    {
        OperandoIzquierdo = operandoIzquierdo;
        OperandoDerecho = operandoDerecho;
        Operador = operador;
    }

    public override object Evaluar(Entorno entorno)
    {

        double valorIzquierdo = Convert.ToDouble(OperandoIzquierdo.Evaluar(entorno));
        double valorDerecho = Convert.ToDouble(OperandoDerecho.Evaluar(entorno));


        switch (Operador)
        {
            case "+":
                return valorIzquierdo + valorDerecho;
            case "-":
                return valorIzquierdo - valorDerecho;
            case "*":
                return valorIzquierdo * valorDerecho;
            case "%":
                return valorIzquierdo % valorDerecho;
            case "^":
                return Math.Pow(valorIzquierdo, valorDerecho);
            case "/":
                if (valorDerecho != 0)
                {
                    return valorIzquierdo / valorDerecho;
                }
                else
                {
                    throw new Exception("Error: División por cero.");
                }
            default:
                throw new Exception($"Error: Operador desconocido '{Operador}'.");
        }


    }



}



public class Negacion : AST
{
    private AST subexpresion;

    public Negacion(AST subexpresion)
    {
        this.subexpresion = subexpresion;
    }

    public override object Evaluar(Entorno entorno)
    {

        object valor = subexpresion.Evaluar(entorno);


        if (valor is int)
        {

            return -Convert.ToDouble(valor);
        }
        else if (valor is double)
        {

            return -(double)valor;
        }
        else
        {

            throw new Exception("Error: se intentó negar un valor no numérico.");
        }
    }

}

public class Cadena : AST
{
    public string Valor { get; }

    public Cadena(string valor)
    {
        Valor = valor;
    }

    public override object Evaluar(Entorno entorno)
    {
        return Valor;
    }
}





public class FuncionLog : AST
{
    public AST BaseLog { get; }
    public AST ArgumentoLog { get; }

    public FuncionLog(AST baseLog, AST argumentoLog)
    {
        BaseLog = baseLog;
        ArgumentoLog = argumentoLog;
    }

    public override object Evaluar(Entorno entorno)
    {
        double valorBase = Convert.ToDouble(BaseLog.Evaluar(entorno));
        double valorArgumento = Convert.ToDouble(ArgumentoLog.Evaluar(entorno));



        return Math.Log(valorBase, valorArgumento);
    }
}

public class FuncionSin : AST
{
    public AST Argumento { get; }

    public FuncionSin(AST argumento)
    {
        Argumento = argumento;
    }

    public override object Evaluar(Entorno entorno)
    {

        double valorArgumento = Convert.ToDouble(Argumento.Evaluar(entorno));


        return Math.Sin(valorArgumento);
    }
}
public class FuncionCos : AST
{
    public AST Argumento { get; }

    public FuncionCos(AST argumento)
    {
        Argumento = argumento;
    }

    public override object Evaluar(Entorno entorno)
    {

        double valorArgumento = Convert.ToDouble(Argumento.Evaluar(entorno));


        return Math.Cos(valorArgumento);
    }
}










public class OperadorLogico : AST
{


    public AST OperandoIzquierdo { get; }
    public AST OperandoDerecho { get; }
    public string Operador { get; }

    public OperadorLogico(AST operandoIzquierdo, AST operandoDerecho, string operador)
    {
        OperandoIzquierdo = operandoIzquierdo;
        OperandoDerecho = operandoDerecho;
        Operador = operador;
    }

    public override object Evaluar(Entorno entorno)
    {

        var valorIzquierdo = OperandoIzquierdo.Evaluar(entorno);
        var valorDerecho = OperandoDerecho.Evaluar(entorno);


        switch (Operador)
        {
            case "==":
                return Convert.ToDouble(valorIzquierdo) == Convert.ToDouble(valorDerecho);
            case "!=":
                return Convert.ToDouble(valorIzquierdo) != Convert.ToDouble(valorDerecho); ;
            case ">":
                return Convert.ToDouble(valorIzquierdo) > Convert.ToDouble(valorDerecho);
            case "<":
                return Convert.ToDouble(valorIzquierdo) < Convert.ToDouble(valorDerecho);
            case "&&":
                return Convert.ToBoolean(valorIzquierdo) && Convert.ToBoolean(valorDerecho);
            case "||":
                return Convert.ToBoolean(valorIzquierdo) || Convert.ToBoolean(valorDerecho);
            default:
                throw new Exception($"Error: Operador desconocido '{Operador}'.");
        }
    }

}

public class Identificador : AST
{
    public string Nombre { get; }

    public Identificador(string nombre)
    {
        Nombre = nombre;
    }
    public override object Evaluar(Entorno entorno)
    {

        var variable = entorno.BuscarVariable(Nombre);
        if (variable != null)
        {

            return variable.Value;
        }
        else
        {

            throw new Exception($"Error: Variable no definida '{Nombre}'.");
        }
    }




}

public class DeclaracionVariable : AST
{
    public string Nombre { get; }
    public AST ValorInicial { get; }

    public DeclaracionVariable(string nombre, AST valorInicial)
    {
        Nombre = nombre;
        ValorInicial = valorInicial;
    }

    public override object Evaluar(Entorno entorno)
    {

        var valor = ValorInicial.Evaluar(entorno);


        entorno.DefinirVariable(new Variable(Nombre, valor));


        return null;
    }


}

public class Concatenacion : AST
{
    public AST Izquierdo { get; }
    public AST Derecho { get; }

    public Concatenacion(AST izquierdo, AST derecho)
    {
        Izquierdo = izquierdo;
        Derecho = derecho;
    }

    public override object Evaluar(Entorno entorno)
    {

        object valorIzquierdo = Izquierdo.Evaluar(entorno);
        object valorDerecho = Derecho.Evaluar(entorno);


        return valorIzquierdo.ToString() + " " + valorDerecho.ToString();
    }
}
public class LetInExpression : AST
{
    public Entorno Entorno { get; }
    public AST Cuerpo { get; }

    public LetInExpression(Entorno entorno, AST cuerpo)
    {
        Entorno = entorno;
        Cuerpo = cuerpo;
    }

    public override object Evaluar(Entorno entorno)
    {

        foreach (var variable in this.Entorno.variables)
        {
            entorno.DefinirVariable(variable.Value);
        }


        return this.Cuerpo.Evaluar(entorno);
    }




}




public class IfElseExpression : AST
{
    public AST Condicion { get; }
    public AST ExpresionIf { get; }
    public AST ExpresionElse { get; }

    public IfElseExpression(AST condicion, AST expresionIf, AST expresionElse)
    {
        Condicion = condicion;
        ExpresionIf = expresionIf;
        ExpresionElse = expresionElse;
    }

    public override object Evaluar(Entorno entorno)
    {

        bool condicion = Convert.ToBoolean(Condicion.Evaluar(entorno));


        if (condicion)
        {
            return ExpresionIf.Evaluar(entorno);
        }
        else
        {
            return ExpresionElse.Evaluar(entorno);
        }
    }

}

public class PrintExpression : AST
{
    public AST Expresion { get; }

    public PrintExpression(AST expresion)
    {
        Expresion = expresion;
    }

    public override object Evaluar(Entorno entorno)
    {

        var valor = Expresion.Evaluar(entorno);
        return valor.ToString();
    }
}

public class FuncionInline : AST
{
    public string Nombre { get; }
    public List<string> Parametros { get; }
    public AST Cuerpo { get; }

    public FuncionInline(string nombre, List<string> parametros, AST cuerpo)
    {
        Nombre = nombre;
        Parametros = parametros;
        Cuerpo = cuerpo;

    }
    public override object Evaluar(Entorno entorno)
    {

        entorno.DefinirFuncion(this);


        return null;
    }

}

public class LlamadaFuncion : AST
{
    public string Nombre { get; }
    public List<AST> Argumentos { get; }

    public LlamadaFuncion(string nombre, List<AST> argumentos)
    {
        Nombre = nombre;
        Argumentos = argumentos;
    }

    public override object Evaluar(Entorno entorno)
    {
        var funcion = entorno.BuscarFuncion(Nombre);

        if (funcion == null)
        {
            throw new Exception($"Error: Función no definida '{Nombre}'.");
        }

        var entornoFuncion = new Entorno();


        foreach (var variable in entorno.variables)
        {
            entornoFuncion.DefinirVariable(variable.Value);
        }
        foreach (var funcionInline in entorno.funciones)
        {
            entornoFuncion.DefinirFuncion(funcion);
        }

        for (int i = 0; i < Argumentos.Count; i++)
        {
            var valor = Argumentos[i].Evaluar(entorno);
            var variable = new Variable(funcion.Parametros[i], valor);
            entornoFuncion.DefinirVariable(variable);
        }

        return funcion.Cuerpo.Evaluar(entornoFuncion);
    }
}


public class Entorno
{
    public Dictionary<string, Variable> variables = new Dictionary<string, Variable>();

    public void DefinirVariable(Variable variable)
    {
        variables[variable.Name] = variable;
    }

    public Variable BuscarVariable(string nombre)
    {
        if (variables.TryGetValue(nombre, out var variable))
        {
            return variable;
        }
        else
        {
            return null;
        }
    }

    public Dictionary<string, FuncionInline> funciones = new Dictionary<string, FuncionInline>();

    public void DefinirFuncion(FuncionInline funcion)
    {
        funciones[funcion.Nombre] = funcion;
    }

    public FuncionInline BuscarFuncion(string nombre)
    {
        if (funciones.TryGetValue(nombre, out var funcion))
        {
            return funcion;
        }
        else
        {
            return null;
        }
    }
}

public class Variable
{
    public string Name { get; private set; }
    public object Value { get; private set; }

    public Variable(string name, object value)
    {
        Name = name;
        Value = value;
    }


}


































