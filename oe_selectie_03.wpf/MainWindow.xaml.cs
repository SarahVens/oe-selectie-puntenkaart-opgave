using System;
using System.Windows;
using System.Windows.Controls;

namespace oe_selectie_03.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Variabelen declareren
        int gewichtWetenschappen;
        int gewichtWiskunde;
        int gewichtTalen;
        int scoreWetenschappen;
        int scoreWiskunde;
        int scoreTalen;
        int TotaleScoreWetenschappen;
        int TotaleScoreWiskunde;
        int TotaleScoreTalen;
        int behaald;
        int behaaldOp;
        float procent;

        //methodes
        void VulDeComboboxen(params string[] gewichten)
        {
            foreach (string gewicht in gewichten)
            {
                cmbTalen.Items.Add(gewicht);
                cmbWetenschappen.Items.Add(gewicht);
                cmbWiskunde.Items.Add(gewicht);
            }
        }

        void SetupTheGui()
        {
            txtTalen.Text = "0";
            txtWetenschappen.Text = "0";
            txtWiskunde.Text = "0";
            lblBehaald.Content = "";
            lblBeoordeling.Content = "";
            lblProcent.Content = "";
            lblTalen.Content = "";
            lblWetenschappen.Content = "";
            lblWiskunde.Content = "";
        }
        int BerekenDeScore(int gewicht, int score)
        {
            return gewicht * score;
        }

        int CheckDeScore(int score)
        {
            int tien;
            if (score > 10) tien = 10;
            else tien = score;
            return tien;
        }

        void BerekenBehaaldeScore(int gewichtWetenschappen, int gewichtWiskunde, int gewichtTalen, int scoreWetenschappen, int scoreWiskunde, int scoreTalen)
        {

            behaald = scoreWetenschappen + scoreWiskunde + scoreTalen;
            behaaldOp = (gewichtTalen + gewichtWetenschappen + gewichtWiskunde) * 10;
            procent = (Convert.ToSingle(behaald) / Convert.ToSingle(behaaldOp)) * 100;
            lblProcent.Content = $"{procent.ToString("00.00")}%";
            lblBehaald.Content = $"{behaald}/{behaaldOp}";
            CheckDeBeoordeling(procent);

        }
        void CheckDeBeoordeling(float procent)
        {
            if (procent < 50) lblBeoordeling.Content = "Niet Geslaagd";
            else if ((procent >= 50 && procent < 68) && (behaald < (behaaldOp / 2))) lblBeoordeling.Content = "Geslaagd op vodoende wijze maar met herexamens";
            else if ((procent >= 50 && procent < 68) && (behaald >= (behaaldOp / 2))) lblBeoordeling.Content = "Geslaagd op vodoende wijze ";
            else if (procent >= 68 && procent < 77) lblBeoordeling.Content = "Geslaagd met onderscheiding";
            else if (procent >= 77 && procent < 85) lblBeoordeling.Content = "geslaagd met groote ondescheiding";
            else if (procent >= 85 && procent < 905) lblBeoordeling.Content = "Geslaagd met grootste ondescheiding";
            else lblBeoordeling.Content = "Geslaagd met grootste onderscheiding en de gelukwensen van de examencomissie";
        }

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulDeComboboxen("1", "2", "3");
            //SetupTheGui();
            gewichtWetenschappen = int.Parse(cmbWetenschappen.SelectedItem.ToString());
            gewichtWiskunde = int.Parse(cmbWiskunde.SelectedItem.ToString());
            gewichtTalen = int.Parse(cmbTalen.SelectedItem.ToString());
            scoreWiskunde = int.Parse(txtWiskunde.Text);
            scoreWetenschappen = int.Parse(txtWetenschappen.Text);
            scoreTalen = int.Parse(txtTalen.Text);
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            SetupTheGui();
        }
        //wetenschappen
        private void cmbWetenschappen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gewichtWetenschappen = int.Parse(cmbWetenschappen.SelectedItem.ToString());
            int score = int.Parse(txtWetenschappen.Text);
            TotaleScoreWetenschappen = BerekenDeScore(gewichtWetenschappen, score);
            lblWetenschappen.Content = TotaleScoreWetenschappen.ToString();
            BerekenBehaaldeScore(gewichtTalen, gewichtWetenschappen, gewichtWiskunde, TotaleScoreWetenschappen, TotaleScoreWiskunde, TotaleScoreTalen);


        }
        private void txtWetenschappen_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtWetenschappen.IsLoaded)
            {
                
                gewichtWetenschappen = int.Parse(cmbWetenschappen.SelectedItem.ToString());
                int score = int.Parse(txtWetenschappen.Text);
                score = CheckDeScore(score);
                txtWetenschappen.Text = score.ToString();
                TotaleScoreWetenschappen = BerekenDeScore(gewichtWetenschappen, score);
                lblWetenschappen.Content = TotaleScoreWetenschappen.ToString();
                BerekenBehaaldeScore(gewichtTalen, gewichtWetenschappen, gewichtWiskunde, TotaleScoreWetenschappen, TotaleScoreWiskunde, TotaleScoreTalen);

            }
        }
        //wiskunde
        private void cmbWiskunde_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gewichtWiskunde = int.Parse(cmbWiskunde.SelectedItem.ToString());
            int score = int.Parse(txtWiskunde.Text);
            TotaleScoreWiskunde = BerekenDeScore(gewichtWiskunde, score);
            lblWiskunde.Content = TotaleScoreWiskunde.ToString();
            BerekenBehaaldeScore(gewichtTalen, gewichtWetenschappen, gewichtWiskunde, TotaleScoreWetenschappen, TotaleScoreWiskunde, TotaleScoreTalen);

        }
        private void txtWiskunde_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtWiskunde.IsLoaded)
            {
                gewichtWiskunde = int.Parse(cmbWiskunde.SelectedItem.ToString());
                int score = int.Parse(txtWiskunde.Text);
                score = CheckDeScore(score);
                txtWiskunde.Text = score.ToString();
                TotaleScoreWiskunde = BerekenDeScore(gewichtWiskunde, score);
                lblWiskunde.Content = TotaleScoreWiskunde.ToString();
                BerekenBehaaldeScore(gewichtTalen, gewichtWetenschappen, gewichtWiskunde, TotaleScoreWetenschappen, TotaleScoreWiskunde, TotaleScoreTalen);

            }
        }
        //talen
        private void cmbTalen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gewichtTalen = int.Parse(cmbTalen.SelectedItem.ToString());
            int score = int.Parse(txtTalen.Text);
            TotaleScoreTalen = BerekenDeScore(gewichtTalen, score);
            lblTalen.Content = TotaleScoreTalen.ToString();
            BerekenBehaaldeScore(gewichtTalen, gewichtWetenschappen, gewichtWiskunde, TotaleScoreWetenschappen, TotaleScoreWiskunde, TotaleScoreTalen);

        }
        private void txtTalen_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtTalen.IsLoaded)
            {
                gewichtTalen = int.Parse(cmbTalen.SelectedItem.ToString());
                int score = int.Parse(txtTalen.Text);

                score = CheckDeScore(score);
                txtTalen.Text = score.ToString();
                TotaleScoreTalen = BerekenDeScore(gewichtTalen, score);
                lblTalen.Content = TotaleScoreTalen.ToString();
                BerekenBehaaldeScore(gewichtTalen, gewichtWetenschappen, gewichtWiskunde, TotaleScoreWetenschappen, TotaleScoreWiskunde, TotaleScoreTalen);
            
            }
        }

        private void txtWetenschappen_GotFocus(object sender, RoutedEventArgs e)
        {
            txtWetenschappen.SelectAll();
        }

        private void txtWiskunde_GotFocus(object sender, RoutedEventArgs e)
        {
            txtWiskunde.SelectAll();
        }

        private void txtTalen_GotFocus(object sender, RoutedEventArgs e)
        {
            txtTalen.SelectAll();
        }
    }
}
