using System;
using System.Net;
using Newtonsoft.Json;

namespace botMegaSena
{
    public class RoboNutelaMegaSena
    {
        public static void RealizaConsulta()
        {
            Console.WriteLine("Informe um número do concurso:");

            string numeroDoConcurso = Console.ReadLine();

            if (String.IsNullOrEmpty(numeroDoConcurso))
            {
                numeroDoConcurso = "2103";
            }

            string url = @"http://loterias.caixa.gov.br/wps/portal/loterias/landing/megasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA0sjIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQE-F4ca/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO6H80AU71KG7J0072/res/id=buscaResultado/c=cacheLevelPage/=/?timestampAjax=1562808392880&concurso=" + numeroDoConcurso;

            string json = "";

            using (var client = new WebClient())
            {
                client.Headers["Cookie"] = "security=true";
                json = client.DownloadString(url);
            }

            var resultadoMegaSena = JsonConvert.DeserializeObject<ResultadoMegaSena>(json);

            Console.WriteLine(resultadoMegaSena.resultadoOrdenado);
        }
    }
}