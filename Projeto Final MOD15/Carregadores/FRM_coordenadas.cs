using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Final_MOD15.Carregadores
{
    public partial class FRM_coordenadas : Form
    {

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public FRM_coordenadas()
        {
            InitializeComponent();
        }

        private void BTN_pesquisar_Click(object sender, EventArgs e)
        {
            string latitude = TXT_latitude.Text;
            string longitude = TXT_longitude.Text;

            string local = "https://www.google.pt/maps/search/";

            StringBuilder queryCoords = new StringBuilder();
            queryCoords.Append("https://www.google.pt/maps/search/");


            if (!float.TryParse(latitude.Replace(".", ","), out float latFloat))
            {
                MessageBox.Show("Preencha a latitude");
                return;
            }
            if (!float.TryParse(longitude.Replace(".", ","), out float longFloat))
            {
                MessageBox.Show("Preencha a longitude");
                return;
            }

            if (-9.92114 > latFloat ||latFloat > -6.25616)
            {
                MessageBox.Show("A latitude precisa de estar entre -9.92114 e -6.25616");
                return;
            }
            if (36.58804 > longFloat || longFloat > 42.21245)
            {
                MessageBox.Show("A longitude precisa de estar entre 36.58804 e 42.21245");
                return;
            }

            latitude = latitude.Replace(",", ".");
            longitude = longitude.Replace(",", ".");
            local += (longitude + "," + latitude);

            PNL_pesquisar.Visible = false;
            WBB_maps.Navigate(local);

            TXT_latAtual.Text = latFloat.ToString();
            TXT_longAtual.Text = longFloat.ToString();
        }

        public void pesquisa(string latitude_, string longitude_)
        {
            TXT_latitude.Text = latitude_;
            TXT_longitude.Text = longitude_;
        }

        private void WBB_maps_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //TODO: ATUALIZAR AS TEXTBOX "atual" COM AS COORDENADAS ATUAIS

            string coordenadas_atuais = WBB_maps.Url.ToString();
            int inicio = coordenadas_atuais.IndexOf("/@");
            if (inicio != -1)
            {
                int fim = coordenadas_atuais.IndexOf("/", inicio+1);

                coordenadas_atuais.Substring(inicio+2, fim - inicio);

                List<string> listaCoordenadas = new List<string>(coordenadas_atuais.Substring(inicio + 2, fim - inicio).Split(','));
                listaCoordenadas.RemoveAt(2);

                TXT_latAtual.Text = listaCoordenadas[1];
                TXT_longAtual.Text = listaCoordenadas[0];
            }

        }

        private void PB_pesquisar_MouseEnter(object sender, EventArgs e)
        {

            PNL_pesquisar.Width += 10;
            PNL_pesquisar.Height += 10;

            PNL_pesquisar.Location = new Point(PNL_pesquisar.Location.X - 2, PNL_pesquisar.Location.Y - 2);


            PB_pesquisar.Width += 10;
            PB_pesquisar.Height += 10;

            PB_pesquisar.Location = new Point(PB_pesquisar.Location.X - 2, PB_pesquisar.Location.Y - 1);
        }

        private void BTN_guardar_Click(object sender, EventArgs e)
        {
            this.Latitude = TXT_latitude.Text;
            this.Longitude = TXT_longitude.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BTN_substituir_Click(object sender, EventArgs e)
        {
            float latAtual = float.Parse(TXT_latAtual.Text, CultureInfo.InvariantCulture);
            float longAtual = float.Parse(TXT_longAtual.Text, CultureInfo.InvariantCulture);

            if (-9.92114 > latAtual || latAtual > -6.25616)
            {
                MessageBox.Show("A latitude precisa de estar entre -9.92114 e -6.25616");
                return;
            }
            if (36.58804 > longAtual || longAtual > 42.21245)
            {
                MessageBox.Show("A longitude precisa de estar entre 36.58804 e 42.21245");
                return;
            }

            TXT_latitude.Text = TXT_latAtual.Text;
            TXT_longitude.Text = TXT_longAtual.Text;
        }

        private void BTN_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FRM_coordenadas_FormClosing(object sender, FormClosingEventArgs e)
        {
            WBB_maps.Dispose();
            WBB_maps = null;
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            System.GC.Collect();
        }
    }
}
