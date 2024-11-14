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

        // Renk kodunu g�ncelle
        string hexColor = $"#{red:X2}{green:X2}{blue:X2}";
        ColorCodeLabel.Text = $"Renk Kodu: {hexColor}";
    }

    private void OnRandomColorClicked(object sender, EventArgs e)
    {
        // Rastgele renk bile�enleri olu�tur
        Random random = new Random();
        int randomRed = random.Next(0, 256);  // 0 ile 255 aras�nda bir de�er
        int randomGreen = random.Next(0, 256);
        int randomBlue = random.Next(0, 256);

        // Slider'lar� g�ncelle
        RedSlider.Value = randomRed;
        GreenSlider.Value = randomGreen;
        BlueSlider.Value = randomBlue;

        // BoxView rengini de�i�tir
        ColorPreview.Color = Color.FromRgb(randomRed, randomGreen, randomBlue);

        // Renk kodunu g�ncelle
        string hexColor = $"#{randomRed:X2}{randomGreen:X2}{randomBlue:X2}";
        ColorCodeLabel.Text = $"Renk Kodu: {hexColor}";
    }

    private async void OnCopyColorCodeClicked(object sender, EventArgs e)
    {
        // Renk kodunu kopyala
        string colorCode = ColorCodeLabel.Text?.Substring(12); // "Renk Kodu: #" k�sm�n� atla
        if (!string.IsNullOrEmpty(colorCode))
        {
            await Clipboard.SetTextAsync(colorCode); // Panoya kopyala
            await DisplayAlert("Ba�ar�l�", "Renk kodu panoya kopyaland�.", "Tamam");
        }
    }





}