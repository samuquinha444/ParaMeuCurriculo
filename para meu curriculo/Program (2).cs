
using System;

class GeradorCPF
{
    static void Main()
    {
        string cpf = GerarCPF();
        Console.WriteLine($"CPF Gerado: {cpf}");
    }

    static string GerarCPF()
    {
        Random random = new Random();
        int[] numeros = new int[9];

        // Gerar os 9 primeiros dígitos
        for (int i = 0; i < 9; i++)
        {
            numeros[i] = random.Next(0, 10);
        }

        // Calcular o primeiro dígito verificador
        int soma = 0;
        for (int i = 0; i < 9; i++)
        {
            soma += numeros[i] * (10 - i);
        }
        int primeiroDV = CalcularDigitoVerificador(soma);

        // Calcular o segundo dígito verificador
        soma = 0;
        for (int i = 0; i < 9; i++)
        {
            soma += numeros[i] * (11 - i);
        }
        soma += primeiroDV * 2;
        int segundoDV = CalcularDigitoVerificador(soma);

        // Montar o CPF
        string cpfGerado = string.Join("", numeros) + primeiroDV + segundoDV;
        return FormatarCPF(cpfGerado);
    }

    static int CalcularDigitoVerificador(int soma)
    {
        int resto = soma % 11;
        if (resto < 2)
            return 0;
        return 11 - resto;
    }

    static string FormatarCPF(string cpf)
    {
        return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
    }
}
