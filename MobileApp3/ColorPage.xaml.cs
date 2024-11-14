namespace MobileApp3;

public partial class ColorPage : ContentPage
{
	public ColorPage()
	{
		InitializeComponent();
	}

    private void OnColorChanged(object sender, ValueChangedEventArgs e)
    {
        var red = (int)RedSlider.Value;
        var green = (int)GreenSlider.Value;
        var blue = (int)BlueSlider.Value;

        ColorPreview.Color = Color.FromRgb(red, green, blue);

        // Renk kodunu güncelle
        string hexColor = $"#{red:X2}{green:X2}{blue:X2}";
        ColorCodeLabel.Text = $"Renk Kodu: {hexColor}";
    }

    private void OnRandomColorClicked(object sender, EventArgs e)
    {
        // Rastgele renk bileþenleri oluþtur
        Random random = new Random();
        int randomRed = random.Next(0, 256);  // 0 ile 255 arasýnda bir deðer
        int randomGreen = random.Next(0, 256);
        int randomBlue = random.Next(0, 256);

        // Slider'larý güncelle
        RedSlider.Value = randomRed;
        GreenSlider.Value = randomGreen;
        BlueSlider.Value = randomBlue;

        // BoxView rengini deðiþtir
        ColorPreview.Color = Color.FromRgb(randomRed, randomGreen, randomBlue);

        // Renk kodunu güncelle
        string hexColor = $"#{randomRed:X2}{randomGreen:X2}{randomBlue:X2}";
        ColorCodeLabel.Text = $"Renk Kodu: {hexColor}";
    }

    private async void OnCopyColorCodeClicked(object sender, EventArgs e)
    {
        // Renk kodunu kopyala
        string colorCode = ColorCodeLabel.Text?.Substring(12); // "Renk Kodu: #" kýsmýný atla
        if (!string.IsNullOrEmpty(colorCode))
        {
            await Clipboard.SetTextAsync(colorCode); // Panoya kopyala
            await DisplayAlert("Baþarýlý", "Renk kodu panoya kopyalandý.", "Tamam");
        }
    }





}