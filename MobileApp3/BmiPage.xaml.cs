namespace MobileApp3;

public partial class BmiPage : ContentPage
{
    public BmiPage()
    {
        InitializeComponent();
    }

    private void OnCalculateBMIButtonClicked(object sender, EventArgs e)
    {
        // Kullanýcýdan boy ve kilo bilgilerini al
        var heightText = HeightEntry.Text;
        var weightText = WeightEntry.Text;

        // Boy ve kilo verilerinin doðruluðunu kontrol et
        if (string.IsNullOrEmpty(heightText) || string.IsNullOrEmpty(weightText))
        {
            DisplayAlert("Hata", "Lütfen boy ve kilo bilgilerinizi girin.", "Tamam");
            return;
        }

        if (!double.TryParse(heightText, out double height) || !double.TryParse(weightText, out double weight))
        {
            DisplayAlert("Hata", "Lütfen geçerli bir sayý girin.", "Tamam");
            return;
        }

        // Boyu metre cinsine çevirmek (cm -> m)
        height /= 100;

        // Vücut Kitle Endeksi (BMI) hesapla
        double bmi = weight / (height * height);

        // Sonucu belirle
        string resultText = bmi switch
        {
            < 16 => "Ýleri Düzeyde Zayýf",
            < 17 => "Orta Düzeyde Zayýf",
            < 18.5 => "Hafif Düzeyde Zayýf",
            < 25 => "Normal Kilolu",
            < 30 => "Hafif Þiþman / Fazla Kilolu",
            < 35 => "1. Derecede Obez",
            < 40 => "2. Derecede Obez",
            _ => "3. Derecede Obez / Morbid Obez"
        };

        // Sonucu ekrana yazdýr
        ResultLabel.Text = $"VKE: {bmi:F2}\n{resultText}";
        ResultLabel.IsVisible = true;
    }
}