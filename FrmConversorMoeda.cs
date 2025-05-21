// *** FrmConversorMoeda.cs ***
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrjConversorMoeda.Code.Dto;

namespace PrjConversorMoeda
{
    public partial class FrmConversorMoeda : Form
    {
        private static readonly HttpClient _http = new HttpClient();
        private readonly JsonSerializerOptions _jsonOpts = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        private bool _inicializando = true;

        public FrmConversorMoeda()
        {
            InitializeComponent();

            // configurações iniciais dos masks
            mskMoeda1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskMoeda2.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskMoeda1.Text = "0";
            mskMoeda2.Text = "0";

            // picture boxes em Zoom
            pbPais1.SizeMode = PictureBoxSizeMode.Zoom;
            pbPais2.SizeMode = PictureBoxSizeMode.Zoom;

            // troca de país => atualiza bandeira + conversão
            cbPais1.SelectedIndexChanged += async (_, __) =>
            {
                AtualizarBandeira(pbPais1, cbPais1);
                await AtualizarConversaoAsync(invert: false);
            };
            cbPais2.SelectedIndexChanged += async (_, __) =>
            {
                AtualizarBandeira(pbPais2, cbPais2);
                await AtualizarConversaoAsync(invert: true);
            };

            // mudança de valor no mask => converte (usando handlers nomeados)
            mskMoeda1.TextChanged += MskMoeda1_TextChanged;
            mskMoeda2.TextChanged += MskMoeda2_TextChanged;

            cbPais1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbPais1.AutoCompleteSource = AutoCompleteSource.ListItems;

            cbPais2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbPais2.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private async void MskMoeda1_TextChanged(object sender, EventArgs e)
            => await AtualizarConversaoAsync(invert: false);

        private async void MskMoeda2_TextChanged(object sender, EventArgs e)
            => await AtualizarConversaoAsync(invert: true);

        /// <summary>
        /// Atualiza o texto do MaskedTextBox sem disparar o evento TextChanged.
        /// </summary>
        private void SetTextWithoutTrigger(MaskedTextBox msk, EventHandler handler, string text)
        {
            msk.TextChanged -= handler;
            msk.Text = text;
            msk.SelectionStart = msk.Text.Length;
            msk.TextChanged += handler;
        }

        private void AtualizarBandeira(PictureBox pb, ComboBox cb)
        {
            pb.Image = (cb.SelectedItem as MoedaDto)?.Bandeira;
        }

        private async void FrmConversorMoeda_Load(object sender, EventArgs e)
        {
            try
            {
                // 1) busca as moedas suportadas pela API
                var jsonSup = await _http.GetStringAsync("https://api.frankfurter.app/currencies");
                var dictSup = JsonSerializer
                    .Deserialize<Dictionary<string, string>>(jsonSup, _jsonOpts)
                    ?? new Dictionary<string, string>();
                var suportadas = dictSup.Keys.ToHashSet();

                // 2) busca todos os países
                var jsonCountries = await _http.GetStringAsync("https://restcountries.com/v3.1/all");
                var countries = JsonSerializer.Deserialize<List<RestCountry>>(jsonCountries, _jsonOpts);
                if (countries == null) return;

                // 3) encontra a entrada dos EUA (cca2 = "US" ou cca3 = "USA")
                var usCountry = countries
                    .FirstOrDefault(c =>
                        string.Equals(c.cca2, "US", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(c.cca3, "USA", StringComparison.OrdinalIgnoreCase)
                    );
                var usFlagUrl = usCountry?.flags?.png;

                // 4) monta um mapa de moeda → URL de bandeira qualquer
                var mapaMoedas = countries
                  .Where(c => c.currencies != null)
                  .SelectMany(c => c.currencies.Select(cur => new {
                      Code = cur.Key,
                      Name = cur.Value.name,
                      FlagUrl = c.flags?.png
                  }))
                  .GroupBy(x => x.Code)
                  .Select(g => g.First())
                  .Where(x => suportadas.Contains(x.Code))
                  .ToList();

                // 5) dicionário de nomes em PT-BR
                var ptBrCurrencyNames = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    {"BGN","Lev Búlgaro"}, {"CZK","Coroa Tcheca"}, {"USD","Dólar Americano"},
                    {"AUD","Dólar Australiano"}, {"CAD","Dólar Canadense"}, {"EUR","Euro"},
                    {"CHF","Franco Suíço"}, {"HKD","Dólar de Hong Kong"}, {"HUF","Forint Húngaro"},
                    {"ISK","Coroa Islandesa"}, {"JPY","Iene Japonês"}, {"INR","Rúpia Indiana"},
                    {"IDR","Rúpia Indonésia"}, {"ILS","Novo Shekel Israelense"},
                    {"DKK","Coroa Dinamarquesa"}, {"GBP","Libra Esterlina"},
                    {"MYR","Ringgit da Malásia"}, {"MXN","Peso Mexicano"},
                    {"NZD","Dólar Neozelandês"}, {"NOK","Coroa Norueguesa"},
                    {"PHP","Peso Filipino"}, {"PLN","Złoty Polonês"}, {"BRL","Real Brasileiro"},
                    {"RON","Leu Romeno"}, {"SGD","Dólar de Singapura"}, {"ZAR","Rand Sul-Africano"},
                    {"KRW","Won Sul-Coreano"}, {"SEK","Coroa Sueca"}, {"THB","Baht Tailandês"},
                    {"TRY","Lira Turca"}, {"CNY","Yuan Chinês"}, {"ARS","Peso Argentino"}
                };

                // 6) baixa as imagens substituindo USD pela bandeira dos EUA
                var tarefas = mapaMoedas.Select(async m =>
                {
                    try
                    {
                        var flagUrl = (m.Code == "USD" && !string.IsNullOrEmpty(usFlagUrl))
                                        ? usFlagUrl
                                        : m.FlagUrl;

                        var bytes = await _http.GetByteArrayAsync(flagUrl);
                        using var ms = new MemoryStream(bytes);
                        var img = Image.FromStream(ms);

                        var nomePt = ptBrCurrencyNames.TryGetValue(m.Code, out var t)
                                        ? t
                                        : m.Name;

                        return new MoedaDto
                        {
                            Nome = $"{nomePt} ({m.Code})",
                            Code = m.Code,
                            Bandeira = img
                        };
                    }
                    catch
                    {
                        return null;
                    }
                });

                var resultados = await Task.WhenAll(tarefas);
                var listaMoedas = resultados
                    .Where(x => x != null)
                    .OrderBy(m => m.Nome)
                    .ToList();

                // 7) popula os ComboBoxes
                cbPais1.DataSource = listaMoedas;
                cbPais1.DisplayMember = "Nome";
                cbPais1.ValueMember = "Bandeira";

                cbPais2.DataSource = new List<MoedaDto>(listaMoedas);
                cbPais2.DisplayMember = "Nome";
                cbPais2.ValueMember = "Bandeira";

                // 8) seleciona Real Brasileiro por padrão
                cbPais1.SelectedItem = listaMoedas.FirstOrDefault(m => m.Code == "BRL");
                cbPais2.SelectedItem = listaMoedas.FirstOrDefault(m => m.Code == "BRL");

                _inicializando = false;
                AtualizarBandeira(pbPais1, cbPais1);
                AtualizarBandeira(pbPais2, cbPais2);
                await AtualizarConversaoAsync(invert: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar moedas:\n{ex.Message}",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task AtualizarConversaoAsync(bool invert)
        {
            if (_inicializando) return;
            if (cbPais1.SelectedItem is not MoedaDto m1 ||
                cbPais2.SelectedItem is not MoedaDto m2)
                return;

            try
            {
                var fromCode = invert ? m2.Code : m1.Code;
                var toCode = invert ? m1.Code : m2.Code;
                var textoInput = invert ? mskMoeda2.Text : mskMoeda1.Text;
                var valorInput = decimal.TryParse(textoInput, out var tmp) ? tmp : 0M;

                // mesma moeda → só espelha
                if (m1.Code == m2.Code)
                {
                    var espelho = valorInput.ToString("N2");
                    if (invert)
                        SetTextWithoutTrigger(mskMoeda1, MskMoeda1_TextChanged, espelho);
                    else
                        SetTextWithoutTrigger(mskMoeda2, MskMoeda2_TextChanged, espelho);

                    lblInfo1.Text = $"1 {m1.Code} = 1 {m2.Code}";
                    lblInfo2.Text = $"1 {m2.Code} = 1 {m1.Code}";
                    return;
                }

                // valor ≤ 0 → traz taxa unitária
                if (valorInput <= 0)
                {
                    if (invert)
                        SetTextWithoutTrigger(mskMoeda1, MskMoeda1_TextChanged, "0");
                    else
                        SetTextWithoutTrigger(mskMoeda2, MskMoeda2_TextChanged, "0");

                    var urlTaxa = $"https://api.frankfurter.app/latest?from={fromCode}&to={toCode}&amount=1";
                    var jt = await _http.GetStringAsync(urlTaxa);
                    using var dt = JsonDocument.Parse(jt);
                    var rate = dt.RootElement.GetProperty("rates").GetProperty(toCode).GetDecimal();

                    lblInfo1.Text = $"1 {m1.Code} = {(invert ? 1M / rate : rate):N4} {m2.Code}";
                    lblInfo2.Text = $"1 {m2.Code} = {(invert ? rate : 1M / rate):N4} {m1.Code}";
                    return;
                }

                // conversão normal
                var url = $"https://api.frankfurter.app/latest?from={fromCode}&to={toCode}&amount={valorInput}";
                var json = await _http.GetStringAsync(url);
                using var doc = JsonDocument.Parse(json);
                var convertido = doc.RootElement.GetProperty("rates").GetProperty(toCode).GetDecimal();

                if (invert)
                    SetTextWithoutTrigger(mskMoeda1, MskMoeda1_TextChanged, convertido.ToString("N2"));
                else
                    SetTextWithoutTrigger(mskMoeda2, MskMoeda2_TextChanged, convertido.ToString("N2"));

                var rateUnit = convertido / valorInput;
                lblInfo1.Text = $"1 {m1.Code} = {(invert ? 1M / rateUnit : rateUnit):N4} {m2.Code}";
                lblInfo2.Text = $"1 {m2.Code} = {(invert ? rateUnit : 1M / rateUnit):N4} {m1.Code}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na conversão de moedas:\n{ex.Message}",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
