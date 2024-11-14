namespace MobileApp3;

public partial class BmiPage : ContentPage
{
    public BmiPage()
    {
        InitializeComponent();
    }

    private void OnCalculateBMIButtonClicked(object sender, EventArgs e)
    {
        // Kullan�c�dan boy ve kilo bilgilerini al
        var heightText = HeightEntry.Text;
        var weightText = WeightEntry.Text;

        // Boy ve kilo verilerinin do�rulu�unu kontrol et
        if (string.IsNullOrEmpty(heightText) || string.IsNullOrEmpty(weightText))
        {
            DisplayAlert("Hata", "L�tfen boy ve kilo bilgilerinizi girin.", "Tamam");
            return;
        }

        if (!double.TryParse(heightText, out double height) || !double.TryParse(weightText, out double weight))
        {
            DisplayAlert("Hata", "L�tfen ge�erli bir say� girin.", "Tamam");
            return;
        }

        // Boyu metre cinsine �evirmek (cm -> m)
        height /= 100;

        // V�cut Kitle Endeksi (BMI) hesapla
        double bmi = weight / (height * height);

        // Sonucu belirle
        string resultText = bmi switch
        {
            < 16 => "�leri D�zeyde Zay�f",
            < 17 => "Orta D�zeyde Zay�f",
            < 18.5 => "Hafif D�zeyde Zay�f",
            < 25 => "Normal Kilolu",
            < 30 => "Hafif �i�man / Fazla Kilolu",
            < 35 => "1. Derecede Obez",
            < 40 => "2. Derecede Obez",
            _ => "3. Derecede Obez / Morbid Obez"
        };

        // Sonucu ekrana yazd�r
        ResultLabel.Text = $"VKE: {bmi:F2}\n{resultText}";
        ResultLabel.IsVisible = true;
    }
}