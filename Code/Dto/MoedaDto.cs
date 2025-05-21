// *** MoedaDto.cs e modelos para JSON ***
using System;
using System.Collections.Generic;
using System.Drawing;

namespace PrjConversorMoeda.Code.Dto
{
    public class MoedaDto
    {
        public string Nome { get; set; }  // ex: "Real (BRL)"
        public string Code { get; set; }  // ex: "BRL"
        public Image Bandeira { get; set; }  // imagem baixada
        public override string ToString() => Nome;
    }

    public class RestCountry
    {
        // adiciona estas propriedades para mapear os campos "cca2" e "cca3" do JSON
        public string cca2 { get; set; }
        public string cca3 { get; set; }

        public Dictionary<string, CurrencyInfo> currencies { get; set; }
        public Flags flags { get; set; }
    }

    public class Flags
    {
        // JSON retorna "png" em minúsculas
        public string png { get; set; }

        // opcional, caso queira SVG também
        // public string svg { get; set; }
    }

    public class CurrencyInfo
    {
        public string name { get; set; }
        public string symbol { get; set; }
    }
}
