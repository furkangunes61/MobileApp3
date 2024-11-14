using Microsoft.Maui.Controls;
using System;
using System.Formats.Tar;

namespace MobileApp3
{
    public partial class CreditPage : ContentPage
    {
        public CreditPage()
        {
            InitializeComponent();
            CreditTypePicker.ItemsSource = new List<string>
    {
        "Ýhtiyaç Kredisi",
        "Konut Kredisi",
        "Taþýt Kredisi",
        "Ticari Kredi"
    };
            TermEntry.Text = TermSlider.Value.ToString("F0");
        }

        private void OnTermSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            TermEntry.Text = e.NewValue.ToString("F0");
        }

        private void OnCreditTypeChanged(object sender, EventArgs e)
        {
            string selectedCreditType = CreditTypePicker.SelectedItem.ToString();

            // Faiz oranýný kredi türüne göre güncelle
            if (selectedCreditType == "Ýhtiyaç Kredisi")
            {
                InterestRateEntry.Text = "1.20"; // Ýhtiyaç kredisi faiz oraný
            }
            else if (selectedCreditType == "Konut Kredisi")
            {
                InterestRateEntry.Text = "0.80"; // Konut kredisi faiz oraný
            }
            else if (selectedCreditType == "Taþýt Kredisi")
            {
                InterestRateEntry.Text = "1.50"; // Taþýt kredisi faiz oraný
            }
            else if (selectedCreditType == "Ticari Kredi")
            {
                InterestRateEntry.Text = "1.70"; // Ticari kredisi faiz oraný
            }
        }

        private void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            if (double.TryParse(AmountEntry.Text, out double principal) &&
                int.TryParse(TermEntry.Text, out int term) &&
                CreditTypePicker.SelectedItem != null)
            {
                var creditType = CreditTypePicker.SelectedItem.ToString();
                double monthlyInterestRate = 0.0;
                double kkdf = 0.0;
                double bsmv = 0.0;

                // Faiz oranlarýný belirleme
                switch (creditType)
                {
                    case "Ýhtiyaç Kredisi":
                        monthlyInterestRate = 1.20 / 100;
                        kkdf = 0.15;
                        bsmv = 0.10;
                        break;
                    case "Konut Kredisi":
                        monthlyInterestRate = 0.99 / 100;
                        kkdf = 0.0;
                        bsmv = 0.0;
                        break;
                    case "Taþýt Kredisi":
                        monthlyInterestRate = 1.10 / 100;
                        kkdf = 0.15;
                        bsmv = 0.05;
                        break;
                    case "Ticari Kredi":
                        monthlyInterestRate = 1.50 / 100;
                        kkdf = 0.0;
                        bsmv = 0.05;
                        break;
                }

                // Brüt faiz oraný hesaplama
                double grossInterestRate = monthlyInterestRate * (1 + kkdf + bsmv);

                // Aylýk taksit hesaplama formülü
                double monthlyInstallment = (Math.Pow(1 + grossInterestRate, term) * grossInterestRate) /
                                            (Math.Pow(1 + grossInterestRate, term) - 1) * principal;

                double totalPayment = monthlyInstallment * term;
                double totalInterest = totalPayment - principal;

                // Sonuçlarý kullanýcýya göster
                ResultLabel.Text = $"Aylýk Taksit: {monthlyInstallment:F2} TL\n" +
                                   $"Toplam Ödeme: {totalPayment:F2} TL\n" +
                                   $"Toplam Faiz: {totalInterest:F2} TL";
                ResultLabel.IsVisible = true;
            }
            else
            {
                ResultLabel.Text = "Lütfen geçerli bir tutar ve vade giriniz.";
                ResultLabel.IsVisible = true;
            }
        }
    }
}
