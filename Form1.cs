namespace JogoDaForcaWinApps
{
    public partial class Form1 : Form
    {
        private string palavra;
        private int tentativasRestantes;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NovaPalavra();
        }

        private void NovaPalavra()
        {
            // Aqui você pode adicionar uma lista de palavras para o jogo
            string[] palavras = { "CARRO", "CASA", "BANANA", "COMPUTADOR", "FLORESTA" };
            Random random = new Random();
            palavra = palavras[random.Next(palavras.Length)].ToUpper();

            tentativasRestantes = 6;
            AtualizarVisualizacaoPalavra();
            AtualizarVisualizacaoTentativas();
            txtPalavra.Text = "";
        }

        private void AtualizarVisualizacaoPalavra()
        {
            lblPalavra.Text = "";
            foreach (char c in palavra)
            {
                if (txtPalavra.Text.Contains(c.ToString()))
                {
                    lblPalavra.Text += c + " ";
                }
                else
                {
                    lblPalavra.Text += "_ ";
                }
            }
        }

        private void AtualizarVisualizacaoTentativas()
        {
            lblTentativas.Text = $"Tentativas restantes: {tentativasRestantes}";
        }

        private void VerificarLetra(char letra)
        {
            if (!txtPalavra.Text.Contains(letra.ToString()))
            {
                txtPalavra.Text += letra;
                if (!palavra.Contains(letra.ToString()))
                {
                    tentativasRestantes--;
                }
            }

            AtualizarVisualizacaoPalavra();
            AtualizarVisualizacaoTentativas();

            if (tentativasRestantes == 0)
            {
                MessageBox.Show("Você perdeu! A palavra era: " + palavra);
                NovaPalavra();
            }
            else if (lblPalavra.Text.IndexOf('_') == -1)
            {
                MessageBox.Show("Parabéns! Você ganhou!");
                NovaPalavra();
            }
        }

        private void btnLetra_Click(object sender, EventArgs e)
        {
            Button botao = (Button)sender;
            char letra = botao.Text[0];

            VerificarLetra(letra); 
        }



        private void btnNovoJogo_Click(object sender, EventArgs e)
        {
            NovaPalavra();
        }

       
    }
}